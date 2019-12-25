using System;

namespace Operations_Between
{
    class Program
    {
        static void Main(string[] args)
        {
            double n1 = double.Parse(Console.ReadLine());
            double n2 = double.Parse(Console.ReadLine());
            string nOperator = Console.ReadLine();
            double all = 0;
            if (nOperator == "+")
            {
                all = n1 + n2;
                if (all % 2 == 0)
                {
                    Console.Write("{0} + {1} = {2}", n1, n2, all);
                    Console.WriteLine(" - even");
                }
                else
                {
                    Console.Write("{0} + {1} = {2}", n1, n2, all);
                    Console.WriteLine(" - odd");
                }
            }
            if (nOperator == "-")
            {
                all = n1 - n2;
                if (all % 2 == 0)
                {
                    Console.Write("{0} - {1} = {2}", n1, n2, all);
                    Console.WriteLine(" - even");
                }
                else
                {
                    Console.Write("{0} - {1} = {2}", n1, n2, all);
                    Console.WriteLine(" - odd");
                }
            }
            if (nOperator == "*")
            {
                all = n1 * n2;
                if (all % 2 == 0)
                {
                    Console.Write("{0} * {1} = {2}", n1, n2, all);
                    Console.WriteLine(" - even");
                }
                else
                {
                    Console.Write("{0} * {1} = {2}", n1, n2, all);
                    Console.WriteLine(" - odd");
                }
            }
            if (nOperator == "/")
            {
                if (n2 == 0)
                {
                    Console.WriteLine("Cannot divide {0} by zero", n1);
                }
                else
                {
                    all = n1 / n2;
                    Console.WriteLine("{0} / {1} = {2:f2}", n1, n2, all);
                }
            }
            if (nOperator == "%")
            {
                if (n2 == 0)
                {
                    Console.WriteLine("Cannot divide {0} by zero", n1);
                }
                else
                {
                    all = n1 % n2;
                    Console.WriteLine("{0} % {1} = {2}", n1, n2, all);
                }
            }
        }
    }
}
