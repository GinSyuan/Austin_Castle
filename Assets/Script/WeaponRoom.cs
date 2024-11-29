using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRoom : RoomBase
{
    [SerializeField] private Item roomItem;
    [SerializeField] private GameObject armorFoundText;
    public override void SetRoomLocation(Vector2 coordinates)
    {
        base.SetRoomLocation(coordinates);
    }

    public override void OnRoomEntered()
    {
        Debug.Log("Weapon Room Entered");
    }

    public override void OnRoomSearched()
    {
        Debug.Log("Armor found!");
        roomItem.gameObject.SetActive(false);
        FindObjectOfType<InventoryManager>().AddItem(roomItem);

        FindObjectOfType<UIManager>().ShowArmorFoundText(2.0f);

    }

    public override void OnRoomExited()
    {
        Debug.Log("Weapon Room Exited");
    }
}

