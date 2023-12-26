using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level05 : MonoBehaviour
{
    public Button button5;
    public Sprite enabledSprite;
    public Sprite enabledBossSprite;
    public Image bossImage;
    private void Start()
    {
        if (LevelManager.highestLevelReached >= 6)
        {
            EnableLevel05();
        }
    }
    public void LoadLevel05()
    {
        SceneManager.LoadScene("Level 05");
    }
    public void EnableLevel05()
    {
        bossImage.sprite = enabledBossSprite;
        button5.image.sprite = enabledSprite;
        button5.interactable = true;
    }
}
