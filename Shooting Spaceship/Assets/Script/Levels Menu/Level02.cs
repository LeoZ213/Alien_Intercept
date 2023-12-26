
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level02 : MonoBehaviour
{
    public Button button2;
    public Sprite enabledSprite;

    private void Start()
    {
        if(LevelManager.highestLevelReached >= 3)
        {
            EnableLevel02();
        }
    }
    public void LoadLevel02()
    {
        if (button2.interactable)
        {
            SceneManager.LoadScene("Level 02");
        }
    }
    public void EnableLevel02()
    {
        button2.interactable = true;
        button2.image.sprite = enabledSprite;
    }
}
