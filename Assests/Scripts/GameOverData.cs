using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GameOverData : MonoBehaviour
{
    [SerializeField] private Text _nameText;
    [SerializeField] private ScoreCounter score;

    private string fileName = "/data.txt";
    private string json;
    public ListData data;


    private void Start()
    {
        _nameText.text = SubmitButton.PlayerName;
        Debug.Log(SubmitButton.PlayerName);
        LoadData();
    }

    private void OnDestroy()
    {
        SubmitButton.PlayerName = null;
    }


    public void SaveNameAndScore()
    {
        
        var userData = new UserData();

        userData.Name = SubmitButton.PlayerName;
        userData.Score = score.Score;

        data.Users.Add(userData);
       

        SaveData();
      
    }

    private void LoadData()
    {
        if (!File.Exists(Application.dataPath + fileName))
        {
            Debug.LogWarning("Not Found");
            data = new ListData();
            data.Users = new List<UserData>();
            return;
        }

        string savedJson = File.ReadAllText(Application.dataPath + fileName);
        data = JsonUtility.FromJson<ListData>(savedJson);
        Debug.Log(data.Users.Count);
     

    }



    private void SaveData()
    {
        json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.dataPath + fileName, json);
    }
}



