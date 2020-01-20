using System;

namespace Password_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            bool passwordLenght = ValidatorLength(password);
            bool charOnly = ValidatorChar(password);
            bool lastDigits = ValidatorLastDigits(password);

            if (passwordLenght && charOnly && lastDigits)
            {
                Console.WriteLine("Password is valid");
            }
            else
            {
                if (!charOnly)
                {
                    Console.WriteLine("Password must consist only of letters and digits");
                }
                if (!passwordLenght)
                {
                    Console.WriteLine("Password must be between 6 and 10 characters");
                }
                if (!lastDigits)
                {
                    Console.WriteLine("Password must have at least 2 digits");
                }
            }
        }

        static bool ValidatorLength(string password)
        {
            bool passwordLenght = false;

            if (password.Length >= 6 && password.Length <= 10)
            {
                passwordLenght = true;
            }
            
            return passwordLenght;
        }

        static bool ValidatorChar(string password)
        {

            bool charOnly = true;


            foreach (var item in password)
            {

                if (!char.IsLetterOrDigit (item))
                {
                    charOnly = false;
                    break;
                }
               
            }
           
            return charOnly;
        }

        static bool ValidatorLastDigits(string password)
        {

            bool lastDigits = false;

            int counter = 0;

            foreach (var item in password)
            {
                if (char.IsDigit(item))
                {
                    counter++;
                }
            }

            if (counter >= 2)
            {
                lastDigits = true;
            }
            return lastDigits;
        }
    }
}

