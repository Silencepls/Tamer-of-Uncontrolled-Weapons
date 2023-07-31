using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
	public static int total_civs = 0;
	public static int total_civ_crowds = 0;

	public int tt = 0;
	public int ttc= 0;
	public int t = 0;
	public int tc = 0;

	private BulletState[] staticBulletState = { BulletState.First, BulletState.Second, BulletState.Third };
	private BulletState[] BulletStateArray = { BulletState.First, BulletState.Second, BulletState.Third };
	private bool lastWasFirst = true;

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

	public static void RemoveFromList(GameObject g)
	{
		civiliansInMovement.Remove(g);
	}

	private void Start()
	{
		TimerEvent.Timer += EventHandler;
		bullet_event += CivilianManager;
		bullet_event?.Invoke();
	}

	private void Update()
	{
		tt = total_civs;
		ttc = total_civ_crowds;
		t = saved_Civilians;
		tc = saved_Crowds;
	}

	private int count2 = 0;

	private void EventHandler()
	{
		if (count2 >= 45)
		{
			int randomNumber = Random.Range(0, 3);
			if (!lastWasFirst)
			{
				randomNumber = Random.Range(0, 4);
				if (randomNumber == 1)
				{
					randomNumber = 2;
				}
				else
				{
					randomNumber = 0;
					lastWasFirst = true;
				}
				bulletState = BulletStateArray[randomNumber];
			}
			else
			{
				bulletState = BulletStateArray[randomNumber];
				if (randomNumber == 0) lastWasFirst = true;
				else lastWasFirst = false;
			}
			bullet_event?.Invoke();
			count2 = 0;
		}
		count2++;
	}

	private void CivilianManager()
	{
		switch(bulletState)
		{
			case BulletState.First:
				AudioManager.instance.Play("SwitchingToBullets");
				TimerEvent.Timer -= FirstState;
				TimerEvent.Timer += FirstState;
				break;
			
			case BulletState.Second:
				AudioManager.instance.Play("SwitchingToMissle");
				int randomNumber = Random.Range(0, civiliansInMovement.Count);
				for (int i = 0; i <= randomNumber; i++)
				{
					SecondState();
				}
				FallMissileToCivilians();
				break;	
			
			case BulletState.Third:
				AudioManager.instance.Play("SwitchingToLaser");
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

	private int _count = 0;
	public GameObject civil1;
	public GameObject civil2;

	private void FirstState()
	{
		if(_count == 30)
		{
			Instantiate(civil1);
			Instantiate(civil2);
			_count = 0;
		}
		_count++;

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