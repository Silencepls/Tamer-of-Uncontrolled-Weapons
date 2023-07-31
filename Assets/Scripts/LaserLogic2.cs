using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserLogic2 : MonoBehaviour
{
    public GameObject player;

    void Update()
    {
		if (!PlayerMovement.shouldMove) return;
		transform.position = player.transform.position + new Vector3(24.95f, 0, 0);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Crowd"))
		{
			other.GetComponent<Cube>().parent.GetComponent<CrowdParent>().MakeThemDie();
		}

		if (other.CompareTag("Civilian"))
		{
			other.GetComponentInChildren<CivilianMovement>().DeathAnimation();
		}
	}
}
