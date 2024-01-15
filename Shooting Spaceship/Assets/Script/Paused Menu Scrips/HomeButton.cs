using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeButton : MonoBehaviour
{
    [SerializeField] private GamePausedWindow gamePausedWindow;
    public void OpenGamePausedPanel()
    {
        gamePausedWindow.gameObject.SetActive(true);
        gamePausedWindow.continueButton.onClick.AddListener(continueButtonClicked);
        gamePausedWindow.menuButton.onClick.AddListener(menuButtonClicked);
        Time.timeScale = 0;
    }
    private void continueButtonClicked()
    {
        gamePausedWindow.gameObject.SetActive(false);
        Time.timeScale = 1; //Unpauses the game
    }
    private void menuButtonClicked()
    {
        SceneManager.LoadScene(0); //Sets the scene back to the main menu
        Time.timeScale = 1; //Unpauses the game
    }


}
