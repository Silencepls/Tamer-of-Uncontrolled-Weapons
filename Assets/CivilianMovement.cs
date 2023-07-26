using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class CivilianMovement : MonoBehaviour
{
	private Vector3 destination;
	public float moveSpeed;

	private void Start()
	{
		moveSpeed = Random.Range(5f, 15f);
		destination = new Vector3(-17f, 0.5f, Random.Range(-9f, 9f));
	}

	private void Update()
	{
		transform.position = Vector3.MoveTowards(transform.position, destination, moveSpeed * Time.deltaTime);

		if (Vector3.Distance(transform.position, destination) < 0.1f)
		{	
			Destroy(gameObject);
		}
	}
}
