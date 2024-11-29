using System;
using System.Collections.Generic;
using UnityEngine;

public class SmallBackyard : RoomBase
    {
    public override void SetRoomLocation(Vector2 coordinates)
    {
        base.SetRoomLocation(coordinates);
    }

    public override void OnRoomEntered()
    {
        Debug.Log("SmallBackyard Entered");
    }

    public override void OnRoomSearched()
    {
        Debug.Log("SmallBackyard Searched.");
    }

    public override void OnRoomExited()
    {
        Debug.Log("SmallBackyard Exited");
    }
}

