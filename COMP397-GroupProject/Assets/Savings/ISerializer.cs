using System.Collections;

public interface ISerializer
{
    string Serialize<T>(T obj); //This will recieve an object of type T and return a string representation of it in JSON format.
    T Deserialize<T>(string json); //This will take a JSON string and convert it back into an object of type T. The method will parse the JSON string and create an instance of the specified type, populating its properties with the data from the JSON.
}
