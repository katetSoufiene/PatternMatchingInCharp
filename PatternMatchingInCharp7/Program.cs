using System;
using System.Linq.Expressions;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Pattern Matching C# 7");
            var emp = new LocalEmployee();
            Console.WriteLine(GetBenefits(emp));
            Console.ReadLine();
        }

        static string GetBenefits(Employee employee)
        {
            switch (employee)
            {
                case PermanentEmployee permanentEmployee when permanentEmployee is LocalEmployee:
                    return permanentEmployee.Benefits;
                case PermanentEmployee permanentEmployee when permanentEmployee is RemoteEmployee:
                    return "healthcare , sick pay and transport";
                default:
                    return "Unkmown";
            }
        }
    }

    public class Employee { }
    public class PermanentEmployee : Employee
    {
        public virtual string Benefits { get; set; } = "healthcare and sick pay";
    }

    public class ContractorEmployee : Employee { }

    public class LocalEmployee : PermanentEmployee { }
    public class RemoteEmployee : PermanentEmployee
    {
        public override string Benefits { get => base.Benefits; set => base.Benefits = value; }
    }
}
