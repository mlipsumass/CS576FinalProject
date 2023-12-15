using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


// Girish and Matt Lips
public class MoonSceneManager : MonoBehaviour
{
	public TextMeshProUGUI timerText;
	public TextMeshProUGUI sceneMessageText;

	public GameObject scrollBar;

	public Camera animationCamera;

	public Camera playerCamera;

	public GameObject player;

	public Animator rocketAnimator;

	public ParticleSystem rocketLaunchParticles;

	public bool startSceneWithAnimation = true;

	private float waitTime = 4f;

	private bool showMessage = true;


	// Start is called before the first frame update
	void Start()
	{
		SceneManagerHelper.InitializeTimer(timerText, SceneManagerHelper.GetCurrentTimer());
		SceneManagerHelper.changeSceneTriggered = false;

		// Start player controller immediately
		if (!startSceneWithAnimation)
		{
			StartPlayerController();
			rocketAnimator.SetTrigger("stopLaunchLow");
		}

		// Play intro animation
		else
		{
			Invoke("StartPlayerController", waitTime);
		}
	}

	// Update is called once per frame
	void Update()
	{
		SceneManagerHelper.UpdateTimer(timerText);
		SceneManagerHelper.UpdateScrollBar(scrollBar);

		if (SceneManagerHelper.isMoonGemAquired && showMessage)
		{
			sceneMessageText.text = $"Congratulations! You've acquired Red gem.";
			StartCoroutine(ClearMessageAfterDelay(2.0f));
		}

		if (SceneManagerHelper.changeSceneTriggered)
		{
			Debug.Log("changescenetrigger is set to true");
			StartRocketLaunchAnimation();
			SceneManagerHelper.changeSceneTriggered = false;
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

		Invoke("ChangeScene", waitTime);
	}

	private void ChangeScene()
	{
		SceneManagerHelper.ChangeScene("Mars");
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
