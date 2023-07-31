using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinalScore : MonoBehaviour
{
	public int a;
	public int b;
	public int c;
	public int d;

	private TextMeshProUGUI textMeshPro;

	private void Start()
	{
		Cursor.visible = true;

		a = Scores.instance.total_civs;
		b = Scores.instance.saved_Civilians;
		c = Scores.instance.total_civ_crowds;
		d = Scores.instance.saved_Crowds;


		textMeshPro = GetComponent<TextMeshProUGUI>();
		UpdateText();
	}

	private void UpdateText()
	{
		string text = $"total civilians: {a,-10}civilians saved: {b}\n" +
					  $"civilians in crowd: {c,-10}civilians in crowd saved: {d}";

		textMeshPro.text = text;
	}
}
