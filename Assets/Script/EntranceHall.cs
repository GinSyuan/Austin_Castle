using System;
using System.Collections.Generic;
// Derived classes for specific rooms
public class EntranceHall : RoomBase
    {
        public EntranceHall() : base("Entrance Hall") { }

        public override void OnRoomEntered(List<string> inventory)
        {
            base.OnRoomEntered(inventory);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   It's the grand entrance to the castle.\n");
            Console.ResetColor();
        }
    }

