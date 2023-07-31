using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrowdScript : MonoBehaviour
{
	private Vector3 startPosition;
	private Vector3 destination;
	private float moveSpeed;

	private bool isdying = false;
	private Vector3 a;

	private void Start()
	{
		startPosition = transform.position;
		destination = new Vector3(-24f, 0.5f, transform.position.z + Random.Range(0f, 1f));
		moveSpeed = Random.Range(5f, 10f);
	}

	private void OnEnable()
	{
		GameManager.total_civ_crowds++;
	}

	private void Update()
	{
		if (isdying)
		{
			transform.position = Vector3.MoveTowards(transform.position, a, 5 * Time.deltaTime);

			if (Vector3.Distance(transform.position, a) < 0.1f)
			{
				transform.position = startPosition;
				transform.GetChild(0).GetChild(0).GetComponent<Image>().color = Color.white;
				isdying = false;
				gameObject.SetActive(false);
			}
			return;
		}

		transform.position = Vector3.MoveTowards(transform.position, destination, moveSpeed * Time.deltaTime);

		if (Vector3.Distance(transform.position, destination) < 0.1f)
		{
			transform.position = startPosition;
			GameManager.saved_Crowds++;
			gameObject.SetActive(false);
		}
	}

	public void DeathAnimation()
	{
		isdying = true;

		a = new Vector3(transform.position.x, 10f, transform.position.z);
		transform.GetChild(0).GetChild(0).GetComponent<Image>().color = Color.red;
	}
}
