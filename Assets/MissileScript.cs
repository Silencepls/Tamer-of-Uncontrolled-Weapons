using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileScript : MonoBehaviour
{
	private float currentValue = 0.01f;
	private float targetValue = 0.03f;
	private float duration = 5f;
	private float timer = 0f;

	private RectTransform r;

	private void Start()
	{
		r = GetComponent<RectTransform>();
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
		Debug.Log("Current Value: " + currentValue);
	}
}
