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

	private Vector3 a = Vector3.zero;
	private bool isdying = false;

	public Sprite inDanger;

	private int count = 0;

	public GameObject barrier;

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
				GameManager.RemoveFromList(gameObject, false);
			}
			return;
		}

		cms.Move(gameObject, destination, moveSpeed);
	}

	public void DeathAnimation()
	{
		isdying = true;

		GameManager.RemoveFromList(gameObject, false);
		a = new Vector3(transform.position.x, 10f, transform.position.z);
		transform.GetChild(0).GetChild(0).GetComponent<Image>().color = Color.red;
	}

	public void InDanger()
	{
		cms = new NoMovement();
		transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = inDanger;
		TimerEvent.Timer += Func;
	}

	private void Func()
	{
		transform.GetChild(0).GetChild(0).GetComponent<MyAnimation>().enabled = false;
		if (count >= 80)
		{
			cms = new FirstStateMovement();
			transform.GetChild(0).GetChild(0).GetComponent<MyAnimation>().enabled = true;
			TimerEvent.Timer -= Func;
		}
		count++;
	}

	private void OnDestroy()
	{
		TimerEvent.Timer -= Func;
	}
}
