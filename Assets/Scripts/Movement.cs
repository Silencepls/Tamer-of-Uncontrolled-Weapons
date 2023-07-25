using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	public float moveSpeed = 5f;
	public float pushForce = 200f; // 200 to 800 | drag = 20 | mass = 10
	public float rotationSpeedMultiplier = 0.5f;
	private Rigidbody rb;

	private int timer = 0;

	void Start()
    {
        rb = GetComponent<Rigidbody>();
		TimerEvent.Timer += () =>
		{
			if (timer == 2)
			{
				ApplyPushForce();
				timer = 0;
			}
			timer++;
		};
    }

	private void FixedUpdate()
	{
		HandleRotation();
		HandleMovement();
	}

	private void HandleRotation()
	{
		Vector3 direction = new Vector3(MyCursor.destination.x, 0.5f, MyCursor.destination.z);
		Quaternion targetRotation = Quaternion.LookRotation(direction - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeedMultiplier * Time.deltaTime);
	}


	private void HandleMovement()
	{
		float horizontalInput = Input.GetAxis("Horizontal");
		float verticalInput = Input.GetAxis("Vertical");

		Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

		if (moveDirection != Vector3.zero)
		{
			rb.AddForce(moveSpeed * 10000 * Time.deltaTime * moveDirection, ForceMode.Force);
		}
	}

	private void ApplyPushForce()
	{
		Vector3 pushDirection = -transform.forward;
		pushDirection.x += Random.Range(-.3f, .3f);
		pushDirection.z += Random.Range(-.3f, .3f);
		rb.AddForce(pushDirection * pushForce, ForceMode.Impulse);
	}
}
