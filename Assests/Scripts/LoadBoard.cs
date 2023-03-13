using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LoadBoard : MonoBehaviour
{
    private const string fileName = "/data.txt";
    private ListData data;
    [SerializeField] private Transform parent;
    [SerializeField] private GameObject prefab;



    private void Start()
    {
        LoadData();

    }
    private void LoadData()
    {
        if (!File.Exists(Application.dataPath + fileName))
        {
            Debug.LogWarning("Not Found");
            return;
        }

        string savedJson = File.ReadAllText(Application.dataPath + fileName);
        data = JsonUtility.FromJson<ListData>(savedJson);
        
        var dataSort = Sort(data.Users);
      
        foreach (var i in dataSort)
        {
           
            var row = Instantiate(prefab, parent);
            var massText = row.GetComponentsInChildren<Text>();
            massText[0].text = i.Name;
            massText[1].text = i.Score.ToString();

        }
      
        Debug.Log(data.Users.Count);
    }


    //private List<UserData> Sort(List<UserData> data)
    //{
    //    var value = 0;
    //    for(var i = 0; i < data.Count; i++)
    //    {
    //        if (data[i].Score > value)
    //        {
    //            var currentOb = data[i];
    //            data.Remove(currentOb);
    //            data.Insert(0, data[i]);
    //            value = currentOb.Score;
    //        }

    //    }
        
    //    return data;
    //}

    private List<UserData> Sort(List<UserData> data)
    {
        int n = data.Count;

        for (int i = 0; i < n - 1; i++)
        {
            // Last i elements are already sorted
            for (int j = 0; j < n - i - 1; j++)
            {
                // Swap if the element found is greater than the next element
                if (data[j].Score < data[j + 1].Score)
                {
                    UserData temp = data[j];
                    data[j] = data[j + 1];
                    data[j + 1] = temp;
                }
            }
        }

        return data;
    }
}
