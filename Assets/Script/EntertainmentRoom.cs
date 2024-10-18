using System;
using System.Collections.Generic;

public class EntertainmentRoom : RoomBase
    {
        public EntertainmentRoom() : base("Entertainment Room") { }

        public override void OnRoomEntered(List<string> inventory)     // If the player enters the entertainment room
        {
            base.OnRoomEntered(inventory);
            if (!inventory.Contains("Dice"))                           // If the player hasn't collected the dice yet, they find it here
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("   You found a dice.\n");
                Console.ResetColor();
                inventory.Add("Dice");
            }
            else                                                       // If player already has the dice, there's nothing else here
            {
                Console.WriteLine("   There’s nothing more of use here.\n");
            }
        }
    }

