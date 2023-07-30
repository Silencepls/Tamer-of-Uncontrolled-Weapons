using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class LaserLogic : MonoBehaviour
{
    public GameObject player;

    void Update()
    {
        transform.position = player.transform.position;
        if (!PlayerMovement.shouldMove) return;
        Direction();       
    }

    private void Direction()
    {
		if (HackPosition.isRight)
        {
			transform.localScale = Vector3.one;
            return;
		}
        transform.localScale = new Vector3(-1, 1, 1);
	}
}
