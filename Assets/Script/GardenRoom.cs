
using UnityEngine;
using System.Collections;

public class GardenRoom : RoomBase
{

    [SerializeField] private Item roomItem;
    [SerializeField] private GameObject popUpText;
    public override void SetRoomLocation(Vector2 coordinates)
    {
        base.SetRoomLocation(coordinates);
    }

    
    public override void OnRoomEntered()
    {
        Debug.Log("Garden Room Entered");
    }

    public override void OnRoomSearched()
    {
        Debug.Log("Garden Room Searched. Green Potion Bottle!");
        roomItem.gameObject.SetActive(false);
        FindObjectOfType<InventoryManager>().AddItem(roomItem);
        
        FindObjectOfType<UIManager>().ShowPopUpText(2.0f);
    }

    private IEnumerator HidePopUpAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        popUpText.SetActive(false); // Hide the pop-up text
    }
    public override void OnRoomExited()
    {
        Debug.Log("Garden Room Exited");
    }
}

