using System;
using System.Collections.Generic;

public class SmallBackyard : RoomBase
    {
        public SmallBackyard() : base("Small Backyard") { }

        public override void OnRoomEntered(List<string> inventory)
        {
            base.OnRoomEntered(inventory);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   A quiet place behind the castle with an ancient tree.\n");
            Console.ResetColor();

            if (inventory.Contains("Ax") && !inventory.Contains("Wood"))        // If the player has an ax but hasn't collected wood yet, they can chop the tree
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("   You use the ax to cut the tree and collect some wood.\n");
                Console.ResetColor();
                inventory.Add("Wood");
            }
            else if (!inventory.Contains("Ax"))                                 // If thet don't have ax
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("   The tree seems sturdy. You need somthing to chop it.\n");
                Console.ResetColor();
            }
        }
    }

