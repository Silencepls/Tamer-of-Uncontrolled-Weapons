using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	private int time = 0;

	private void Start()
	{
		TimerEvent.Timer += AutoDestroy;
	}

	private void AutoDestroy()
	{
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
}
