using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private UIManager UiSystem;
    [SerializeField] private InGameHud GameHud;
    [SerializeField] private GameObject controlsGuide;

    public void ButtonStartGame()
    {
        gameObject.SetActive(false);
        UiSystem.ActivateInGame();
        GameHud.OnStartGame();
        FindObjectOfType<UIManager>().ShowControlsGuide(3.0f);
    }

}
