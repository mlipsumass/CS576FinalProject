using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EarthSceneManager : MonoBehaviour
{
    public TextMeshProUGUI timer_text;
    public float timer = 0.0f;
    private float current_timer = 0.0f;
    private float countInSeconds = 0.0f;
    public Button changeSceneButton;

   
   

    // Start is called before the first frame update
    void Start()
    {
        changeSceneButton.onClick.AddListener(ChangeScene);
        current_timer = timer;
        timer_text.text = "Timer: " + timer.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Earth Update");
        OperateTimer();
    }

    private void OperateTimer()
    {
        countInSeconds += Time.deltaTime;
        if (countInSeconds >= 1.0f)
        {
            current_timer -= countInSeconds;
            if (current_timer <= 0.0f)
            {
                HandleGameOver();
            }
            else
            {
                timer_text.text = "Timer: " + (int)current_timer;
            }
            countInSeconds = 0.0f;
        }
    }

    private void HandleGameOver()
    {
        Debug.Log("Game Over");
    }

    private void ChangeScene()
    {
        string sceneName = "Mars";

       
        PlayerPrefs.SetFloat("TimerValue", current_timer);

        
        SceneManager.LoadScene(sceneName);
    }
}
