using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FactTrigger : MonoBehaviour
{

	public Transform[] factTriggerPlaces;

	public string[] facts;

	public TextMeshProUGUI textMesh;

	public GameObject textBubble;

	public Transform playerTransform;

	public CompanionMoving companionMovement;

	private bool[] factsSpoken;

	private Queue<string> dialogues;

	private float dialogueTalkTime;

	private float dialogueTimer;

	private bool isTalking;

	private void Start()
	{
		dialogues = new Queue<string>();
		if (factTriggerPlaces.Length != facts.Length)
		{
			Debug.LogError("Facts list and trigger places must have equal length.");
		}
		factsSpoken = new bool[facts.Length];

		textBubble.SetActive(false);
		textMesh.enabled = false;
		isTalking = false;
		dialogueTimer = 0;

		dialogueTalkTime = 2f;
	}

	private void Update()
	{
		CheckDialogueTrigger(playerTransform);
		if (isTalking)
		{
			dialogueTimer += Time.deltaTime;
			companionMovement.SetMove(true);
			if (dialogueTimer >= dialogueTalkTime)
			{
				dialogueTimer = 0;
				if (dialogues.Count > 0)
				{
					string nextLine = dialogues.Dequeue();
					SetNextLine(nextLine);
				}
				else
				{
					textBubble.SetActive(false);
					textMesh.enabled = false;
					isTalking = false;
					companionMovement.SetMove(false);
				}
			}
		}
	}

	public void CheckDialogueTrigger(Transform playerPosition)
	{

		Transform startPosition = transform;
		float closestTransformDistance = (playerPosition.position - startPosition.position).magnitude;
		int closestTransformIndex = -1;

		// Get the closest transform of the facts trigger positions
		for (int i = 0; i < factTriggerPlaces.Length; i++)
		{
			float transformDistance = (playerPosition.position - factTriggerPlaces[i].position).magnitude;
			if (transformDistance < closestTransformDistance)
			{
				closestTransformDistance = transformDistance;
				closestTransformIndex = i;

			}
		}

		// If a new fact trigger area has been entered and not spoken before,
		// then add the fact to the dialogue queue
		if (closestTransformIndex != -1 && !factsSpoken[closestTransformIndex])
		{
			AddDialogue(closestTransformIndex);
		}
	}

	private void AddDialogue(int index)
	{
		string fact = facts[index];
		factsSpoken[index] = true;

		// Break the fact to smaller dialogue pieces split by new line
		string[] factLines = fact.Split('$');

		for (int i = 0; i < factLines.Length; i++)
		{
			dialogues.Enqueue(factLines[i]);
		}

		if (!isTalking)
		{
			SetNextLine(factLines[0]);
		}
	}

	private void SetNextLine(string line)
	{
		textBubble.SetActive(true);
		textMesh.enabled = true;
		textMesh.text = line;
		isTalking = true;
	}
}
