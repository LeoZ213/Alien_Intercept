using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level03 : MonoBehaviour
{
    public Button button3;
    public Sprite enabledSprite;

    private void Start()
    {
        if (LevelManager.highestLevelReached >= 4)
        {
            EnableLevel03();
        }
    }
    public void LoadLevel03()
    {
        SceneManager.LoadScene("Level 03");
    }
    public void EnableLevel03()
    {
        button3.interactable = true;
        button3.image.sprite = enabledSprite;
    }
}
