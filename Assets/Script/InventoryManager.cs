using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<Item> inventoryItems = new List<Item>();
    public InventoryUI inventoryUI;

    private void Awake()
    {
        inventoryUI = FindObjectOfType<InventoryUI>(true);
    }
    public void AddItem(Item newItem)
    {
        inventoryItems.Add(newItem);
       // inventoryUI.RefreshUI(inventoryItems);
        Debug.Log($"Item added: {newItem.itemName}");

        foreach (Item item in inventoryItems)
        {
            Debug.Log(item);
        }
    }

    public void RemoveItem(Item itemToRemove)
    {
        //if (inventoryItems.Contains(itemToRemove))
        //{
        //    inventoryItems.Remove(itemToRemove);
        //    inventoryUI.RefreshUI(inventoryItems);
        //    Debug.Log("Item removed: " + itemToRemove.itemName);
        //}
    }
}
