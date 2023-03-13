using UnityEngine;
using UnityEngine.Events;
using TMPro;


public class ButtonChecker : MonoBehaviour
{
    [SerializeField] private GameContentControl control;
    [SerializeField] private UnityEvent OnLoseEvent;
    [SerializeField] private UnityEvent OnWinEvent;
    private int Id;
    private string NameButton;
    [SerializeField] private TextMeshProUGUI Text;


    

    public void CheckIdIsEqual()
    {
        if (Id == control.currentFruit.Id)
            OnWinEvent.Invoke();
        else
            OnLoseEvent.Invoke();
    }

    public void GetData(int id, string Name)
    {
        this.Id = id;
        NameButton = Name;
        UpdateText();
    }


    private void UpdateText()
    {
        Text.text = NameButton;
    }

}
