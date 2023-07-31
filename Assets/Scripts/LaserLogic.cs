using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserLogic : MonoBehaviour
{
    public GameObject player;

    void Update()
    {
        transform.position = player.transform.position;
        if (!PlayerMovement.shouldMove) return;  
    }
}
