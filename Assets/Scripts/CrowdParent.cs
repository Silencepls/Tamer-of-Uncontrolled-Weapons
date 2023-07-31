using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdParent : MonoBehaviour
{
	private int count = 0;

	public void SetActiveCivilians()
	{
		foreach (Transform child in transform)
		{
			child.gameObject.SetActive(true);
		}

		TimerEvent.Timer += CubeLogic;
	}

	private void CubeLogic()
	{
		if (count == 32)
		{
			GetComponentInChildren<Cube>().gameObject.SetActive(false);
			count = 0;
			TimerEvent.Timer -= CubeLogic;
		}
		count++;
	}

	public void MakeThemDie()
	{
		foreach (Transform child in transform)
		{
			if (child.GetComponent<CrowdScript>() != null)
			child.GetComponent<CrowdScript>().DeathAnimation();
		}
	}
}
