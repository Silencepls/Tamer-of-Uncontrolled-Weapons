using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
	public static int total_civs = 0;
	public static int total_civ_crowds = 0;

	public int tt = 0;
	public int ttc= 0;
	public int t = 0;
	public int tc = 0;

	public static int saved_Civilians = 0;
	public static int saved_Crowds = 0;

	public static BulletState bulletState = BulletState.First;
	public static Action bullet_event;

	public static List<GameObject> civiliansInMovement = new();
	public static List<GameObject> civiliansStopped = new();

	public GameObject missileShadow;

	public List<CrowdParent> crowds = new();
	public GameObject civilian;
	private int timer = -1;

	public static void AddToList(GameObject g)
	{
		civiliansInMovement.Add(g);
	}

	public static void RemoveFromList(GameObject g, bool isSaved)
	{
		if (isSaved)
		{
			saved_Civilians++;
		}
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
		tt = total_civs;
		ttc = total_civ_crowds;
		t = saved_Civilians;
		tc = saved_Crowds;

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
				int randomNumber = Random.Range(0, civiliansInMovement.Count);
				for (int i = 0; i <= randomNumber; i++)
				{
					SecondState();
				}
				FallMissileToCivilians();
				break;	
			
			case BulletState.Third:
				TimerEvent.Timer -= FirstState;
				ThirdState();
				break;
		}
	}

	private void FallMissileToCivilians()
	{
		for (int i = 0; i < civiliansStopped.Count; i++)
		{
			var o = civiliansStopped[i];
			GameObject s = Instantiate(missileShadow);
			s.transform.position = new Vector3(o.transform.position.x, s.transform.position.y, o.transform.position.z);
			s.GetComponent<MissileShadowScript>().civilian = o;
		}

		civiliansStopped = new();
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
		var a = g.GetComponent<CivilianMovement>();
		g.tag = "InDanger";
		a.cms = new NoMovement();
		a.InDanger();

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