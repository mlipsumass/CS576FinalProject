using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Matt Lips
public class CompanionMoving : MonoBehaviour
{

	public Vector3 onCameraPosition;

	public Vector3 offCameraPosition;

	private bool isOnScreen;

	private float moveTime;

	private float moveTimer;

	// Start is called before the first frame update
	void Start()
	{
		transform.localPosition = offCameraPosition;

		moveTime = 0.5f;
		moveTimer = 1;
	}

	// Update is called once per frame
	void Update()
	{
		moveTimer += Time.deltaTime;
		if (isOnScreen)
		{
			transform.localPosition = Vector3.Slerp(offCameraPosition, onCameraPosition, moveTimer);
		}
		else
		{
			transform.localPosition = Vector3.Slerp(onCameraPosition, offCameraPosition, moveTimer);
		}

	}

	public void SetMove(bool moveOnScreen)
	{
		if (moveOnScreen == isOnScreen)
		{
			return;
		}
		float totalDistance = (offCameraPosition - onCameraPosition).magnitude;
		if (isOnScreen)
		{
			float progress = (transform.localPosition - onCameraPosition).magnitude / totalDistance;
			progress = Mathf.Min(progress, 1);
			progress = Mathf.Max(progress, 0);
			moveTimer = moveTime * progress;
		}
		else
		{
			float progress = (transform.localPosition - offCameraPosition).magnitude / totalDistance;
			progress = Mathf.Min(progress, 1);
			progress = Mathf.Max(progress, 0);
			moveTimer = moveTime * progress;
		}
		isOnScreen = moveOnScreen;
	}
}
