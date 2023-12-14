using TMPro;
using UnityEngine;

public class SceneManagerHelper
{
    public static void InitializeTimer(TextMeshProUGUI timerText, ref float currentTimer, float initialTimerValue)
    {
        currentTimer = PlayerPrefs.GetFloat("TimerValue", initialTimerValue);
        timerText.text = "Timer: " + (int)currentTimer;
    }

    public static void UpdateTimer(TextMeshProUGUI timerText, ref float currentTimer, ref float countInSeconds)
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

    public static void ChangeScene(string sceneName, float currentTimerValue)
    {
        PlayerPrefs.SetFloat("TimerValue", currentTimerValue);
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
