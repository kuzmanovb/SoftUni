using System;

namespace Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double saberPrice = double.Parse(Console.ReadLine());
            double robePrice = double.Parse(Console.ReadLine());
            double beltPrice = double.Parse(Console.ReadLine());

            double studentPlusTen = Math.Ceiling(students * 1.1);
            double moneyForSaber = saberPrice * studentPlusTen;
            double moneyForRobe = robePrice * students;
            double moneyForBelt = beltPrice * students;

            double discountForBelt = Math.Floor(students / 6.0) * beltPrice;

            double allPrice = moneyForSaber + moneyForRobe + (moneyForBelt - discountForBelt);

            if (money >= allPrice)
            {
                Console.WriteLine($"The money is enough - it would cost {allPrice:f2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {allPrice - money:f2}lv more.");
            }
        }
    }
}
