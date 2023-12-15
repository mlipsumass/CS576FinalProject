using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class MarsSceneManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private SceneManagerHelper sceneManagerHelper = new SceneManagerHelper();

    // Start is called before the first frame update
    void Start()
    {
        sceneManagerHelper.InitializeTimer(timerText, SceneManagerHelper.GetCurrentTimer());
    }

    // Update is called once per frame
    void Update()
    {
        sceneManagerHelper.UpdateTimer(timerText);
    }
}
