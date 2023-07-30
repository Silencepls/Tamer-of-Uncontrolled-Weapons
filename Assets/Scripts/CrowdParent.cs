using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdParent : MonoBehaviour
{
	public void SetActiveCivilians()
	{
		foreach (Transform child in transform)
		{
			child.gameObject.SetActive(true);
		}
	}
}
