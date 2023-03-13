using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLoadD : MonoBehaviour
{
    // The name of the JSON file to read from and write to
        public string fileName = "data";

        // The data to append to the JSON file
        public UserData dataToAppend;

        // The data read from the JSON file
        private Dictionary<string, object> jsonData;

        private void Start()
        {
        // Load the JSON data from the file
        dataToAppend = new UserData();
        dataToAppend.Name = "Artem";
        dataToAppend.Score = 8;

        AppendData();
        LoadData();
            
        }

        private void LoadData()
        {
            string filePath = Application.dataPath + "/" + fileName + ".json";

            if (File.Exists(filePath))
            {
                // Read the existing JSON data from the file
                string json = File.ReadAllText(filePath);

                // Deserialize the JSON data into a dictionary
                jsonData = JsonUtility.FromJson<Dictionary<string, object>>(json);

                Debug.Log("JSON data loaded from file: " + filePath);

            }
            else
            {
                Debug.LogWarning("File not found: " + filePath);

                // Create a new empty dictionary if the file doesn't exist
                jsonData = new Dictionary<string, object>();
            }
        }

        public void AppendData()
        {
            // Add the new data to the dictionary
            jsonData["newData"] = dataToAppend;

            // Serialize the updated dictionary to JSON format
            string json = JsonUtility.ToJson(jsonData);

            // Write the updated JSON data to the file
            string filePath = Application.dataPath + "/" + fileName + ".json";
            File.WriteAllText(filePath, json);

            Debug.Log("JSON data appended to file: " + filePath);
        }
    }

