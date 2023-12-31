﻿using UnityEngine;

public class Bullet2 : MonoBehaviour
{
	private int time = 0;

	public GameObject barrier;

	private void Start()
	{
		TimerEvent.Timer += AutoDestroy;
	}

	private void AutoDestroy()
	{
		int randomNumber = Random.Range(0, 6);
		if (randomNumber == 0)
		{
			TimerEvent.Timer -= AutoDestroy;
			Destroy(gameObject);
			return;
		}
		if (time >= 10)
		{
			TimerEvent.Timer -= AutoDestroy;
			Destroy(gameObject);
		}
		time++;
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Wall"))
		{
			TimerEvent.Timer -= AutoDestroy;
			Destroy(gameObject);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("InDanger"))
		{
			other.GetComponent<CivilianMovement>()._protected = true;
			GameObject g = Instantiate(barrier);
			g.GetComponent<Barrier>().civilian = other.gameObject;
			g.transform.position = other.transform.position;

			AudioManager.instance.Play("ShieldSound");
		}
	}

}