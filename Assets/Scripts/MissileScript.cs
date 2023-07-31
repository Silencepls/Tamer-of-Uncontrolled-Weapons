using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MissileScript : MonoBehaviour
{
	public GameObject canvas;
	public Image image;
	public GameObject summoner;
	public GameObject civilian;

	public GameObject explosion;

	private int count = 0;

	private Vector3 d;

	private void Start()
	{
		TimerEvent.Timer += Initialize;
	}

	void Update()
    {
		d = transform.position;
		d.y = 0.5f;
		transform.position = Vector3.MoveTowards(transform.position, d, 5 * Time.deltaTime);
	}

	private void Initialize()
	{
		if (Vector3.Distance(transform.position, d) < 0.1f)
		{
			AudioManager.instance.Play("MissleInpact");

			if (!civilian.GetComponent<CivilianMovement>()._protected)
			{
				civilian.GetComponent<CivilianMovement>().DeathAnimation();
			}

			GameObject g = Instantiate(explosion);
			g.transform.position = transform.position;
			explosion = g;

			civilian.tag = "Civilian";

			TimerEvent.Timer += Func;
			TimerEvent.Timer -= Initialize;
		}
	}

	private void Func()
	{
		if (count >= 20)
		{
			TimerEvent.Timer -= Func;
			Destroy(explosion);
			Destroy(gameObject);
			Destroy(summoner);
			return;
		}
		count++;
	}
}
