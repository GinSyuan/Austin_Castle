using System;
using System.Collections.Generic;
using UnityEngine;

public class GuestRoom : RoomBase

    {
    public override void SetRoomLocation(Vector2 coordinates)
    {
        base.SetRoomLocation(coordinates);
    }

    public override void OnRoomEntered()
    {
        Debug.Log("Guest Room Entered");
    }

    public override void OnRoomSearched()
    {
        Debug.Log("Guest Room Searched");
    }

    public override void OnRoomExited()
    {
        Debug.Log("Guest Room Exited");
    }
}

