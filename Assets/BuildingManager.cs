using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
	public List<GameObject> buildings;
	public List<GameObject> sideWalks;
	public int lastIndex = 0;

	public int count = 0;

	public float _velocity = 0;
	public static float velocity = 0f;

	private void Start()
	{
		TimerEvent.Timer += () =>
		{
			if(count == 5)
			{
				count = 0;
				int randomNumber = Random.Range(0, buildings.Count);
				switch (lastIndex)
				{
					case 1:
						if(randomNumber == 2)
						{
							randomNumber -= 1;
						}
						break;
					case 2:
						if(randomNumber == 1)
						{
							randomNumber -= 1;
						}
						break;
				}
				
				GameObject g = Instantiate(buildings[randomNumber]);
				Vector3 startPos = new(100, g.transform.position.y, g.transform.position.z);
				g.transform.position = startPos;
				lastIndex = randomNumber;

				//int randomNumber = Random.Range(0, buildings.Count + 1);
				//if(randomNumber == buildings.Count)
				//{
				//	switch(lastIndex)
				//	{
				//		case 1:
				//			Vector3 pos1 = lastObject.transform.position;
				//			GameObject a = Instantiate(sideWalks[0]);
				//			a.transform.position = new Vector3(pos1.x + 0.33f, a.transform.position.y, a.transform.position.z);
				//			break;
				//		case 2:
				//			Vector3 pos2 = lastObject.transform.position;
				//			GameObject b = Instantiate(sideWalks[0]);
				//			b.transform.position = new Vector3(pos2.x - 15.4f, b.transform.position.y, b.transform.position.z);
				//			break;
				//	}
				//}
				//else
				//{
				//	GameObject g = Instantiate(buildings[randomNumber]);
				//	Vector3 startPos = new(100, g.transform.position.y, g.transform.position.z);
				//	g.transform.position = startPos;
				//	lastIndex = randomNumber;
				//	lastObject = g;
				//}
			}
			count++;
		};
	}

	private void Update()
	{
		velocity = _velocity;
	}
}