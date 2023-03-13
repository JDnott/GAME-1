using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Fruits
{
    public int Id;
    public Sprite Image;
    public string Name;
}

public class GameContentControl: MonoBehaviour
{
    [Header("Add fruit")]
    [SerializeField] private Fruits[] fruits;
    [Header("Aswer buttons")]
    [SerializeField] private ButtonChecker[] buttonsAnwer;
    [SerializeField] private Image image;
    [Header("CurrentFruit")]
    public Fruits currentFruit;
    [SerializeField] private Timer Time;
    
    private void Start()
    {
        Initialization();
    }

    public void Initialization()
    {
        FruitsFill();
        currentFruit = GetRandomFruit();
        image.sprite = currentFruit.Image;
        SendDataToButtons();
        Time.timeRemaining += 10;
    }

    void FruitsFill()
    {
        for (int i = 0; i < fruits.Length; i++)
        {
            fruits[i].Id = i;
            fruits[i].Name = fruits[i].Image.name;
        }
    }

    public void SetRandomFruit()
    {
        image.sprite = GetRandomFruit().Image;
    }

    public Fruits GetRandomFruit()
    {
        return fruits[Random.Range(0, fruits.Length)];
    }


    private void SendDataToButtons()
    {
        
        var currentMass = AddNewLis();
        var rightAnswer = currentMass[Random.Range(0, currentMass.Count)];
        rightAnswer.GetData(currentFruit.Id, currentFruit.Name);
        currentMass.Remove(rightAnswer);
        SendWrongAnswers(currentMass);
    }


    private void SendWrongAnswers(List<ButtonChecker> wrongList)
    {
       
        for (var i = 0; i < wrongList.Count; i++)
        {
            var wrongAnswer = GetRandomWrongFruit();
            wrongList[i].GetData(wrongAnswer.Id, wrongAnswer.Name);
        }           

    }


    private Fruits GetRandomWrongFruit()
    {
        var wrongFruit = fruits[Random.Range(0, fruits.Length)];
        if(wrongFruit == currentFruit)        
            return GetRandomWrongFruit();                    
        return wrongFruit;
    }


    private List<ButtonChecker> AddNewLis()
    {
        var newList = new List<ButtonChecker>();
        foreach (var i in buttonsAnwer)
            newList.Add(i);
        return newList;
    }
}

