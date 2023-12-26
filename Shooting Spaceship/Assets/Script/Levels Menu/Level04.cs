using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level04 : MonoBehaviour
{
    public Button button4;
    public Sprite enabledSprite;

    private void Start()
    {
        if (LevelManager.highestLevelReached >= 5)
        {
            EnableLevel04();
        }
    }
    public void LoadLevel04()
    {
        SceneManager.LoadScene("Level 04");
    }

    public void EnableLevel04()
    {
        button4.interactable = true;
        button4.image.sprite = enabledSprite;
    }
}
