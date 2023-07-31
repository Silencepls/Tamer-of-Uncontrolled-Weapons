using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyAnimation : MonoBehaviour
{
	private Image i;

	public Sprite[] _animation;

	private int count = 0;
	private int frame = 0;

	private void Start()
	{
		i = GetComponent<Image>();
		TimerEvent.Timer += Func;
	}

	private void Func()
	{
		if (frame == _animation.Length)
		{
			frame = 0;
		}

		if (count == 5)
		{
			i.sprite = _animation[frame];
			frame++;
			count = 0;
		}
		count++;
	}

	private void OnDestroy()
	{
		TimerEvent.Timer -= Func;
	}
}
