using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class CivilianMovement : MonoBehaviour
{
	public Vector3 destination;
	public float moveSpeed;

	public IMovement cms = new FirstStateMovement();

	private void Start()
	{
		moveSpeed = Random.Range(5f, 15f);
		destination = new Vector3(-17f, 0.5f, Random.Range(-8f, 8f));
	}

	private void Update()
	{
		cms.Move(gameObject, destination, moveSpeed);
	}
}
