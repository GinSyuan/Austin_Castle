using System;
using System.Collections.Generic;
using UnityEngine;

public class Cellar : RoomBase
{
    [SerializeField] private GameObject treasureChest;
    [SerializeField] private GameObject treasureChestLid;
    [SerializeField] private GameObject treasureChestFoundText;

    public override void SetRoomLocation(Vector2 coordinates)
    {
        base.SetRoomLocation(coordinates);
    }

    public override void OnRoomEntered()
    {
        Debug.Log("Cellar Room Entered");
    }

    public override void OnRoomSearched()
    {
        Debug.Log("Treasure Chest Found!");

        treasureChestLid.transform.Rotate(-90,0,0);

        FindObjectOfType<UIManager>().ShowTreasureChestFoundText(3.0f);
    }

    public override void OnRoomExited()
    {
        Debug.Log("Cellar Room Exited");
    }
}

