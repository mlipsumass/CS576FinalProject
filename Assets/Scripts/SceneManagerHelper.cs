using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SceneManagerHelper
{
    private static float currentTimer = 0.0f;
    private static float countInSeconds = 0.0f;
    private static float playerHealth = 1.0f;

    public static float GetCurrentTimer()
    {
        return currentTimer;
    }

    public static void SetCurrentTimer(float value)
    {
        currentTimer = value;
    }

    public static float GetPlayerHealth()
    {
        return playerHealth;
    }

    public static void SetPlayerHealth(float value)
    {
        playerHealth = Mathf.Clamp01(value); // Ensure health is between 0 and 1
    }

    public static void InitializeTimer(TextMeshProUGUI timerText, float initialTimerValue)
    {
        currentTimer = initialTimerValue;
        timerText.text = "Timer: " + (int)currentTimer;
    }

    public static void UpdateTimer(TextMeshProUGUI timerText)
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

    public static void UpdateScrollBar(GameObject scrollBar)
    {
        scrollBar.GetComponent<Scrollbar>().size = playerHealth;
        if (playerHealth < 0.5f)
        {
            ColorBlock cb = scrollBar.GetComponent<Scrollbar>().colors;
            cb.disabledColor = new Color(1.0f, 0.0f, 0.0f);
            scrollBar.GetComponent<Scrollbar>().colors = cb;
        }
        else
        {
            ColorBlock cb = scrollBar.GetComponent<Scrollbar>().colors;
            cb.disabledColor = new Color(0.0f, 1.0f, 0.25f);
            scrollBar.GetComponent<Scrollbar>().colors = cb;
        }
    }

    public static void HandleGameOver()
    {
        Debug.Log("Game Over");
    }

    public static void ChangeScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
