//using System.Collections.Generic;
//using System.IO;
//using UnityEngine;
//using UnityEngine.UI;

//public class NameLoader : MonoBehaviour
//{

//    public Button Button0, Button1, Button2, Button3;
//    public string NameFilePath;

//    private List<string> namesList;

//    void LoadNamesFromText()
//    {
//        // Read the text file into a string array
//        string[] namesArray = File.ReadAllLines(Application.dataPath + "/" + NameFilePath);

//        // Convert the array to a list
//        namesList = new List<string>(namesArray);
//    }

//    void UpdateButtonName()
//    {
//        // Select a random name from the list
//        string randomName = namesList[Random.Range(0, namesList.Count)];

//        // Update the text of the name button
//        nameText.text = randomName;
//    }
//}

//}
