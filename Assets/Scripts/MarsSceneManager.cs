using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class MarsSceneManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI sceneMessageText;
    public GameObject scrollBar;

    private bool showMessage = true;

    // Start is called before the first frame update
    void Start()
    {
        //SceneManagerHelper.SetPlayerHealth(0.8f);
        SceneManagerHelper.InitializeTimer(timerText, SceneManagerHelper.GetCurrentTimer());
    }

    // Update is called once per frame
    void Update()
    {
        SceneManagerHelper.UpdateTimer(timerText);
        SceneManagerHelper.UpdateScrollBar(scrollBar);

        if(SceneManagerHelper.is_mars_gem_achieved && showMessage)
        {
            sceneMessageText.text = $"Congratulations! You've acquired Blue gem.";
            StartCoroutine(ClearMessageAfterDelay(2.0f));
        }
    }

    IEnumerator ClearMessageAfterDelay(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Clear the scene message text
        sceneMessageText.text = "";
        showMessage = false;
    }
}
