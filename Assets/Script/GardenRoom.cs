using System;
using System.Collections.Generic;
using Jing_Lab3;

public class GardenRoom : RoomBase
    {
        public GardenRoom() : base("Garden") { }

        public override void OnRoomEntered(List<string> inventory)
        {
            base.OnRoomEntered(inventory);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   A lush garden filled with beautiful plants. A fairy appears.\n");
            Console.ResetColor();

            if (!inventory.Contains("Dice"))                 // If player doesn't have the dice yet, thet can't play with the fairy
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("   The fairy says, 'If you have a dice, we can play a game. If you win, I will give you a mysterious item.'\n");
                Console.ResetColor();
            }
            else if (inventory.Contains("Dice") && !inventory.Contains("Carrot"))     // If player had dice, the dice game will start
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("   The fairy says, 'Let's play!\n'");
                Console.ResetColor();
                DiceGame gameManager = new DiceGame();  
                gameManager.gameStart();

                if (gameManager.playerTotalScore > gameManager.computerTotalScore)    // If player wins the dice game, thet get a carrot
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("   You won! The fairy gives you an Carrot.\n");
                    Console.ResetColor();
                    inventory.Add("Carrot");
                    
                }
                else                                                                  // If player lose the game
                {
                    Console.ForegroundColor = ConsoleColor.Blue;                              
                    Console.WriteLine("   You lost the game. The fairy disappears.\n");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;                          // If player alredy had key
                Console.WriteLine("   The fairy says, 'You already have my gift. Go on your way.'\n");
                Console.ResetColor();
            }
        }
    }

