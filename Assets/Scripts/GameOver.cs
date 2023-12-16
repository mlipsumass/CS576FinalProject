using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Matt Lips
public class GameOver : MonoBehaviour
{

	public GameObject gameUI;

	public GameObject playAgainButton;

	private SpriteRenderer fadeSprite;

	bool isGameOver = false;

	public Camera animationCamera;

	public Camera playerCamera;

	public GameObject player;

	public Button tryAgainButton;

	private void Start()
	{
		fadeSprite = GetComponentInChildren<SpriteRenderer>();
		tryAgainButton.onClick.AddListener(SceneManagerHelper.RestartGame);
	}

	public void TriggerGameOver()
	{
		if (isGameOver)
		{
			return;
		}
		isGameOver = true;
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		gameUI.SetActive(false);
		animationCamera.enabled = true;
		playerCamera.enabled = false;
		player.SetActive(false);
		StartCoroutine(FadeScreenToBlack());
	}

	IEnumerator FadeScreenToBlack()
	{
		for (int i = 0; i < 100; i++)
		{
			if (fadeSprite == null)
			{
				yield return null;
			}
			fadeSprite.color = new Color(0, 0, 0, (float)i / 100);
			yield return null;
		}

		playAgainButton.SetActive(true);
	}
}
