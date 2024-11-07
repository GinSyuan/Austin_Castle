using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class RoomBase : MonoBehaviour
{
    [SerializeField] private GameObject NorthDoorway, EastDoorway, SouthDoorway, WestDoor; // References to doorway objects on each side

    private RoomBase _north, _east, _south, _west; // Links to neighboring rooms

    // Properties to access neighboring rooms
    public RoomBase North => _north;
    public RoomBase East => _east;
    public RoomBase South => _south;
    public RoomBase West => _west;

    private Vector2 _roomPosition; // Stores the room’s position in the map
    public Vector2 RoomPosition => _roomPosition; // Public access to room’s position

    // Set the room’s location on the map
    public virtual void SetRoomLocation(Vector2 coordinates)
    {
        // Sets the position on the X and Z plane, Y is set to 0
        transform.position = new Vector3(coordinates.x, 0, coordinates.y);
        _roomPosition = coordinates; // Store the coordinates
        Console.WriteLine("Room " + _roomPosition + " Created!"); // Print room creation info
    }

    // Link the room to its neighboring rooms and update the doorways
    public void SetRooms(RoomBase roomNorth, RoomBase roomEast, RoomBase roomSouth, RoomBase roomWest)
    {
        _north = roomNorth;
        NorthDoorway.SetActive(_north == null); // Disable the north doorway if there's no north room

        _east = roomEast;
        EastDoorway.SetActive(_east == null); // Disable the east doorway if there's no east room

        _south = roomSouth;
        SouthDoorway.SetActive(_south == null); // Disable the south doorway if there's no south room

        _west = roomWest;
        WestDoor.SetActive(_west == null); // Disable the west doorway if there's no west room
    }

    // Called when the player enters the room
    public virtual void OnRoomEntered()
    {
        Debug.Log("Empty Room Entered"); // Log that the room was entered
    }

    // Called when the player searches the room (e.g., pressing a search key)
    public virtual void OnRoomSearched()
    {
        Debug.Log("Empty Room Searched"); // Log that the room was searched
    }

    // Called when the player leaves the room
    public virtual void OnRoomExited()
    {
        Debug.Log("Empty Room Exited"); // Log that the room was exited
    }
}



//public virtual RoomBase GetRoomInDirection(string direction, List<string> inventory)          // Get the room in the chosen direction, checking for obstacles
//    {
//        if (obstacles.ContainsKey(direction))
//        {
//            var obstacle = obstacles[direction];

//            string obstacleMessage = obstacle.Obstacle switch                                 // Show different messages based on the type of obstacle
//            {
//                "Ivy" => "The door is blocked by ivy. You need something to cut it.",
//                "Broke" => "The door is broken. You need something to fix it.",
//                "Locked" => "The door is locked. You need a key to unlock it.",
//                _ => $"The path is blocked by {obstacle.Obstacle}. You need something to pass."
//            };


//            if (!inventory.Contains(obstacle.RequiredItem))                                   // If player doesn't have the required item, show the obstacle message
//            {
//                Console.ForegroundColor = ConsoleColor.Red;
//                Console.WriteLine($"\n{obstacleMessage}\n");
//                Console.ResetColor();
//                return null;
//            }
//            else
//            {
//                string removeMessage = obstacle.RequiredItem switch                           // If player removed the obstacle, show message
//                {
//                    "Sword" => "You use the sword to cut the ivy.",
//                    "Wood" => "You use the wood to fix the broken door.",
//                    "Key" => "You use the key to unlock the door.",
//                    _ => $"You use the {obstacle.RequiredItem} to bypass the {obstacle.Obstacle}."
//                };
//                Console.ForegroundColor = ConsoleColor.Magenta;
//                Console.WriteLine($"\n{removeMessage}\n");
//                Console.ResetColor();
//            }
//        }

//        return direction switch                              // Return the room in the chosen direction
//        {
//            "north" => North,
//            "south" => South,
//            "east" => East,
//            "west" => West,
//            _ => null
//        };

//    }


