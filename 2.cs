using System;

public class Employee
{
    public string Name { get; set; }
    public double Salary { get; set; }

    public Employee(string name, double salary)
    {
        Name = name;
        Salary = salary;
    }

    public virtual double CalculateBonus()
    {
        return 0;
    }

    public override string ToString()
    {
        return $"{Name}, Зарплата: {Salary}, Бонус: {CalculateBonus()}";
    }
}

public interface IReportable
{
    void GenerateReport();
}

public class Manager : Employee, IReportable
{
    public Manager(string name, double salary) : base(name, salary) { }

    public override double CalculateBonus()
    {
        return Salary * 1.20;
    }

    public void GenerateReport()
    {
        Console.WriteLine($"Менеджер {Name} створює звіт.");
    }
}

public class Developer : Employee
{
    public Developer(string name, double salary) : base(name, salary) { }

    public override double CalculateBonus()
    {
        return Salary * 1.10;
    }
}

class Program
{
    static void Main()
    {
        Employee manager = new Manager("Олександр", 30000);
        Employee developer = new Developer("Іван", 20000);

        Console.WriteLine(manager);
        Console.WriteLine(developer);

        IReportable reportable = (IReportable)manager;
        reportable.GenerateReport();
    }
}
