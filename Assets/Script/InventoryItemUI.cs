using UnityEngine;
using UnityEngine.UI;

public class InventoryItemUI : MonoBehaviour
{
    [SerializeField] private Text itemNameText;
    [SerializeField] private Image itemIcon;

    private Item currentItem;

    public void Setup(Item item)
    {
        currentItem = item;
        itemNameText.text = item.itemName;
        itemIcon.sprite = item.itemIcon;
    }

    public void OnItemClicked()
    {
        Debug.Log("Clicked on item: " + currentItem.itemName);
        // Add functionality for what happens when you click the item.
    }
}
