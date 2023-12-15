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
	public Button changeSceneButton;

	public Camera animationCamera;

	public Camera playerCamera;

	public GameObject player;

	public Animator rocketAnimator;

	public ParticleSystem rocketLaunchParticles;

	public GameOver gameOverScript;

	public GameWon gameWonScript;

	public float waitTime = 4f;


	// Start is called before the first frame update
	void Start()
	{
		changeSceneButton.onClick.AddListener(StartRocketLaunchAnimation);
		SceneManagerHelper.InitializeTimer(timerText, timer);

		rocketAnimator.SetTrigger("stopLaunchLow");

		SceneManagerHelper.AddGameOverScript(gameOverScript);
	}

	// Update is called once per frame
	void Update()
	{
		float player_health = SceneManagerHelper.GetPlayerHealth();
		SceneManagerHelper.UpdateTimer(timerText);

		SceneManagerHelper.UpdateScrollBar(scrollBar);

		if (SceneManagerHelper.isMarsGemAquired &&
			SceneManagerHelper.isMoonGemAquired /* And reached the final destination */)
		{
			gameWonScript.gameObject.SetActive(true);
			gameWonScript.TriggerGameWon();
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
		SceneManagerHelper.SetCurrentTimer(SceneManagerHelper.GetCurrentTimer());
		SceneManagerHelper.ChangeScene("Moon");
	}





}
