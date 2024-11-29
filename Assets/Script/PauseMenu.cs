using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private InGameHud gameHud; // Reference to the Pause Menu UI
    [SerializeField] private UIManager uiManager;
    [SerializeField] private GameObject inventoryPanel;


    private bool isPaused = false; // To track the pause state

    
    private void Update()
    {
        // Toggle pause state with Esc key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    //private void OnEnable()
    //{
    //    foreach (ItemData item in _fakeInventoryForTesting)
    //    {
    //        var inventoryItem = Instantiate(ItemExamplePrefab, InventoryContentParent);
    //        inventoryItem.Setup(item);
    //        _inventoryItemInstances.Add(inventoryItem);
    //    }
    //}

    //private void OnDisable()
    //{
    //    foreach (InventoryItem item in _inventoryItemInstances)
    //    {
    //        Destroy(item.gameObject);
    //    }

    //    _inventoryItemInstances.Clear();
    //}

    public void ButtonBag()
    {
        
        // Toggle the inventory panel
        if (inventoryPanel.activeSelf)
        {
            Debug.Log("Closing Inventory");
            inventoryPanel.SetActive(false);
        }
        else
        {
            Debug.Log("Opening Inventory");
            inventoryPanel.SetActive(true);

            // Optional: Update inventory UI when opening the inventory
            // If you have an inventory manager, you can refresh the UI here.
            // Example: inventoryManager.RefreshUI();
        }
    }

    public void ButtonContinue()
    {
        gameHud.OffPauseGame();
        ResumeGame();
        uiManager.ActivateInGame();
    }

    public void ButtonQuit()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }

    public void PauseGame()
    {
        Time.timeScale = 0f; // Freeze the game time
        isPaused = true; // Set the pause state

        // Unlock and show the cursor for UI interaction
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; // Resume the game time
        isPaused = false; // Reset the pause state

        // Lock and hide the cursor for gameplay
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
