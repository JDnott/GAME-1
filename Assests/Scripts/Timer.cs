
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    // [SerializeField] private float timeRemaining = 10;
    public float timeRemaining = 10;
    [SerializeField] private bool timerIsRunning = false;
    [SerializeField] private TextMeshProUGUI timeText;

    [SerializeField] private UnityEvent OnLoseEvent;
    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
    }
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
               
                timeRemaining = 0;
                timerIsRunning = false;
                OnLoseEvent.Invoke();
            }
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}