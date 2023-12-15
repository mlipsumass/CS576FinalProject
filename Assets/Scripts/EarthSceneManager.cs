using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class EarthSceneManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float timer = 0.0f;
    private SceneManagerHelper sceneManagerHelper = new SceneManagerHelper();
    public Button changeSceneButton;

    // Start is called before the first frame update
    void Start()
    {
        changeSceneButton.onClick.AddListener(ChangeScene);
        sceneManagerHelper.InitializeTimer(timerText, timer);
    }

    // Update is called once per frame
    void Update()
    {
        sceneManagerHelper.UpdateTimer(timerText);
    }

   

    private void ChangeScene()
    {
        SceneManagerHelper.SetCurrentTimer(SceneManagerHelper.GetCurrentTimer());
        sceneManagerHelper.ChangeScene("Mars");
    }

}
