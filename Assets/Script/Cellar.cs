using System;
using System.Collections.Generic;

public class Cellar : RoomBase
    {
        public Cellar() : base("Cellar") { }

        public override void OnRoomEntered(List<string> inventory)    // When the player enters the cellar
        {
            base.OnRoomEntered(inventory);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nYou have found a treasure! Congratulations!\n");
            Console.ResetColor();

            
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("You have reached the end of your adventure.\nThank you for playing!");     // End the game
            Console.ResetColor();
            Environment.Exit(0); // Exit the application
        }
    }

