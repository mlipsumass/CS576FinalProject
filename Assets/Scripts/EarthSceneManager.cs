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

	public GameOver gameOverScript;

	public GameWon gameWonScript;

	public ParticleSystem confetti;

	public CapsuleCollider playerCollder;
	public CapsuleCollider winCollider;

	public float waitTime = 4f;

	private bool confettiPlayed = false;


	// Start is called before the first frame update
	void Start()
	{
		SceneManagerHelper.changeSceneTriggered = false;
		if (SceneManagerHelper.GetCurrentTimer() == 0.0f)
		{
			SceneManagerHelper.InitializeTimer(timerText, timer);
		}


		rocketAnimator.SetTrigger("stopLaunchLow");

		SceneManagerHelper.AddGameOverScript(gameOverScript);
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

		if ((SceneManagerHelper.isMarsGemAquired &&
			SceneManagerHelper.isMoonGemAquired &&
			playerCollder.bounds.Intersects(winCollider.bounds)))
		{
			if (!confettiPlayed)
			{
				confettiPlayed = true;
				confetti.Play();
			}
			gameWonScript.gameObject.SetActive(true);
			gameWonScript.TriggerGameWon();
			FindObjectOfType<AudioManager>().Play("game_win");
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
		FindObjectOfType<AudioManager>().Play("rocket_launch");
	}


	private void ChangeScene()
	{
		SceneManagerHelper.ChangeScene("Moon");
	}





}
