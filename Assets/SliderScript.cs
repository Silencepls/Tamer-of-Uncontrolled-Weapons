using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
	public float startValue;
	public Slider slider;

	private void Start()
	{
		slider = GetComponent<Slider>();
		slider.value = 0.5f;
		slider.maxValue = 1f;
		slider.minValue = 0f;
		startValue = slider.value;

		slider.onValueChanged.AddListener(UpdateVolume);
	}

	private void UpdateVolume(float value)
	{
		AudioManager.instance.UpdateVolume(value);
	}
}
