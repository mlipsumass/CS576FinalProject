using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class GameWon : MonoBehaviour
{
	public GameObject gameUI;

	bool isGameWon = false;

	public RigidbodyFirstPersonController player;

	public Button tryAgainButton;

	private void Start()
	{
		tryAgainButton.onClick.AddListener(SceneManagerHelper.RestartGame);
	}

	public void TriggerGameWon()
	{
		if (isGameWon)
		{
			return;
		}
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		gameUI.SetActive(false);
		player.enabled = false;
		SceneManagerHelper.SetCurrentTimer(10000);
	}

}
