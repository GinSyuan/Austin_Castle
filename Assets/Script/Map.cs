using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] private RoomBase[] RoomPrefabs; // Array of different room templates we can use
    [SerializeField] private float RoomSize = 1; // Size of each room in the grid

    private const int MapSize = 3; // Sets the grid size (3x3 in this case)
    readonly Dictionary<Vector2, RoomBase> _rooms = new(); // Stores each room’s location in the map
    public Dictionary<Vector2, RoomBase> Rooms => _rooms; // Public access to the rooms map

    public void CreateMap()
    {
        int i = 0; // Index to cycle through room prefabs

        // Loop through a grid and place rooms
        for (int x = 0; x < MapSize; x++)
        {
            for (int z = 0; z < MapSize; z++)
            {
                Vector2 coords = new Vector2(x * RoomSize, z * RoomSize); // Position for this room

                // Create a room from the prefab at these coordinates
                var roomInstance = Instantiate(RoomPrefabs[i], transform);
                i++; // Move to the next prefab
                roomInstance.SetRoomLocation(coords); // Set the room’s position in the game

                // Add the room to the dictionary with its coordinates
                _rooms.Add(coords, roomInstance);
            }
        }

        // Link the rooms to their neighbors
        foreach (var roomByCoordinate in _rooms)
        {
            RoomBase northRoom = FindRoom(roomByCoordinate.Key, Direction.North); // Find the room above
            RoomBase eastRoom = FindRoom(roomByCoordinate.Key, Direction.East); // Find the room to the right
            RoomBase southRoom = FindRoom(roomByCoordinate.Key, Direction.South); // Find the room below
            RoomBase westRoom = FindRoom(roomByCoordinate.Key, Direction.West); // Find the room to the left

            // Set the neighboring rooms for this room
            roomByCoordinate.Value.SetRooms(northRoom, eastRoom, southRoom, westRoom);
        }
    }

    private RoomBase FindRoom(Vector2 currentRoom, Direction direction)
    {
        RoomBase room = null;
        Vector2 nextRoomCoordinates = new Vector2(-1, -1); // Default to an invalid position

        // Calculate the coordinates for the neighboring room based on the direction
        switch (direction)
        {
            case Direction.North:
                nextRoomCoordinates = currentRoom + (Vector2.up * RoomSize); // Room above
                break;
            case Direction.East:
                nextRoomCoordinates = currentRoom + (Vector2.right * RoomSize); // Room to the right
                break;
            case Direction.South:
                nextRoomCoordinates = currentRoom + (Vector2.down * RoomSize); // Room below
                break;
            case Direction.West:
                nextRoomCoordinates = currentRoom + (Vector2.left * RoomSize); // Room to the left
                break;
        }

        // Check if the calculated coordinates exist in the dictionary of rooms
        if (_rooms.TryGetValue(nextRoomCoordinates, out var nextRoom))
        {
            room = nextRoom; // Set the room if it exists
        }

        return room; // Return the found room, or null if it doesn't exist
    }
}
