using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
	public static int saved_FirstBullet = 0;
	public static int saved_SecondBullet = 0;
	public static int saved_ThirdBullet = 0;

	public static BulletState bulletState = BulletState.First;
	public static Action bullet_event;

	public static List<GameObject> civiliansInMovement = new();
	public static List<GameObject> civiliansStopped = new();

	public List<CrowdParent> crowds = new();
	public GameObject civilian;
	private int timer = -1;

	public static void AddToList(GameObject g)
	{
		civiliansInMovement.Add(g);
	}

	public static void RemoveFromList(GameObject g)
	{
		civiliansInMovement.Remove(g);
		Destroy(g);
	}

	private void Start()
	{
		bullet_event += CivilianManager;
		bullet_event?.Invoke();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			bulletState = BulletState.First;
			bullet_event?.Invoke();
		}
		if (Input.GetKeyDown(KeyCode.Q))
		{
			bulletState = BulletState.Second;
			bullet_event?.Invoke();
		}
		if (Input.GetKeyDown(KeyCode.E))
		{
			bulletState = BulletState.Third;
			bullet_event?.Invoke();
		}
	}

	private void CivilianManager()
	{
		switch(bulletState)
		{
			case BulletState.First:
				TimerEvent.Timer -= FirstState;
				TimerEvent.Timer += FirstState;
				break;
			
			case BulletState.Second:
				SecondState();
				break;	
			
			case BulletState.Third:
				TimerEvent.Timer -= FirstState;
				ThirdState();
				break;
		}
	}
	
	private void FirstState()
	{
		if (timer != -1)
		{
			if (timer > 8)
			{
				GameObject g = Instantiate(civilian);
				AddToList(g);
				g.transform.position = new Vector3(24f, 0.5f, Random.Range(-7.5f, 5f));
				timer = -1;
			}
			else
			{
				timer++;
			}
		}
		else
		{
			timer = Random.Range(1, 8);
		}
	}

	private void SecondState()
	{
		if (civiliansInMovement.Count <= 0) return;

		GameObject g = civiliansInMovement[Random.Range(0, civiliansInMovement.Count)];
		g.GetComponent<CivilianMovement>().cms = new NoMovement();

		civiliansInMovement.Remove(g);
		civiliansStopped.Add(g);
	}

	private void ThirdState()
	{
		int randomNumber = Random.Range(0, 2);
		int numberOfRows = 0;
		if(randomNumber == 0)
		{
			crowds[0].SetActiveCivilians();
			numberOfRows++;
		}
		randomNumber = Random.Range(0, 2);
		if (randomNumber == 0)
		{
			crowds[1].SetActiveCivilians();
			numberOfRows++;
		}
		randomNumber = Random.Range(0, 2);
		if (randomNumber == 0 && numberOfRows != 2)
		{
			crowds[2].SetActiveCivilians();
			numberOfRows++;
		}
		if(numberOfRows == 0)
		{
			crowds[0].SetActiveCivilians();
			crowds[2].SetActiveCivilians();
		}
	}
}