using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    private InventoryManager _inventoryManager;
    // UI slot prefab that represents an inventory slot with item image and quantity
    [SerializeField] private GameObject _slotButtonPrefab;

    // Parent container (the content object of the scroll view)
    [SerializeField] private Transform _contentParent;

    private void Start()
    {

    }
    private void OnEnable()
    {
        _inventoryManager = Object.FindAnyObjectByType<InventoryManager>();
        if (_inventoryManager != null)
        {
            Debug.Log("Inventory manager found");
        }
        else if (_inventoryManager == null)
        {
            Debug.Log("Inventory manager NOT found");
        }
        RefreshUI();
    }

    public void RefreshUI()
    {
        // Clear existing UI
        foreach (Transform child in _contentParent)
        {
            Destroy(child.gameObject);
        }

        foreach (var itemObject in _inventoryManager.inventoryItems) // Irritate these code for each items in inventory
        {
            Item item = itemObject.GetComponent<Item>(); // Item script
            if (item != null)
            {
                //string itemName = itemObject.name;

                // Instantiate a new slot UI element
                GameObject newSlot = Instantiate(_slotButtonPrefab, _contentParent);                  // Instantiate slot prefab under content parent
                Image itemImage = newSlot.transform.Find("ItemImage").GetComponent<Image>();    // item image in slot prefab
                TMP_Text itemName = newSlot.transform.Find("ItemName").GetComponent<TMP_Text>();    

                // Set the image and quantity in the slot
                itemImage.sprite = item.itemIcon;// Replace with appropriate image source from item in inventory
                itemName.text = item.itemName;
            }
        }
    }
}

