using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HackPosition : MonoBehaviour
{
	public static HackPosition ins;

	public GameObject player;

	public Image i;
	private Vector3 d;
	private Vector3 e;

	public static bool isRight = true;

	private void Start()
	{
		if (ins == null)
		{
			ins = this;
		}

		d = i.rectTransform.localScale;
		e = d;
	}

	private void Update()
	{
		transform.position = player.transform.position;

		if (!PlayerMovement.shouldMove) return;

		if (transform.position.x > MyCursor.destination.x)
		{
			isRight = false;
			d.x = -e.x;
			i.rectTransform.localScale = d;
		}
		else if (transform.position.x < MyCursor.destination.x)
		{
			isRight = true;
			d.x = e.x;
			i.rectTransform.localScale = d;
		}
	}

	public void LookToRight()
	{
		isRight = true;
		d.x = e.x;
		i.rectTransform.localScale = d;
	}
}
