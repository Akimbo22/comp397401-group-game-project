using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileDataService : IDataService
{
    private ISerializer serializer;
    private string dataPath; //Where the save file is located
    private string fileExtension; //We can define a custom file extension for our save files, such as ".save" or ".json". This helps to identify and manage the save files more easily.

    public FileDataService(ISerializer serializer)
    {
        this.serializer = serializer;
        dataPath = Application.persistentDataPath; //C:\Users\Username\AppData\LocalLow\CompanyName\GameName
        fileExtension = ".json"; //We can define a custom file extension for our save files, such as ".save" or ".json". This helps to identify and manage the save files more easily.
    }

    //GetPathFile - To combine the dataPath, FileName and FileExtension 
    private string GetPathFile(string fileName)
    {
        //C:\Users\Username\AppData\LocalLow\CompanyName\GameName\fileName.json
        return Path.Combine(dataPath, string.Concat(fileName, fileExtension));
    }

    //Save
    public void Save(GameData data, bool overwrite = true)
    {
        string fileLocation = GetPathFile(data.fileName);
        if(!overwrite && File.Exists(fileLocation)) //I can't overwrite the file if it already exists, so I will check if the file exists and if overwrite is false. If both conditions are true, I will log a warning message and skip the save operation.
        {
            throw new IOException("The file already exists and can't be overwritten");
        }
        File.WriteAllText(fileLocation, serializer.Serialize(data)); //This will write the serialized data to the specified file location. The WriteAllText method creates a new file, writes the specified string to the file, and then closes the file. If the file already exists, it will be overwritten.
    }

    //Load

    public GameData Load(string name)
    {
        string fileLocation = GetPathFile(name);
        if (!File.Exists(fileLocation)) //I will check if the file exists before trying to load it. If the file does not exist, I will log a warning message and return null or a default value.
        {
            throw new System.Exception("No persistent file found at " + fileLocation);
        }
       File.ReadAllText(fileLocation); //This will read the contents of the specified file and return it as a string. The ReadAllText method opens the file, reads all the text in the file, and then closes the file.
        return serializer.Deserialize<GameData>(File.ReadAllText(fileLocation)); //This will deserialize the JSON string back into a GameData object. The Deserialize method takes the JSON string as input and converts it into an instance of the specified type (in this case, GameData), populating its properties with the data from the JSON.
    }

    //Delete
    public void Delete(string name)
    {
        string fileLocation = GetPathFile(name);
        if (!File.Exists(fileLocation)) //I will check if the file exists before trying to delete it. If the file does not exist, I will log a warning message and return without performing any deletion.
        {
            throw new System.Exception("No persistent file found at " + fileLocation);
        }
        File.Delete(fileLocation); //This will delete the specified file from the file system. The Delete method takes the file path as input and removes the file from the disk.
    }

    //ListAllSaves
    public IEnumerable<string> ListSaves()
    {
      foreach ( string path in Directory.EnumerateFiles(dataPath))
        { if(Path.GetExtension(path) == fileExtension)
            {
                yield return Path.GetFileNameWithoutExtension(path); //This will return the file name without the extension for each file that matches the specified file extension. The GetFileNameWithoutExtension method takes a file path as input and returns the file name without the extension, allowing you to easily identify and manage your save files.
            }
        }
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