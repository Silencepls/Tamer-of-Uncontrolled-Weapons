using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
	public GameObject bulletPefab;
	public float bulletSpeed = 10f;

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
		GameObject bullet = Instantiate(bulletPefab, transform.position + transform.forward, Quaternion.identity);
		Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
		bulletRb.velocity = direction_offseted.normalized * bulletSpeed;

		// Optionally, you can rotate the bullet to face the shooting direction.
		//bullet.transform.rotation = Quaternion.LookRotation(direction_offseted, Vector3.up);
	}

	private void ShootSecondBullet()
	{
		Debug.Log("Arroche");
	}

	private void ShootThirdBullet()
	{
		Debug.Log("Simbora");
	}
}
