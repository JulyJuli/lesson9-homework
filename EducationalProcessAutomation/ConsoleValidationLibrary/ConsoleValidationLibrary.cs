using System;

namespace ConsoleValidationLibrary
{
    public class ValidationLibrary
    {
        public static int GetNumericVariable(string text, bool negativeCheck = false, int? maxNumber = null)
        {
            Console.Write(text);
            string variable = Console.ReadLine();
            int parsedVar;

            // validation

            if (!int.TryParse(variable, out parsedVar))
            {
                Console.WriteLine("Only numbers are available for input!");
                return GetNumericVariable(text, negativeCheck, maxNumber);
            }

            if (negativeCheck && parsedVar <= 0)
            {
                Console.WriteLine("The entered number cannot be less than zero and cannot be zero!");
                return GetNumericVariable(text, negativeCheck, maxNumber);
            }

            if (maxNumber != null && parsedVar > maxNumber)
            {
                Console.WriteLine("The maximum allowed number for input is {0}!", maxNumber);
                return GetNumericVariable(text, negativeCheck, maxNumber);
            }

            return parsedVar;
        }

        public static string GetStringVariable(string text)
        {
            Console.Write(text);
            string variable = Console.ReadLine();

            if (variable == null || variable.Length == 0)
            {
                Console.WriteLine("The field cannot be empty!");
                return GetStringVariable(text);
            }

            return variable;
        }
    }
}