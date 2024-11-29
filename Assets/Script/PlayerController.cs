using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private RoomBase _currentRoom = null; // Keeps track of the current room the player is in

    public void Setup()
    {
        // Initial setup for the player, no code needed here for now
    }

    private void Update()
    {
        // Check if the space bar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // If we're in a room, "search" it (do something related to the room)
            if (_currentRoom != null)
            {
                _currentRoom.OnRoomSearched();
            }
        }
    }

    private void OnTriggerEnter(Collider otherObject)
    {
        // Safely get the RoomBase component
        RoomBase room = otherObject.GetComponent<RoomBase>();
        if (room != null) // Check if the component exists
        {
            _currentRoom = room;
            _currentRoom.OnRoomEntered();
        }
    }

    private void OnTriggerExit(Collider otherObject)
    {
        // Safely get the RoomBase component
        RoomBase room = otherObject.GetComponent<RoomBase>();
        if (room != null) // Check if the component exists
        {
            room.OnRoomExited();
        }
    }
}
