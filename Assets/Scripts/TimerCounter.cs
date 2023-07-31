using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerCountDown : MonoBehaviour
{
	public TextMeshProUGUI timerText;
	private float timeInSeconds = 0f;
	private int minutes = 0;
	private int seconds = 0;
	private bool isTimerRunning = true;

	private void Update()
	{
		if (isTimerRunning && minutes < 10)
		{
			timeInSeconds += Time.deltaTime;

			if (timeInSeconds >= 1f)
			{
				timeInSeconds -= 1f;
				seconds++;

				if (seconds >= 60)
				{
					seconds = 0;
					minutes++;
				}

				UpdateTimerText();
			}
		}
		else
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
	}

	private void UpdateTimerText()
	{
		string minutesString = minutes.ToString("D2");
		string secondsString = seconds.ToString("D2");
		timerText.text = minutesString + ":" + secondsString;
	}
}
