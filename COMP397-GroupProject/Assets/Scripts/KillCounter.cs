using UnityEngine;
using UnityEngine.SceneManagement;

public class KillCounter : PersistentSingleton<KillCounter>
{
    public int deathCount = 0;
    public int requiredKills = 3;

    public void AddKill()
    {
        deathCount++;

        Debug.Log("Kills: " + deathCount + " / " + requiredKills);

        if (deathCount >= requiredKills)
        {
            WinLevel();
        }
    }

    private void WinLevel()
    {
        Debug.Log("LEVEL COMPLETE!");

        string currentScene = SceneManager.GetActiveScene().name;

        // ? OBSERVER EVENT (WAVE COMPLETE)
        if (EventChannelManager.instance != null)
        {
            if (currentScene == "Wave 1-1Alt")
                EventChannelManager.instance.onWaveCompleted?.Raise(1);

            if (currentScene == "Wave 1-2")
                EventChannelManager.instance.onWaveCompleted?.Raise(2);
        }

        string nextScene = GetNextScene();

        SaveLoadSystem.Instance.gameData = new GameData
        {
            fileName = nextScene,
            sceneName = nextScene
        };

        SaveLoadSystem.Instance.SaveGame();
        SceneManager.LoadScene(nextScene);
    }

    private string GetNextScene()
    {
        string current = SceneManager.GetActiveScene().name;

        if (current == "Wave 1-1Alt")
            return "Wave 1-2";

        if (current == "Wave 1-2")
            return "GameWinScene"; 

        return "Wave 1-1Alt";
    }

    public void ResetCounter(int killsNeeded)
    {
        deathCount = 0;
        requiredKills = killsNeeded;

        Debug.Log("Reset kills. Need: " + requiredKills);
    }
}