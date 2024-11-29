using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName; // The name of the item
    public Sprite itemIcon; // The icon to display in the inventory
    public ItemType itemType; // Optional: Differentiate between item types (e.g., weapon, potion)

    public enum ItemType
    {
        Weapon,
        Consumable,
        QuestItem
    }
}
