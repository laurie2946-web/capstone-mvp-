using UnityEngine;
using TMPro; // Required for TextMeshPro

public class VRCountdownTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText; // Drag your TMP text here
    [SerializeField] private float timeLeft = 60f; // Starting time in seconds
    
    private bool timerIsRunning = false;

    void Start()
    {
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                UpdateTimerDisplay(timeLeft);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeLeft = 0;
                timerIsRunning = false;
                // Add your game-over logic here (e.g., trigger an event)
            }
        }
    }

    void UpdateTimerDisplay(float timeToDisplay)
    {
        if (timeToDisplay < 0) timeToDisplay = 0;

        // Calculate minutes and seconds
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        // Format the text to look like MM:SS
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
