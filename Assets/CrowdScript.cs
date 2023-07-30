using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdScript : MonoBehaviour
{
	private Vector3 startPosition;
	private Vector3 destination;
	private float moveSpeed;

	private void Start()
	{
		startPosition = transform.position;
		destination = new Vector3(-24f, 0.5f, transform.position.z + Random.Range(0f, 1f));
		moveSpeed = Random.Range(5f, 10f);
	}

	private void Update()
	{
		transform.position = Vector3.MoveTowards(transform.position, destination, moveSpeed * Time.deltaTime);

		if (Vector3.Distance(transform.position, destination) < 0.1f)
		{
			transform.position = startPosition;
			gameObject.SetActive(false);
		}
	}
}
