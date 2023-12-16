using UnityEngine;

// Matt Lips
public class CameraController : MonoBehaviour
{
	public float rotationSpeed = 5f;
	public float movementSpeed = 5f;
	public float verticalSpeed = 5f;

	void Start()
	{
		// Hide the mouse cursor at the beginning
		Cursor.visible = false;
	}

	void Update()
	{
		// Hide the mouse cursor when clicking
		// if (Input.GetMouseButtonDown(0))
		// {
		// 	Cursor.lockState = CursorLockMode.Locked;
		// 	Cursor.visible = false;
		// }

		// Mouse rotation
		float mouseX = Input.GetAxis("Mouse X");

		transform.Rotate(Vector3.up * mouseX * rotationSpeed);

		// Keyboard movement
		float horizontalInput = Input.GetAxis("Horizontal");
		float verticalInput = Input.GetAxis("Vertical");

		Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;
		Vector3 moveAmount = moveDirection * movementSpeed * Time.deltaTime;

		FindObjectOfType<AudioManager>().Play("enemy_attack");
		transform.Translate(moveAmount);

		// Arrow key vertical movement
		float verticalTranslation = 0;

		if (!Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.Space))
		{
			verticalTranslation = verticalSpeed * Time.deltaTime;
		}
		else if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.Space))
		{
			verticalTranslation = -verticalSpeed * Time.deltaTime;
		}

		// Move the camera up or down based on space key input
		transform.Translate(Vector3.up * verticalTranslation);
	}
}
