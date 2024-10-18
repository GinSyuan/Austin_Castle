using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public abstract class RoomBase
    {
        // Name of the room
        public string Name { get; private set; }

        // Dierctions to other rooms
        public RoomBase North { get; set; }
        public RoomBase South { get; set; }
        public RoomBase East { get; set; }
        public RoomBase West { get; set; }

        // Obstacless in the room and the required item to pass them
        private Dictionary<string, (string Obstacle, string RequiredItem)> obstacles = new Dictionary<string, (string, string)>();


        // Set the room name
        protected RoomBase(string name)
        {
            Name = name;
        }


        // Add an obstacle to a direction that requires an tiem to bypass
        public void AddObstacle(string direction, string obstacle, string requiredItem)
        {
            obstacles[direction] = (obstacle, requiredItem);
        }


        // When player enter a room 
        public virtual void OnRoomEntered(List<string> inventory)
        {
            Console.WriteLine($"\nYou have entered the {Name}.\n");
        }


        // When player leaves a room
        public virtual void OnRoomExit() { }

        
        // Get the availabe directions the player can move
        public string GetAvailableDirections()
        {
            List<string> directions = new List<string>();
            if (North != null) directions.Add("north");
            if (South != null) directions.Add("south");
            if (East != null) directions.Add("east");
            if (West != null) directions.Add("west");
            return $"({string.Join(", ", directions)})";
        }


        
        public virtual RoomBase GetRoomInDirection(string direction, List<string> inventory)          // Get the room in the chosen direction, checking for obstacles
        {
            if (obstacles.ContainsKey(direction))
            {
                var obstacle = obstacles[direction];

                string obstacleMessage = obstacle.Obstacle switch                                 // Show different messages based on the type of obstacle
                {
                    "Ivy" => "The door is blocked by ivy. You need something to cut it.",
                    "Broke" => "The door is broken. You need something to fix it.",
                    "Locked" => "The door is locked. You need a key to unlock it.",
                    _ => $"The path is blocked by {obstacle.Obstacle}. You need something to pass."
                };

               
                if (!inventory.Contains(obstacle.RequiredItem))                                   // If player doesn't have the required item, show the obstacle message
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n{obstacleMessage}\n");
                    Console.ResetColor();
                    return null;
                }
                else
                {
                    string removeMessage = obstacle.RequiredItem switch                           // If player removed the obstacle, show message
                    {
                        "Sword" => "You use the sword to cut the ivy.",
                        "Wood" => "You use the wood to fix the broken door.",
                        "Key" => "You use the key to unlock the door.",
                        _ => $"You use the {obstacle.RequiredItem} to bypass the {obstacle.Obstacle}."
                    };
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"\n{removeMessage}\n");
                    Console.ResetColor();
                }
            }

            return direction switch                              // Return the room in the chosen direction
            {
                "north" => North,
                "south" => South,
                "east" => East,
                "west" => West,
                _ => null
            };
            
        }
    }

