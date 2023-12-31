using UnityEngine.SceneManagement;

public static class LevelManager 
{
    public static int highestLevelReached = 1;

    public static void UnlockNextLevel()
    {
        if (highestLevelReached < 6)
        {
            highestLevelReached = SceneManager.GetActiveScene().buildIndex + 1;
        }
    }

    public static int GetHighestLevelReached()
    {
        return highestLevelReached;
    }
}
