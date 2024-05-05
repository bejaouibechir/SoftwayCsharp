using System;
using System.Collections.Generic;
using System.Linq;

namespace Client
{
    class LinqExemples
    {
        public void simplequeries_immediate()
        {
            List<Employee> employees = Employee.GenerateFakeEmployees(50);
            //Where Filtre une séquence de valeurs en fonction d'une fonction prédicat:
            var highSalaryEmployees = employees.Where(emp => emp.Salary > 5000);
            //OrderBy Trie les éléments d'une séquence par ordre croissant:
            var sortedEmployees = employees.OrderBy(emp => emp.Name);
            //ThenBy Effectue un tri ultérieur des éléments dans une séquence par ordre croissant:
            var doublesortedEmployees = employees.OrderBy(emp => emp.Name).ThenBy(emp => emp.Salary);
            //Select Projette chaque élément d'un manière groupée
            var employeeSelect = employees.Select(emp => emp.Projects);
            //Select Projette chaque élément d'un manière flatte
            var employeeSelectMany = employees.SelectMany(emp => emp.Projects);
            //Any Détermine si au moins une séquence contient un élément spécifié:
            var containsJohnAny = employees.Any(emp => emp.Name == "John");
            //Any Détermine si au toutes les séquences contiennent un élément spécifié:
            var containsJohnAll = employees.All(emp => emp.Name == "John");
            //First Retourne le premier élément d'une séquence:
            var firstEmployee = employees.First();
            //FirstOrDefault Retourne le premier élément d'une séquence,
            //ou une valeur par défaut si la séquence ne contient aucun élément:
            var firstEmployee2 = employees.FirstOrDefault();
            //SingleRetourne l'unique élément d'une séquence, ou lève une exception
            //s'il n'y a pas exactement un élément dans la séquence:
            var singleEmployee = employees.Single(emp => emp.Id == 1);
            //SingleOrDefault Retourne l'unique élément d'une séquence, ou une valeur par défaut
            //si la séquence est vide ;
            //cette méthode lève une exception s'il y a plus d'un élément dans la séquence:
            var singleEmployee2 = employees.SingleOrDefault(emp => emp.Id == 1);
            IEnumerable<Employee> otherEmployees = employees.Take(10);
            //SequenceEqual  Détermine si deux séquences sont égales en comparant leurs éléments:
            var areEqual = employees.SequenceEqual(otherEmployees);
            //Distinct Retourne les éléments distincts d'une séquence:
            var distinctEmployees = employees.Distinct();
            IEnumerable<Employee> managementEmployees = employees.Take(5);
            //Except Produit la différence ensembliste de deux séquences:
            var employeesNotInManagement = employees.Except(managementEmployees);
            //Intersect Produit l'intersection ensembliste de deux séquences:
            var commonEmployees = employees.Intersect(managementEmployees);
            //Union Produit l'union ensembliste de deux séquences:
            var allEmployees = employees.Union(managementEmployees);
            //Skip Ignore un nombre spécifié d'éléments dans une séquence,
            //puis retourne les éléments restants:
            var employeesAfterSkipping = employees.Skip(5);
            //SkipWhile Ignore les éléments dans une séquence tant qu'une condition spécifiée est vraie,
            //puis retourne les éléments restants:
            var employeesAfterSkipping2 = employees.SkipWhile(emp => emp.Salary < 5000);
            //Take Retourne un nombre spécifié d'éléments contigus à partir du début d'une séquence:
            var first5Employees = employees.Take(5);
            //TakeWhileRetourne les éléments d'une séquence tant qu'une condition spécifiée est vraie,
            //puis ignore les éléments restants:
            var highSalaryEmployees2 = employees.TakeWhile(emp => emp.Salary > 5000);
            //DefaultIfEmpty Retourne les éléments de la séquence spécifiée ou la valeur spécifiée dans
            //une collection singleton si la séquence est vide:
            var employeesOrEmpty = employees.DefaultIfEmpty();
            //Aggregate Applique une fonction accumulateur sur une séquence:
            var totalSalaries = employees.Aggregate((sum, emp) 
                    =>new Employee(51,"majd",sum.Salary+emp.Salary,5,DateTime.Now,"Finance"));
            //Concat Rassemble deux ensembles 
            var employeeConcat = employees.Concat(otherEmployees);
            //GroupBy Groupe les éléments d'une séquence en fonction d'une fonction sélectrice de clé:
            var employeesByDepartment = employees.GroupBy(emp => emp.Department);
            //ToLookup Crée un Lookup<TKey, TElement> à partir d'un IEnumerable<T>
            //selon une fonction de sélecteur de clé spécifiée:
            var employeesLookup = employees.ToLookup(emp => emp.Department);
            //Average Calcule la moyenne d'une séquence de valeurs numériques:
            var averageSalary = employees.Average(emp => emp.Salary);
            //Count Retourne le nombre d'éléments dans une séquence:
            var numberOfEmployees = employees.Count();
            //Max Retourne la valeur maximale dans une séquence:
            var maxSalary = employees.Max(emp => emp.Salary);
            //Min Retourne la valeur minimale dans une séquence:   
            var minSalary = employees.Min(emp => emp.Salary);
            //ElementAt returne un élement au niveau d'un indice donné
            var employeeAt = employees.ElementAt(employees.Count() - 1);

            
        }


        public void exemple_let()
        {
            List<Employee> employees = Employee.GenerateFakeEmployees(50);

            var newSalaries = from emp in employees
                              let increasedSalary = emp.Salary * 1.1m // Augmenter le salaire de 10%
                              select new { emp.Name, IncreasedSalary = increasedSalary };

            foreach (var employee in newSalaries)
            {
                Console.WriteLine($"{employee.Name}: {employee.IncreasedSalary}");
            }
        }

        public void exemple_into()
        {
            List<Employee> employees = Employee.GenerateFakeEmployees(50);

            var salaryGroups = from emp in employees
                               group emp by emp.Salary > 5000 into highSalaryGroup
                               select new
                               {
                                   IsHighSalary = highSalaryGroup.Key,
                                   Employees = highSalaryGroup.ToList()
                               };

            foreach (var group in salaryGroups)
            {
                if (group.IsHighSalary)
                    Console.WriteLine("High Salary Employees:");
                else
                    Console.WriteLine("Normal Salary Employees:");

                foreach (var employee in group.Employees)
                {
                    Console.WriteLine($" - {employee.Name}: {employee.Salary}");
                }
            }
        }
    }
    
    
    
    class Employee
    {
        public Employee()
        {
            
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public int DaysOff { get; set; }
        public DateTime HireDate { get; set; }
        public object Department { get; internal set; }
        public List<string> Projects { get; set; }

        public Employee(int id, string name, decimal salary, 
            int daysOff, DateTime hireDate,string department)
        {
            Id = id;
            Name = name;
            Salary = salary;
            DaysOff = daysOff;
            HireDate = hireDate;
            Department = department;
        }


        static public List<Employee> GenerateFakeEmployees(int count)
        {
            List<Employee> employees = new List<Employee>();
            Random random = new Random();

            // Generate fake data for employees
            for (int i = 0; i < count; i++)
            {
                int id = i + 1;
                string name = GenerateRandomName();
                string department = GenerateRandomDepartement();
                decimal salary = Math.Round((decimal)(random.NextDouble() * 10000), 2);
                int daysOff = random.Next(0, 30);
                DateTime hireDate = DateTime.Now.AddYears(-random.Next(0, 10));
                Employee employee = new Employee(id, name, salary, daysOff, hireDate, department);
                employee.Projects = GenerateFakeProjects(random.Next(5, 10));
                employees.Add(employee);
            }

            return employees;
        }

        private static string GenerateRandomDepartement()
        {
            string[] departements = { "General direction", "Finance", "Production", "Marketing", "Research and devlopment" };
            Random random = new Random();
            string departement = departements[random.Next(0, departements.Length)];
            return departement;
        }

        static string GenerateRandomName()
        {
            string[] firstNames = { "John", "Jane", "David", "Emily", "Michael", "Emma", "Daniel", "Olivia", "Matthew", "Sophia" };
            string[] lastNames = { "Smith", "Johnson", "Williams", "Jones", "Brown", "Davis", "Miller", "Wilson", "Moore", "Taylor" }; 
            Random random = new Random();
            string firstName = firstNames[random.Next(0, firstNames.Length)];
            string lastName = lastNames[random.Next(0, lastNames.Length)];

            return $"{firstName} {lastName}";
        }

        public static List<string> GenerateFakeProjects(int numProjects)
        {
            Random random = new Random();
            List<string> projects = new List<string>();
            // List of sample project names
            string[] sampleProjectNames = { "Project A", "Project B", "Project C", "Project D", "Project E" };

            for (int i = 0; i < numProjects; i++)
            {
                // Choose a random project name from the sample list
                string projectName = sampleProjectNames[random.Next(sampleProjectNames.Length)];
                // Append a random number to make project names distinct
                projectName += "_" + random.Next(1000);
                projects.Add(projectName);
            }
            return projects;
        }
    }
}
