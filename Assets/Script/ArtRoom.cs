using System;
using System.Collections.Generic;

public class ArtRoom : RoomBase
    {
        public ArtRoom() : base("Art Room") { }

        public override void OnRoomEntered(List<string> inventory)     // When the player enters the art room
        {
            base.OnRoomEntered(inventory);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   A room filled with paintings. You see a bunny here.\n");
            Console.ResetColor();

            if (!inventory.Contains("Carrot"))                                     // If player doesn't have a carrot, the bunny just hops away
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("   The bunny sniffs you and hops away.\n");
                Console.ResetColor();
            }
            else if (inventory.Contains("Carrot") && !inventory.Contains("Key"))   // If the player has a carrot but doesn't have the key, the bunny gives them a key
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("   The bunny eats your Carrot and gives you a key.\n");
                Console.ResetColor();
                inventory.Remove("Carrot");
                inventory.Add("Key");
            }
            else                                                                   // If the player already has the key, the bunny has nothing more to give
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("   The bunny looks happy and has nothing more to give (only the poop).\n");
                Console.ResetColor();
            }
        }
    }

