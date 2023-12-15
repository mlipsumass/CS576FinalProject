using UnityEngine;
using TMPro;

// Matt Lips
public class BillboardText : MonoBehaviour
{

	// Player
	public GameObject player;

	// How fast billboard spins
	public float billboardSpeed = 100f;

	// Whether to spin towards player
	private bool rotationCondition = true;

	void Update()
	{
		if (rotationCondition)
		{

			// Find direction to player then spin that way
			Vector3 directionToPlayer = player.transform.position - transform.position;
			directionToPlayer.y = 0f;
			Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);
			transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * billboardSpeed);
		}
	}

	/// <summary>
	/// Set whether the object should billboard spin to player
	/// </summary>
	/// <param name="rotationCondition">Whether the object should billboard</param>
	public void setRotationCondition(bool rotationCondition)
	{
		this.rotationCondition = rotationCondition;
	}
}
