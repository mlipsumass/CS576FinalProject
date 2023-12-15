using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


// Girish
public class MarsSceneManager : MonoBehaviour
{
	public TextMeshProUGUI timerText;
	public TextMeshProUGUI sceneMessageText;
	public GameObject scrollBar;

	private bool showMessage = true;

	public Camera animationCamera;

	public Camera playerCamera;

	public GameObject player;
        if(SceneManagerHelper.isMarsGemAquired && showMessage)
        {
            sceneMessageText.text = $"Congratulations! You've acquired Blue gem.";
            StartCoroutine(ClearMessageAfterDelay(2.0f));
        }
    }

	public Animator rocketAnimator;

	public ParticleSystem rocketLaunchParticles;

	private float waitTime = 4f;

	// Start is called before the first frame update
	void Start()
	{
		//SceneManagerHelper.SetPlayerHealth(0.8f);
		SceneManagerHelper.InitializeTimer(timerText, SceneManagerHelper.GetCurrentTimer());


		Invoke("StartPlayerController", waitTime);
	}

	// Update is called once per frame
	void Update()
	{
		SceneManagerHelper.UpdateTimer(timerText);
		SceneManagerHelper.UpdateScrollBar(scrollBar);

		if (SceneManagerHelper.is_mars_gem_achieved && showMessage)
		{
			sceneMessageText.text = $"Congratulations! You've acquired Blue gem.";
			StartCoroutine(ClearMessageAfterDelay(2.0f));
		}
	}

	// Begin the player controller after the animation plays
	void StartPlayerController()
	{
		playerCamera.enabled = true;
		animationCamera.enabled = false;
		player.SetActive(true);
	}

	// Start the rocket launch animation
	public void StartRocketLaunchAnimation()
	{
		animationCamera.enabled = true;
		playerCamera.enabled = false;
		player.SetActive(false);
		rocketAnimator.SetTrigger("launchTrigger");
		rocketLaunchParticles.Play();
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
