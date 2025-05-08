using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public float timeRemaining = 120f;
    public TextMeshProUGUI timerText;
    public GameObject gameOverPanel; // Optional if you want a "You Lose" screen

    private bool timerRunning = true;

    void Update()
    {
        if (timerRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerDisplay(timeRemaining);
            }
            else
            {
                timerRunning = false;
                timeRemaining = 0;
                UpdateTimerDisplay(timeRemaining);
                GameOver();
            }
        }
    }

    void UpdateTimerDisplay(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        timerText.text = string.Format("Bus Leaves in {0:00}:{1:00}", minutes, seconds);
    }

    void GameOver()
    {
        // Optional: Show Game Over screen
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        // Disable player movement or show restart UI
        Time.timeScale = 0;
    }
}
