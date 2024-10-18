using System;
using System.Collections.Generic;

public class WeaponRoom : RoomBase
    {
        public WeaponRoom() : base("Weapon Room") { }

        public override void OnRoomEntered(List<string> inventory)
        {
            base.OnRoomEntered(inventory);
            if (!inventory.Contains("Sword"))      // If the player hasn't picked up the sword yet
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("   You found a sword.\n");
                Console.ResetColor();
                inventory.Add("Sword");
            }
            else                                   // If the player already had sword
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("   You have already collected the sword here.\n");
                Console.ResetColor();
            }
        }
    }

