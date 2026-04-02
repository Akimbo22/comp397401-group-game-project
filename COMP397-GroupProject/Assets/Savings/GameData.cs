[System.Serializable]
public class GameData
{
    public string fileName;
    public string sceneName;
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