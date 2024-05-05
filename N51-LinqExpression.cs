using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, int> somme = (a, b) => a + b;
            Expression<Func<int, int, int>> expression = (a, b) => a + b;
            Visitor visitor = new Visitor();
            visitor.Visit(expression);
            string result = visitor.ToString();
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }

    public class Visitor : ExpressionVisitor
    {
        List<string> _expressionList;
        IReadOnlyCollection<Expression> _parameters;
        bool _firstparam = true;
        public Visitor() => _expressionList = new List<string>();



        protected override Expression VisitLambda<T>(Expression<T> node)
        {
            string parameters = string.Empty;
            _parameters = node.Parameters;

            List<ParameterExpression> ps = new List<ParameterExpression>();
            foreach (ParameterExpression item in node.Parameters)
            {
                parameters += $"{item} ,";
            }
            if (node.ReturnType.Name != string.Empty)
                parameters += " la valeur retournée est de type " + node.ReturnType;
            _expressionList.Add($"Cette expression lambda contient les paramètres : {parameters}");

            return base.VisitLambda(node);

        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            if (_firstparam == true)
            {
                _expressionList.Add($" la valeur du paramètre {node.Name} de type {node.Type} ");
                _firstparam = false;
            }
            else
            {
                _expressionList.Add($" à la valeur du paramètre {node.Name} de type {node.Type} ");
            }

            return base.VisitParameter(node);
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            switch (node.NodeType)
            {
                case ExpressionType.Add:
                    _expressionList.Add(" consiste à ajouter ");
                    break;
                case ExpressionType.AddChecked:
                    break;
                case ExpressionType.And:
                    _expressionList.Add("+");
                    break;
                case ExpressionType.AndAlso:
                    _expressionList.Add(" et aussi ");
                    break;
                case ExpressionType.ArrayLength:
                    break;
                case ExpressionType.ArrayIndex:
                    break;
                case ExpressionType.Call:
                    break;
                case ExpressionType.Coalesce:
                    break;
                case ExpressionType.Conditional:
                    break;
                case ExpressionType.Constant:
                    break;
                case ExpressionType.Convert:
                    _expressionList.Add(" convertir ");
                    break;
                case ExpressionType.ConvertChecked:
                    break;
                case ExpressionType.Divide:
                    break;
                case ExpressionType.Equal:
                    break;
                case ExpressionType.ExclusiveOr:
                    break;
                case ExpressionType.GreaterThan:
                    break;
                case ExpressionType.GreaterThanOrEqual:
                    break;
                case ExpressionType.Invoke:
                    break;
                case ExpressionType.Lambda:
                    break;
                case ExpressionType.LeftShift:
                    break;
                case ExpressionType.LessThan:
                    break;
                case ExpressionType.LessThanOrEqual:
                    break;
                case ExpressionType.ListInit:
                    break;
                case ExpressionType.MemberAccess:
                    break;
                case ExpressionType.MemberInit:
                    break;
                case ExpressionType.Modulo:
                    break;
                case ExpressionType.Multiply:
                    break;
                case ExpressionType.MultiplyChecked:
                    break;
                case ExpressionType.Negate:
                    break;
                case ExpressionType.UnaryPlus:
                    break;
                case ExpressionType.NegateChecked:
                    break;
                case ExpressionType.New:
                    break;
                case ExpressionType.NewArrayInit:
                    break;
                case ExpressionType.NewArrayBounds:
                    break;
                case ExpressionType.Not:
                    break;
                case ExpressionType.NotEqual:
                    break;
                case ExpressionType.Or:
                    break;
                case ExpressionType.OrElse:
                    break;
                case ExpressionType.Parameter:
                    break;
                case ExpressionType.Power:
                    break;
                case ExpressionType.Quote:
                    break;
                case ExpressionType.RightShift:
                    break;
                case ExpressionType.Subtract:
                    break;
                case ExpressionType.SubtractChecked:
                    break;
                case ExpressionType.TypeAs:
                    break;
                case ExpressionType.TypeIs:
                    break;
                case ExpressionType.Assign:
                    break;
                case ExpressionType.Block:
                    break;
                case ExpressionType.DebugInfo:
                    break;
                case ExpressionType.Decrement:
                    break;
                case ExpressionType.Dynamic:
                    break;
                case ExpressionType.Default:
                    break;
                case ExpressionType.Extension:
                    break;
                case ExpressionType.Goto:
                    break;
                case ExpressionType.Increment:
                    break;
                case ExpressionType.Index:
                    break;
                case ExpressionType.Label:
                    break;
                case ExpressionType.RuntimeVariables:
                    break;
                case ExpressionType.Loop:
                    break;
                case ExpressionType.Switch:
                    break;
                case ExpressionType.Throw:
                    break;
                case ExpressionType.Try:
                    break;
                case ExpressionType.Unbox:
                    break;
                case ExpressionType.AddAssign:
                    break;
                case ExpressionType.AndAssign:
                    break;
                case ExpressionType.DivideAssign:
                    break;
                case ExpressionType.ExclusiveOrAssign:
                    break;
                case ExpressionType.LeftShiftAssign:
                    break;
                case ExpressionType.ModuloAssign:
                    break;
                case ExpressionType.MultiplyAssign:
                    break;
                case ExpressionType.OrAssign:
                    break;
                case ExpressionType.PowerAssign:
                    break;
                case ExpressionType.RightShiftAssign:
                    break;
                case ExpressionType.SubtractAssign:
                    break;
                case ExpressionType.AddAssignChecked:
                    break;
                case ExpressionType.MultiplyAssignChecked:
                    break;
                case ExpressionType.SubtractAssignChecked:
                    break;
                case ExpressionType.PreIncrementAssign:
                    break;
                case ExpressionType.PreDecrementAssign:
                    break;
                case ExpressionType.PostIncrementAssign:
                    break;
                case ExpressionType.PostDecrementAssign:
                    break;
                case ExpressionType.TypeEqual:
                    break;
                case ExpressionType.OnesComplement:
                    break;
                case ExpressionType.IsTrue:
                    break;
                case ExpressionType.IsFalse:
                    break;
                default:
                    break;
            }


            return base.VisitBinary(node);
        }
        public override string ToString()
        {
            return _expressionList[0] +
                _expressionList[1] +
                _expressionList[2] +
                _expressionList[3];
        }

    }
}
