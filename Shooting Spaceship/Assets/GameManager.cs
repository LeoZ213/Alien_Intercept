
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool hasGameEnded = false;
    float restartDelay = 1f;

    //Continously checks if the player kills all the Enemies and switches the scene to the Levels Menu
    private void Update()
    {
        int numberOfEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (numberOfEnemies <= 0)
        {
            Invoke(nameof(ToLevels), 1.0f);
        }
    }

    //Used to call various methods when the game ends and changes hasGameEnded to true
    public void EndGame()
    {
        if (hasGameEnded == false)
        {
            hasGameEnded = true;
            Debug.Log("GAME OVER");
            Invoke(nameof(Restart), restartDelay);
        }
    }

    //Restarts the Scene
    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //Loads the Levels Menu
    private void ToLevels()
    {
        SceneManager.LoadScene(1);
    }
}
