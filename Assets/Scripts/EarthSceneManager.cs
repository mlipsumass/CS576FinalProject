using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EarthSceneManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float timer = 0.0f;
    private float currentTimer = 0.0f;
    private float countInSeconds = 0.0f;
    public Button changeSceneButton;

    // Start is called before the first frame update
    void Start()
    {
        changeSceneButton.onClick.AddListener(ChangeScene);
        currentTimer = timer;
        timerText.text = "Timer: " + timer.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        SceneManagerHelper.UpdateTimer(timerText, ref currentTimer, ref countInSeconds);
    }

    private void ChangeScene()
    {
        SceneManagerHelper.ChangeScene("Mars", currentTimer);
    }
}