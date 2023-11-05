
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool hasGameEnded = false;
    float restartDelay = 1f;

    private void Update()
    {
        int numberOfEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (numberOfEnemies <= 0)
        {
            Invoke("nextLevel", 1.0f);
        }
    }
    public void EndGame()
    {
        if (hasGameEnded == false)
        {
            hasGameEnded = true;
            Debug.Log("GAME OVER");
            Invoke("Restart", restartDelay);
        }
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void nextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
