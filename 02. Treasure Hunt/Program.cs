using System;
using System.Linq;
using System.Collections.Generic;

namespace _02._Treasure_Hunt
{
    class Program
    {
        static void Main()
        {
            List<string> treasureChest = Console.ReadLine().Split("|").ToList();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Yohoho!")
                {
                    break;
                }
                string[] command = input.Split().ToArray();
                if (command[0] == "Loot")
                {
                    for (int i = 1; i < command.Length; i++)
                    {
                        string currTreasure = command[i];
                        if (!treasureChest.Contains(currTreasure))
                        {
                            treasureChest.Insert(0, currTreasure);
                        }
                    }
                }
                else if (command[0] == "Drop")
                {
                    int index = int.Parse(command[1]);
                    if (index >= 0 && index < treasureChest.Count)
                    {
                        string currTreasure = treasureChest[index];
                        treasureChest.RemoveAt(index);
                        treasureChest.Add(currTreasure);
                    }
                }
                else if (command[0] == "Steal")
                {
                    List<string> stolenItems = new List<string>();
                    int count = int.Parse(command[1]);
                    if (count > treasureChest.Count)
                    {
                        count = treasureChest.Count;
                    }
                    int startIndex = treasureChest.Count - count;
                    int endIndex = startIndex + count;
                    for (int i = startIndex; i < endIndex; i++)
                    {
                        stolenItems.Add(treasureChest[i]);
                    }
                    treasureChest.RemoveRange(startIndex, count);
                    Console.WriteLine(string.Join(", ", stolenItems));
                }
            }
            if (treasureChest.Count > 0)
            {
                double treasureGain = 0;
                for (int i = 0; i < treasureChest.Count; i++)
                {
                    string currTreasure = treasureChest[i];
                    treasureGain += currTreasure.Length;
                }
                treasureGain /= treasureChest.Count;
                Console.WriteLine($"Average treasure gain: {treasureGain:F2} pirate credits.");
            }
            else
            {
                Console.WriteLine("Failed treasure hunt.");
            }
        }
    }
}
