using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Man_O_War
{
    class Program
    {
        static void Main()
        {
            List<int> pirateShipSections = Console.ReadLine().Split(">").Select(int.Parse).ToList();
            List<int> warShipSections = Console.ReadLine().Split(">").Select(int.Parse).ToList();
            int maxHealthForSection = int.Parse(Console.ReadLine());

            bool pirateShipIsDistroyed = false;
            bool warShipIsDistroyed = false;

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Retire")
                {
                    break;
                }
                string[] command = input.Split().ToArray();
                if (command[0] == "Fire")
                {
                    int index = int.Parse(command[1]);
                    int damage = int.Parse(command[2]);
                    if (index >= 0 && index < warShipSections.Count)
                    {
                        warShipSections[index] -= damage;
                        if (warShipSections[index] <= 0)
                        {
                            warShipIsDistroyed = true;
                            break;
                        }
                    }
                }
                else if (command[0] == "Defend")
                {
                    int startIndex = int.Parse(command[1]);
                    int endIndex = int.Parse(command[2]);
                    int damage = int.Parse(command[3]);
                    if (startIndex >= 0 && endIndex < pirateShipSections.Count)
                    {
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            pirateShipSections[i] -= damage;
                            if (pirateShipSections[i] <= 0)
                            {
                                pirateShipIsDistroyed = true;
                                break;
                            }
                        }
                    }
                }
                else if (command[0] == "Repair")
                {
                    int index = int.Parse(command[1]);
                    int health = int.Parse(command[2]);
                    if (index >= 0 && index < pirateShipSections.Count)
                    {
                        pirateShipSections[index] += health;

                        if (pirateShipSections[index] > maxHealthForSection)
                        {
                            pirateShipSections[index] = maxHealthForSection;
                        }
                    }
                }
                else if (command[0] == "Status")
                {
                    int countSectionForRepair = 0;
                    int minHealth = maxHealthForSection / 5;
                    for (int j = 0; j < pirateShipSections.Count; j++)
                    {
                        int currSection = pirateShipSections[j];
                        if (currSection < minHealth)
                        {
                            countSectionForRepair++;
                        }
                    }
                    Console.WriteLine($"{countSectionForRepair} sections need repair.");
                }
            }
            if (warShipIsDistroyed)
            {
                Console.WriteLine("You won! The enemy ship has sunken.");
            }
            else if (pirateShipIsDistroyed)
            {
                Console.WriteLine("You lost! The pirate ship has sunken.");
            }
            else
            {
                Console.WriteLine($"Pirate ship status: {pirateShipSections.Sum()}");
                Console.WriteLine($"Warship status: {warShipSections.Sum()}");
            }
        }
    }
}
