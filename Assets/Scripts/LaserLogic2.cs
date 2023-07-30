using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserLogic2 : MonoBehaviour
{
    public GameObject player;

    void Update()
    {
		if (!PlayerMovement.shouldMove) return;
		if (HackPosition.isRight)
        {
            transform.position = player.transform.position + new Vector3(24.95f, 0, 0);
            return;
		}
		transform.position = player.transform.position + new Vector3(-24.95f, 0, 0);
	}
}
