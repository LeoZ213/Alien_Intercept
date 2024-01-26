using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    Slider slider;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("Volume val")) 
        {
            slider.value = PlayerPrefs.GetFloat("Volume val");
        }
    }
    public void PlayGame()
    {
        PlayerData.Load();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        PlayerPrefs.SetFloat("Volume val", slider.value);
    }
    public void QuitGame()
    {
        PlayerData.Save();
        Application.Quit();
        Debug.Log("Quit");
    }
}
