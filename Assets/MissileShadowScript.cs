using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileShadowScript : MonoBehaviour
{
	private float currentValue = 0.01f;
	private float targetValue = 0.03f;
	private float duration = 5f;
	private float timer = 0f;

	public GameObject Missile;

	private RectTransform r;

	private void Start()
	{
		r = GetComponent<RectTransform>();
		TimerEvent.Timer += SummonMissiel;
	}

	void Update()
	{
		if (currentValue < targetValue)
		{
			timer += Time.deltaTime;
			currentValue = Mathf.Lerp(0.01f, 0.03f, timer / duration);
		}
		else
		{
			currentValue = targetValue;
		}

		r.localScale = new Vector3(currentValue, currentValue, currentValue);
	}

	private void SummonMissiel()
	{
		if (currentValue < targetValue) return;
		
		GameObject g = Instantiate(Missile);
		g.transform.position = new Vector3(transform.position.x, 10f, transform.position.z);
		var a = g.GetComponent<MissileScript>().canvas.GetComponent<RectTransform>();
		g.GetComponent<MissileScript>().summoner = gameObject;

		a.localScale = new Vector3(a.localScale.x, -a.localScale.y, a.localScale.z);

		TimerEvent.Timer -= SummonMissiel;
	}
}
