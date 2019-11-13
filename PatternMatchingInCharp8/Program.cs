using System;

namespace PatternMatchingInCharp8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Pattern Matching C# 8");

            var emp = new LocalEmployee();
            Console.WriteLine(GetBenefits(emp));
            Console.ReadLine();
        }

        static string GetBenefits(Employee employee) =>
          employee switch
          {
              PermanentEmployee permanentEmployee when permanentEmployee is LocalEmployee => permanentEmployee.Benefits,
              PermanentEmployee permanentEmployee when permanentEmployee is RemoteEmployee => "healthcare , sick pay and transport",
              _ => "Unkmown"
          };

        // property 
        static int GetBenefitCode(PermanentEmployee employee) =>
          employee switch
          {
              { Benefits: "healthcare and sick pay" } => 1,
              { Benefits: "healthcare , sick pay and transport" } => 2,
              _ => 0
          };

        static bool Authorise(string apiKey, string authToken, bool isAuthTokenValid)
        => (apiKey, authToken, isAuthTokenValid) switch
        {
            ("987654321", _, _) => true,
            (_, _, true) => true,
            (_, _, false) => false,
           // _ => false,
        };
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
