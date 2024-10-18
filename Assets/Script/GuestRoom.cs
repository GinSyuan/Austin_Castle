using System;
using System.Collections.Generic;

public class GuestRoom : RoomBase
    {
        public GuestRoom() : base("Guest Room") { }

        public override void OnRoomEntered(List<string> inventory)
        {
            base.OnRoomEntered(inventory);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   A cozy room with old furniture.\n");
            Console.ResetColor();
        }
    }

