using System;
using System.Collections.Generic;
using UnityEngine;

public class ArtRoom : RoomBase
    {
    public override void SetRoomLocation(Vector2 coordinates)
    {
        base.SetRoomLocation(coordinates);
    }

    public override void OnRoomEntered()
    {
        Debug.Log("Art Room Entered");
    }

    public override void OnRoomSearched()
    {
        Debug.Log("Art Room Searched.");
    }

    public override void OnRoomExited()
    {
        Debug.Log("Art Room Exited");
    }
}

