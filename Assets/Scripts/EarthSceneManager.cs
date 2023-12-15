using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class EarthSceneManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public GameObject scrollBar;
    public float timer = 0.0f;
    public Button changeSceneButton;

    // Start is called before the first frame update
    void Start()
    {
        changeSceneButton.onClick.AddListener(ChangeScene);
        SceneManagerHelper.InitializeTimer(timerText, timer);
    }

    // Update is called once per frame
    void Update()
    {
        float player_health = SceneManagerHelper.GetPlayerHealth();
        SceneManagerHelper.UpdateTimer(timerText);

        SceneManagerHelper.UpdateScrollBar(scrollBar);

    }



    private void ChangeScene()
    {
        SceneManagerHelper.SetCurrentTimer(SceneManagerHelper.GetCurrentTimer());
        SceneManagerHelper.ChangeScene("Mars");
    }

}
