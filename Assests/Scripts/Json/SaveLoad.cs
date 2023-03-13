using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    UserData userData = new UserData();
    private string json;
    private string loadJson;
    private void Start()
    {
        userData.Name = "Artem";
        userData.Score = 8;
        Save();
        Load();
    }


    void Save()
    {
        json = JsonUtility.ToJson(userData);
        SaveToFile("Saves");
        
    }



    void Load()
    {
       
    }
    public void SaveToFile(string fileName)
    {
        string filePath = Application.dataPath + "/" + fileName + ".json";
        File.WriteAllText(filePath, json);
        Debug.Log("JSON file saved to " + filePath);
    }

    public void AppendToFile(string fileName)
    {
        string filePath = Application.dataPath + "/" + fileName + ".json";
       

        // check if the file exists
        if (File.Exists(filePath))
        {
            // read the existing JSON data from the file
            string existingJson = File.ReadAllText(filePath);

            // deserialize the existing JSON data into a Dictionary
            Dictionary<string, object> data = JsonUtility.FromJson<Dictionary<string, object>>(existingJson);

            // append the new JSON data to the existing data
            data["newData"] = loadJson;

            // serialize the updated data back to JSON format
            string updatedJson = JsonUtility.ToJson(data);

            // write the updated JSON data back to the file
            File.WriteAllText(filePath, updatedJson);

            Debug.Log("JSON data appended to file: " + filePath);
        }
        else
        {
            Debug.LogError("File not found: " + filePath);
        }
    }
}
