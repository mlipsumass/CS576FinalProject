using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MarsSceneManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float timer = 0.0f;
    private float currentTimer = 0.0f;
    private float countInSeconds = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        SceneManagerHelper.InitializeTimer(timerText, ref currentTimer, timer);
    }

    // Update is called once per frame
    void Update()
    {
        SceneManagerHelper.UpdateTimer(timerText, ref currentTimer, ref countInSeconds);
    }
}