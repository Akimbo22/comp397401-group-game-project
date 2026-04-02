using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoadSystem : PersistentSingleton<SaveLoadSystem>
{
    public GameData gameData;
    IDataService dataService;

    protected override void Awake()
    {
        base.Awake();
        dataService = new FileDataService(new JsonSerializer());
    }

    public void SaveGame()
        {
            dataService.Save(gameData);
    }

    public void LoadGame(string gameName)
    {
        try
        {
            gameData = dataService.Load(gameName);

            if (string.IsNullOrEmpty(gameData.sceneName))
            {
                gameData.sceneName = "Wave 1-1Alt";
            }

            SceneManager.LoadScene(gameData.sceneName);
        }
        catch
        {
            Debug.Log("No save found loading Level 1");
            SceneManager.LoadScene("Wave 1-1Alt");
        }
    }

    public void DeleteGame(string name)
    {
        dataService.Delete(name);
    }
     public IEnumerable<string> ListSaves()
    {
        return dataService.ListSaves();
    }
}

/*Example of how to use the JsonSerializer class: 
 * if you use false
 * 
{ data: saveGame, playerLevel:35} 
if you use true
{
    "data": {
        "playerName": "John",
        "playerLevel": 35,
        "playerHealth": 100
    }
}
it means that the JSON string will be formatted with indentation and line breaks, making it easier to read and understand. The "data" field will contain the serialized object, which in this case is a SaveGame object with properties like playerName, playerLevel, and playerHealth.
*/ 