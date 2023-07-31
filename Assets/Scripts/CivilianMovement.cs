using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CivilianMovement : MonoBehaviour
{
	public Vector3 destination;
	public float moveSpeed;

	public IMovement cms = new FirstStateMovement();

	private Vector3 a;
	private bool isdying = false;

	private void Start()
	{
		GameManager.total_civs++;
		moveSpeed = Random.Range(5f, 15f);
		destination = new Vector3(-24f, 0.5f, Random.Range(-7.5f, 5f));
	}

	private void Update()
	{
		if (isdying)
		{
			transform.position = Vector3.MoveTowards(transform.position, a, 5 * Time.deltaTime);

			if (Vector3.Distance(transform.position, a) < 0.1f)
			{
				GameManager.RemoveFromList(gameObject);
			}
			return;
		}

		cms.Move(gameObject, destination, moveSpeed);
	}

	public void DeathAnimation()
	{
		isdying = true;

		a = new Vector3(transform.position.x, 10f, transform.position.z);
		transform.GetChild(0).GetChild(0).GetComponent<Image>().color = Color.red;
	}
}
