using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Girish
public class EarthSceneManager : MonoBehaviour
{
	public TextMeshProUGUI timerText;
	public GameObject scrollBar;
	public float timer = 0.0f;

	public Camera animationCamera;

	public Camera playerCamera;

	public GameObject player;

	public Animator rocketAnimator;

	public ParticleSystem rocketLaunchParticles;

	private float waitTime = 3f;

	// Start is called before the first frame update
	void Start()
	{
		SceneManagerHelper.changeSceneTriggered = false;
		SceneManagerHelper.InitializeTimer(timerText, timer);

		rocketAnimator.SetTrigger("stopLaunchLow");
	}

	// Update is called once per frame
	void Update()
	{
		float player_health = SceneManagerHelper.GetPlayerHealth();
		SceneManagerHelper.UpdateTimer(timerText);

		SceneManagerHelper.UpdateScrollBar(scrollBar);
		if (SceneManagerHelper.changeSceneTriggered)
		{
			Debug.Log("changescenetrigger is set to true");
			StartRocketLaunchAnimation();
			SceneManagerHelper.changeSceneTriggered = false;
		}

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
		SceneManagerHelper.ChangeScene("Moon");
	}

}
