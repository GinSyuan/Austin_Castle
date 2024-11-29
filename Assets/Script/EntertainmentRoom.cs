using System;
using System.Collections.Generic;
using UnityEngine;

public class EntertainmentRoom : RoomBase
    {
    public override void SetRoomLocation(Vector2 coordinates)
    {
        base.SetRoomLocation(coordinates);
    }

    public override void OnRoomEntered()
    {
        Debug.Log("Entertainment Room Entered");
    }

    public override void OnRoomSearched()
    {
        Debug.Log("Entertainment Room Searched.");
    }

    public override void OnRoomExited()
    {
        Debug.Log("Entertainment Room Exited");
    }
}

