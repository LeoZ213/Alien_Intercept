using UnityEngine;

public static class PlayerData
{
    public static void Save()
    {
        PlayerPrefs.SetInt("highestLevelReached", LevelManager.highestLevelReached);
        PlayerPrefs.Save();
    }

    public static void Load()
    {
        if (PlayerPrefs.HasKey("highestLevelReached"))
        {
            LevelManager.highestLevelReached = PlayerPrefs.GetInt("highestLevelReached");
        }
    }
}
