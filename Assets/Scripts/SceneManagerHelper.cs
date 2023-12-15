using TMPro;
using UnityEngine;





public class SceneManagerHelper
{
    private static float currentTimer = 0.0f;
    private static float countInSeconds = 0.0f;

    public static float GetCurrentTimer()
    {
        return currentTimer;
    }

    public static void SetCurrentTimer(float value)
    {
        currentTimer = value;
    }

    public void InitializeTimer(TextMeshProUGUI timerText, float initialTimerValue)
    {
        currentTimer = initialTimerValue;
        timerText.text = "Timer: " + (int)currentTimer;
    }

    public void UpdateTimer(TextMeshProUGUI timerText)
    {
        countInSeconds += Time.deltaTime;
        if (countInSeconds >= 1.0f)
        {
            currentTimer -= countInSeconds;
            if (currentTimer <= 0.0f)
            {
                HandleGameOver();
            }
            else
            {
                timerText.text = "Timer: " + (int)currentTimer;
            }
            countInSeconds = 0.0f;
        }
    }

    private static void HandleGameOver()
    {
        Debug.Log("Game Over");
    }

    public void ChangeScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}

