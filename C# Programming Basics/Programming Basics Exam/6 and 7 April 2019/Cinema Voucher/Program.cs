using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Voucher
{
    class Program
    {
        static void Main(string[] args)
        {
            int vaulcherPrice = int.Parse(Console.ReadLine());
            int money = vaulcherPrice;
            int ticket = 0;
            int stock = 0;
            while (money >= 0)
            {
                string name = Console.ReadLine();
                if (name == "End")
                {
                    break;
                }
                else
                {
                    if (name.Length >= 9)
                    {
                        char one = name[0];
                        char two = name[1];
                        if (money >= one + two)
                        {
                        money -= one + two;
                        ticket++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else 
                    {
                        char one = name[0];
                        if (money >= one)
                        {
                        money -= (int)one ;
                        stock++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                   

            }
            Console.WriteLine(ticket);
            Console.WriteLine(stock);
        }
    }
}
