using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static int saved_FirstBullet = 0;
	public static int saved_SecondBullet = 0;
	public static int saved_ThirdBullet = 0;

	public GameObject civilian;

	private int timer = -1;

	private void Start()
	{
		TimerEvent.Timer += () =>
		{
			if(timer != -1)
			{
				if(timer > 8)
				{
					GameObject c = Instantiate(civilian);
					c.transform.position = new Vector3 (17f, 0.5f, Random.Range(-9f, 9f));
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
		};
	}
}
