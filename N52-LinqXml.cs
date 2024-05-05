using System;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        // Generate XML content for 10 employees
        string xmlContent = GenerateEmployeeXml(1000);
        //Requete compilée
        XDocument doc = XDocument.Parse(xmlContent);
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        var query = from el in doc.Descendants("Employee")
                    select el;
        stopwatch.Stop();
        long elapsed = stopwatch.ElapsedMilliseconds;

        Expression<Func<XDocument, IEnumerable<string>>> queryExpression =
            d => d.Descendants("Employee").Select(e => e.Element("Name").Value);
        //Requete  compilée

        Func<XDocument, IEnumerable<string>> compiledQuery = queryExpression.Compile();
        stopwatch.Restart();
        IEnumerable<string> result = compiledQuery(doc);
        stopwatch.Stop();
        elapsed = stopwatch.ElapsedMilliseconds;
    }

    static string GenerateEmployeeXml(int numberOfEmployees)
    {
        // Create a root element for the XML document
        XElement employeesElement = new XElement("Employees");

        // Generate XML content for each employee
        for (int i = 1; i <= numberOfEmployees; i++)
        {
            // Generate random values for employee properties
            int id = i;
            string name = "Employee" + i;
            decimal salary = GenerateRandomSalary();
            int daysOff = GenerateRandomDaysOff();
            DateTime hireDate = GenerateRandomHireDate();

            // Create an XElement for the current employee
            XElement employeeElement = new XElement("Employee",
                new XElement("Id", id),
                new XElement("Name", GenerateRandomName()),
                new XElement("Salary", salary),
                new XElement("DaysOff", daysOff),
                new XElement("HireDate", hireDate.ToString("yyyy-MM-dd")),
                new XElement("Department", GenerateRandomDepartement()),
                new XElement("Department", GenerateFakeProjects(1))
            );

            // Add the employee element to the root element
            employeesElement.Add(employeeElement);
        }

        // Create an XDocument with the root element
        XDocument doc = new XDocument(employeesElement);

        // Return the XML content as a string
        return doc.ToString();
    }

    private static string GenerateRandomDepartement()
    {
        string[] departements = { "General direction", "Finance", "Production", "Marketing", "Research and devlopment" };
        Random random = new Random();
        int r = random.Next(0, departements.Length);
        string departement = departements[r];
        return departement;
    }

    static string GenerateRandomName()
    {
        string[] firstNames = { "John", "Jane", "David", "Emily", "Michael", "Emma", "Daniel", "Olivia", "Matthew", "Sophia" };
        string[] lastNames = { "Smith", "Johnson", "Williams", "Jones", "Brown", "Davis", "Miller", "Wilson", "Moore", "Taylor" };
        Random random = new Random();
        int r = random.Next(0, firstNames.Length);
        string firstName = firstNames[r];
        r = random.Next(0, firstNames.Length);
        string lastName = lastNames[r];
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


    static decimal GenerateRandomSalary()
    {
        // Generate a random salary between 3000 and 10000
        Random random = new Random();
        int r = random.Next(3000, 10001);
        return Math.Round((decimal)(r), 2);
    }

    static int GenerateRandomDaysOff()
    {
        // Generate a random number of days off between 0 and 30
        Random random = new Random();
        return random.Next(0, 31);
    }

    static DateTime GenerateRandomHireDate()
    {
        // Generate a random hire date within the last 5 years
        Random random = new Random();
        DateTime startDate = DateTime.Today.AddYears(-5);
        int range = (DateTime.Today - startDate).Days;
        return startDate.AddDays(random.Next(range));
    }
}
