using System.Collections.Generic;

public interface IDataService
{
    void Save(GameData data, bool overwrite = true); //This method will save the provided GameData object. The overwrite parameter indicates whether to overwrite existing data or not. If overwrite is true, it will replace any existing data with the new data. If overwrite is false, it may append the new data or handle it in a way that does not overwrite existing data.
    GameData Load(string name); //Name represents the name of a save file
    void Delete(string name);
    IEnumerable<string> ListSaves();
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