using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Matt Lips
public class AlienTalking : MonoBehaviour
{

	// Player
	public GameObject player;

	// Talking text
	public TextMeshProUGUI textMesh;

	// Alien talking animator
	public Animator animator;

	// Distance the alien will talk
	private float talkDistance;

	// Speech bubble
	public GameObject speechBubble;

	// 1 line of speech text
	public string talkText;

	// Multiple lines of speech text
	public string[] speechLines;

	// Time to talk per speech line
	public float intervalTime;

	// Index of speech
	private int speechLineIndex;

	// Current total time talking to player
	private float talkingTime;

	public BillboardText alienTextBubble;

	// Start is called before the first frame update
	void Start()
	{
		talkDistance = 15f;
		speechLineIndex = 0;
		talkingTime = 0;
		textMesh.text = talkText;
	}

	// Update is called once per frame
	void Update()
	{
		bool playerClose = (player.transform.position - transform.position).magnitude <= talkDistance;

		// If an array of talking elements is present, then talk in order of lines and reset when player leaves
		if (speechLines != null && speechLines.Length > 0)
		{
			if (!playerClose)
			{
				speechLineIndex = 0;
				talkingTime = 0;
			}
			else if (intervalTime != 0)
			{
				speechLineIndex = Mathf.FloorToInt(talkingTime / intervalTime);
				speechLineIndex = Mathf.Min(speechLineIndex, speechLines.Length - 1);
				talkingTime += Time.deltaTime;
				textMesh.text = speechLines[speechLineIndex];
			}
		}

		// Animate talking and turn to player if player close
		animator.SetBool("isTalking", playerClose);
		textMesh.enabled = playerClose;
		speechBubble.SetActive(playerClose);
		alienTextBubble.setRotationCondition(playerClose);

	}
}
