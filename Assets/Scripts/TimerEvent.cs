using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerEvent : MonoBehaviour
{
	public static Action Timer;
	private const float UPDATE_RATE = .2f;
	private float _timer;

	private void Update()
	{
		_timer += Time.deltaTime;
		if (_timer >= UPDATE_RATE)
		{
			_timer -= UPDATE_RATE;
			Timer?.Invoke();
		}
	}
}
