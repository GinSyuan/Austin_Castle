using System;
using System.Collections.Generic;

public class StorageRoom : RoomBase
    {
        public StorageRoom() : base("Storage Room") { }

        public override void OnRoomEntered(List<string> inventory)      // When the player enters the storage room
        {
            base.OnRoomEntered(inventory);
            if (!inventory.Contains("Ax"))                              // If the player hasn't collected the ax yet, they find it here
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("   You found an ax.\n");
                Console.ResetColor();
                inventory.Add("Ax");
            }
            else                                                        // If player alredy has the ax, there is nothing eles here
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("   There’s nothing more of use here.\n");
                Console.ResetColor();
            }
        }
    }

