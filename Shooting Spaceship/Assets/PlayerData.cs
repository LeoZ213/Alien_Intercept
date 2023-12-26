using UnityEngine;

public static class PlayerData
{
    static void Save()
    {
        PlayerPrefs.SetInt("highestLevelReached", LevelManager.highestLevelReached);
    }

    public static void Load()
    {
        if (PlayerPrefs.HasKey("highestLevelReached"))
        {
            LevelManager.highestLevelReached = PlayerPrefs.GetInt("highestLevelReached");
        }
    }
}
