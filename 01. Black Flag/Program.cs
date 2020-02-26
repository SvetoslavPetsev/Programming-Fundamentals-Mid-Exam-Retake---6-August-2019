using System;

namespace _01._Black_Flag
{
    class Program
    {
        static void Main()
        {
            int days = int.Parse(Console.ReadLine());
            int plunder = int.Parse(Console.ReadLine());
            double expectedPlunder = double.Parse(Console.ReadLine());

            double allDayesPlunder = 0;

            for (int i = 1; i <= days; i++)
            {
                double dayPlunder = plunder;
                if (i % 3 == 0)
                {
                    dayPlunder *= 1.5;
                }
                allDayesPlunder += dayPlunder;
                if (i % 5 == 0)
                {
                    allDayesPlunder *= 0.7;
                }
            }
            if (allDayesPlunder >= expectedPlunder)
            {
                Console.WriteLine($"Ahoy! {allDayesPlunder:F2} plunder gained.");
            }
            else
            {
                double percentage = allDayesPlunder / expectedPlunder * 100;
                Console.WriteLine($"Collected only {percentage:F2}% of the plunder.");
            }
        }
    }
}
