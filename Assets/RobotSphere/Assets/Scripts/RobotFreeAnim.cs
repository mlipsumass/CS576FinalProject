using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotFreeAnim : MonoBehaviour {

	public Transform player;
	public float detectionDistance = 10f;
	public float movementSpeed = 2f;

	Vector3 rot = Vector3.zero;
	float rotSpeed = 40f;
	Animator anim;

	// Use this for initialization
	void Awake()
	{
		anim = gameObject.GetComponent<Animator>();
		// gameObject.transform.eulerAngles = rot;
	}

	// Update is called once per frame
	void Update()
	{
		// CheckKey();
		// gameObject.transform.eulerAngles = rot;

		MoveTowardPlayer();
	}

	void CheckKey()
	{
		// Walk
		if (Input.GetKey(KeyCode.W))
		{
			anim.SetBool("Walk_Anim", true);
		}
		else if (Input.GetKeyUp(KeyCode.W))
		{
			anim.SetBool("Walk_Anim", false);
		}

		// Rotate Left
		if (Input.GetKey(KeyCode.A))
		{
			rot[1] -= rotSpeed * Time.fixedDeltaTime;
		}

		// Rotate Right
		if (Input.GetKey(KeyCode.D))
		{
			rot[1] += rotSpeed * Time.fixedDeltaTime;
		}

		// Roll
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (anim.GetBool("Roll_Anim"))
			{
				anim.SetBool("Roll_Anim", false);
			}
			else
			{
				anim.SetBool("Roll_Anim", true);
			}
		}

		// Close
		if (Input.GetKeyDown(KeyCode.LeftControl))
		{
			if (!anim.GetBool("Open_Anim"))
			{
				anim.SetBool("Open_Anim", true);
			}
			else
			{
				anim.SetBool("Open_Anim", false);
			}
		}
	}

	void MoveTowardPlayer()
	{
		if (player == null)
			return;

		float distancetoPlayer = Vector3.Distance(transform.position, player.position);

		if (distancetoPlayer <= detectionDistance)
		{
			Vector3 direction = (player.position - transform.position).normalized;
			transform.position += direction * movementSpeed * Time.deltaTime;

			Quaternion targetRoatation = Quaternion.LookRotation(direction);
			transform.rotation = Quaternion.Lerp(transform.rotation, targetRoatation, Time.deltaTime * 5f);

			anim.SetBool("Walk_Anim", true);
		}
		else{
			anim.SetBool("Walk_Anim", false);
		}
	}

}
