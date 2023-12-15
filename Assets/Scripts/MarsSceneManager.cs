using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class MarsSceneManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public GameObject scrollBar;

    // Start is called before the first frame update
    void Start()
    {
        SceneManagerHelper.SetPlayerHealth(0.8f);
        SceneManagerHelper.InitializeTimer(timerText, SceneManagerHelper.GetCurrentTimer());
    }

    // Update is called once per frame
    void Update()
    {
        SceneManagerHelper.UpdateTimer(timerText);
        SceneManagerHelper.UpdateScrollBar(scrollBar);
    }
}
