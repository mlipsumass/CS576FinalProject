using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


// Girish and Matt Lips
public class MoonSceneManager : MonoBehaviour
{
	public TextMeshProUGUI timerText;

	public GameObject scrollBar;

	public Button changeSceneButton;

	public Camera animationCamera;

	public Camera playerCamera;

	public GameObject player;

	public Animator rocketAnimator;

	public ParticleSystem rocketLaunchParticles;

	public bool startSceneWithAnimation = true;

	private float waitTime = 4f;


	// Start is called before the first frame update
	void Start()
	{
		SceneManagerHelper.InitializeTimer(timerText, SceneManagerHelper.GetCurrentTimer());

		changeSceneButton.onClick.AddListener(StartRocketLaunchAnimation);

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
		SceneManagerHelper.SetCurrentTimer(SceneManagerHelper.GetCurrentTimer());
		SceneManagerHelper.ChangeScene("Mars");
	}

}