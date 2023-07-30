using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
	public List<GameObject> buildings;
	public List<GameObject> sideWalks;
	public int lastIndex = -1;

	public int count = 0;
	public int _count = 12;

	public int sequence = 0;

	public float _velocity = 0;
	public static float velocity = 0f;

	private void Start()
	{
		TimerEvent.Timer += TempLogic;
	}

	private void TempLogic()
	{
		if (sequence == 3)
		{
			sequence = 0;
		}
		if (count == _count)
		{
			count = 0;

			GameObject g = Instantiate(buildings[sequence]);
			Vector3 startPos = new(40, g.transform.position.y, g.transform.position.z);
			g.transform.position = startPos;
			sequence++;
		}
		count++;
	}

	private void BuildingManagerLocic()
	{
		if (count == 12)
		{
			count = 0;
			int randomNumber;

			if (lastIndex == -1)
			{
				randomNumber = Random.Range(0, buildings.Count);
			}
			else
			{
				randomNumber = Random.Range(0, buildings.Count + 1);
			}

			if (randomNumber == buildings.Count)
			{
				lastIndex = -1;
				return;
			}

			GameObject g = Instantiate(buildings[randomNumber]);
			Vector3 startPos = new(40, g.transform.position.y, g.transform.position.z);
			g.transform.position = startPos;
			lastIndex = randomNumber;
		}
		count++;

	}

	private void Update()
	{
		velocity = _velocity;
	}
}