using System;
using System.Collections.Generic;
using System.Linq;

namespace Balanced_Parentheses
{
    class Program
    {
        static void Main(string[] args)
        {

            var inputParenthesis = Console.ReadLine().ToCharArray();

            var stackParenthesis = new Stack<char>();
            bool check = true;

            foreach (var bracket in inputParenthesis)
            {
                if (bracket == '(' || bracket == '{' || bracket == '[')
                {
                    stackParenthesis.Push(bracket);
                }
                else if (stackParenthesis.Any())
                {

                    if (bracket == ')' && stackParenthesis.Peek() == '(')
                    {
                        stackParenthesis.Pop();
                    }
                    else if (bracket == '}' && stackParenthesis.Peek() == '{')
                    {
                        stackParenthesis.Pop();
                    }
                    else if (bracket == ']' && stackParenthesis.Peek() == '[')
                    {
                        stackParenthesis.Pop();
                    }
                    else
                    {
                        check = false;
                        break;
                    }
                }
                else
                {
                    check = false;
                    break;
                }
            }

            if (check)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
