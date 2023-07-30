using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserLogic2 : MonoBehaviour
{
    public GameObject player;

    void Update()
    {
        if (HackPosition.isRight)
        {
            Debug.Log("mouse is on right");
            transform.position = player.transform.position + new Vector3(24.95f, 0, 0);
            return;
		}
		Debug.Log("mouse is on left");
		transform.position = player.transform.position + new Vector3(-24.95f, 0, 0);
	}
}
