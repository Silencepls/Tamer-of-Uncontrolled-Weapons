using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
	public GameObject firstbulletPefab;
	public GameObject secondbulletPefab;
	public float bulletSpeed = 10f;

	public GameObject laser;
	public GameObject laser_collider;

	public int count = 0;

	private void Awake()
	{
		GameManager.bullet_event += BulletManager;
	}

	private void BulletManager()
	{
		switch (GameManager.bulletState)
		{
			case BulletState.First:
				TimerEvent.Timer -= ShootFirstBullet;
				TimerEvent.Timer -= ShootThirdBullet;
				TimerEvent.Timer -= ShootSecondBullet;
				TimerEvent.Timer += ShootFirstBullet;
				break;

			case BulletState.Second:
				TimerEvent.Timer -= ShootSecondBullet;
				TimerEvent.Timer -= ShootThirdBullet;
				TimerEvent.Timer += ShootSecondBullet;
				TimerEvent.Timer -= ShootFirstBullet;
				break;

			case BulletState.Third:
				TimerEvent.Timer -= ShootThirdBullet;
				TimerEvent.Timer += ShootThirdBullet;
				TimerEvent.Timer -= ShootSecondBullet;
				TimerEvent.Timer -= ShootFirstBullet;
				break;
		}
	}

	private void ShootFirstBullet()
	{
		Vector3 direction_offseted = transform.forward;
		direction_offseted.x += Random.Range(-.3f, .3f);
		direction_offseted.z -= Random.Range(-.3f, .3f);
		GameObject bullet = Instantiate(firstbulletPefab, transform.position + transform.forward, Quaternion.identity);
		Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
		bulletRb.velocity = direction_offseted.normalized * bulletSpeed;
	}

	private void ShootSecondBullet()
	{
		Vector3 direction_offseted = transform.forward;
		GameObject bullet = Instantiate(secondbulletPefab, transform.position + transform.forward, Quaternion.identity);
		Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
		bulletRb.velocity = direction_offseted.normalized * bulletSpeed;
	}

	private void ShootThirdBullet()
	{
		if (count >= 20)
		{
			laser.SetActive(true);
			laser_collider.GetComponent<BoxCollider>().enabled = true;
			PlayerMovement.shouldMove = false;
			if (count >= 30)
			{
				laser.SetActive(false);
				laser_collider.GetComponent<BoxCollider>().enabled = false;
				count = 0;
				PlayerMovement.shouldMove = true;
				TimerEvent.Timer -= ShootThirdBullet;
				return;
			}
		}
		count++;
	}
}
