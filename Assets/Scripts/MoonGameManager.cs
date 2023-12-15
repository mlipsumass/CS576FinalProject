using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

// Matt Lips
public class GameManager : MonoBehaviour
{

	public Camera animationCamera;

	public Camera playerCamera;

	public GameObject player;

	public Animator rocketAnimator;

	public ParticleSystem rocketLaunchParticles;

	public bool startSceneWithAnimation = true;

	private float waitTime = 4f;

	void Start()
	{
		Invoke("StartPlayerController", waitTime);
		if (!startSceneWithAnimation)
		{
			rocketAnimator.SetTrigger("stopLaunchLow");
		}
	}

	void StartPlayerController()
	{
		animationCamera.enabled = false;
		playerCamera.enabled = true;
		player.SetActive(true);
	}

	public void StartRocketLaunchAnimation()
	{
		animationCamera.enabled = true;
		playerCamera.enabled = false;
		player.SetActive(false);
		rocketAnimator.SetTrigger("launchTrigger");
		rocketLaunchParticles.Play();
	}

}