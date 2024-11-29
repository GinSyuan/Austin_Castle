using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject[] Layouts;
    [SerializeField] private InGameHud gameHud;

    [SerializeField] private GameObject popUpText; // Reference to your pop-up text prefab or object
    [SerializeField] private GameObject controlsGuide;
    [SerializeField] private GameObject armorFoundText;
    [SerializeField] private GameObject treasureChestFoundText;


    public void ShowTreasureChestFoundText(float duration)
    {
        if (treasureChestFoundText != null)
        {
            treasureChestFoundText.SetActive(true); // Show the pop-up text
            StartCoroutine(HideTreasureChestFoundText(duration)); // Automatically hide after a delay
        }
    }

    private IEnumerator HideTreasureChestFoundText(float delay)
    {
        yield return new WaitForSeconds(delay);
        treasureChestFoundText.SetActive(false); // Hide the pop-up text
    }

    public void ShowArmorFoundText(float duration)
    {
        if (armorFoundText != null)
        {
            armorFoundText.SetActive(true); // Show the pop-up text
            StartCoroutine(HideArmorFoundText(duration)); // Automatically hide after a delay
        }
    }

    private IEnumerator HideArmorFoundText(float delay)
    {
        yield return new WaitForSeconds(delay);
        armorFoundText.SetActive(false); // Hide the pop-up text
    }

    public void ShowControlsGuide(float duration)
    {
        if (controlsGuide != null)
        {
            controlsGuide.SetActive(true); // Show the pop-up text
            StartCoroutine(HideControlsGuide(duration)); // Automatically hide after a delay
        }
    }

    private IEnumerator HideControlsGuide(float delay)
    {
        yield return new WaitForSeconds(delay);
        controlsGuide.SetActive(false); // Hide the pop-up text
    }


    public void ShowPopUpText(float duration)
    {
        if (popUpText != null)
        {
            popUpText.SetActive(true); // Show the pop-up text
            StartCoroutine(HidePopUpAfterDelay(duration)); // Automatically hide after a delay
        }
    }

    private IEnumerator HidePopUpAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        popUpText.SetActive(false); // Hide the pop-up text
    }

    private bool isPaused = false;

    private enum MenuLayouts 
    {
        Main = 0,
        InGame = 1,
        Pause = 2,
   
    }
    private void Update()
    {
        // Check for the Escape key press to toggle the pause menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            { 
                Layouts[2].GetComponent<PauseMenu>().ResumeGame();
                isPaused = false;
            }
            else
            {
                isPaused = true;
                gameHud.OnPauseGame();
                Layouts[2].GetComponent<PauseMenu>().PauseGame();

            }
            Layouts[2].SetActive(isPaused);
        }
    }
    private void Start()
    {
        OpenMainMenu();
    }

    private void SetLayout(MenuLayouts layouts) 
    {
        for (int i = 0; i < Layouts.Length; i++) 
        {
            Layouts[i].SetActive((int)layouts == i);
        }
        
    }

    public void OpenMainMenu() 
    {
        SetLayout(MenuLayouts.Main);
    }

    public void ActivateInGame() 
    {
        SetLayout(MenuLayouts.InGame);
    }

    public void ShowPausegameMenu() 
    {
        SetLayout(MenuLayouts.Pause);
    }
  

}
