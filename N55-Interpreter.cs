/*
Explication
Interface IExpression :

Définit la méthode Interpret que toutes les expressions concrètes doivent implémenter pour évaluer leur résultat en fonction du contexte.
Classe Context :

Contient un dictionnaire de variables avec leurs valeurs.
Fournit des méthodes pour définir et récupérer les valeurs des variables.
Classes d'expressions (NumberExpression, AddExpression, SubtractExpression) :

Implémentent l'interface IExpression.
Chaque classe d'expression interprète une partie spécifique de la grammaire (nombre, addition, soustraction) en utilisant le contexte pour récupérer les valeurs des variables.
Classe Program :

Contient le point d'entrée Main où un contexte est configuré avec des variables.
Une expression composée est créée (dans cet exemple, une expression qui additionne deux variables et soustrait une autre variable).
L'expression est évaluée en utilisant le contexte pour obtenir les valeurs des variables et obtenir le résultat.
Dans cet exemple, le pattern Interpreter est utilisé pour construire une grammaire simple pour évaluer des expressions arithmétiques composées de nombres et d'opérations d'addition/soustraction.
*/

using System;
using System.Collections.Generic;

namespace InterpreterPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();

            // Définir le contexte avec des variables
            context.SetVariable("x", 10);
            context.SetVariable("y", 5);

            // Définir l'expression à évaluer
            IExpression expression = new SubtractExpression(
                new AddExpression(new NumberExpression("x"), new NumberExpression("y")),
                new NumberExpression("y"));

            // Évaluer l'expression
            int result = expression.Interpret(context);
            Console.WriteLine("Résultat de l'expression : " + result);
        }
    }

    // Contexte contenant les variables
    public class Context
    {
        private Dictionary<string, int> variables = new Dictionary<string, int>();

        public void SetVariable(string name, int value)
        {
            variables[name] = value;
        }

        public int GetVariable(string name)
        {
            if (variables.ContainsKey(name))
                return variables[name];
            else
                throw new KeyNotFoundException($"Variable {name} not found.");
        }
    }

    // Interface pour les expressions
    public interface IExpression
    {
        int Interpret(Context context);
    }

    // Expression pour un nombre
    public class NumberExpression : IExpression
    {
        private string variableName;

        public NumberExpression(string variableName)
        {
            this.variableName = variableName;
        }

        public int Interpret(Context context)
        {
            return context.GetVariable(variableName);
        }
    }

    // Expression pour l'addition
    public class AddExpression : IExpression
    {
        private IExpression leftExpression;
        private IExpression rightExpression;

        public AddExpression(IExpression leftExpression, IExpression rightExpression)
        {
            this.leftExpression = leftExpression;
            this.rightExpression = rightExpression;
        }

        public int Interpret(Context context)
        {
            return leftExpression.Interpret(context) + rightExpression.Interpret(context);
        }
    }

    // Expression pour la soustraction
    public class SubtractExpression : IExpression
    {
        private IExpression leftExpression;
        private IExpression rightExpression;

        public SubtractExpression(IExpression leftExpression, IExpression rightExpression)
        {
            this.leftExpression = leftExpression;
            this.rightExpression = rightExpression;
        }

        public int Interpret(Context context)
        {
            return leftExpression.Interpret(context) - rightExpression.Interpret(context);
        }
    }
}
