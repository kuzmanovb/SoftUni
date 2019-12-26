using System;
using System.Collections.Generic;

namespace Activation_Keys
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] keys = Console.ReadLine().Split("&");

            var validKeys = new List<string>();

            foreach (var key in keys)
            {
                bool checkKey = true;
                var keyArray = key.ToUpper().ToCharArray();
                for (int i = 0; i < keyArray.Length; i++)
                {
                    if (char.IsDigit(keyArray[i]))
                    {
                        keyArray[i] = (char)(57 - keyArray[i] + 48);

                    }
                    if (!char.IsLetterOrDigit(keyArray[i]))
                    {
                        checkKey = false;
                        break;
                    }

                }

                string newKey = new string(keyArray);

                if (key.Length == 16 && checkKey)
                {
                    for (int i = 0; i < newKey.Length; i += 4)
                    {
                        if (i > 0)
                        {
                            newKey = newKey.Insert(i, "-");
                            i++;
                        }
                    }
                    validKeys.Add(newKey);
                }
                else if (key.Length == 25 && checkKey)
                {
                    for (int i = 0; i < newKey.Length; i += 5)
                    {
                        if (i > 0)
                        {
                            newKey = newKey.Insert(i, "-");
                            i++;
                        }
                    }
                    
                    validKeys.Add(newKey);
                }
            }

            Console.WriteLine(string.Join(", ", validKeys));
        }
    }
}
