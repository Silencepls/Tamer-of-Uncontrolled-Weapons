using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
	public GameObject bulletPefab;
	public float bulletSpeed = 10f;

	private void Start()
	{
		TimerEvent.Timer += ShootBullet;
	}

	private void ShootBullet()
	{
		Vector3 direction = new Vector3(MyCursor.destination.x, 0.5f, MyCursor.destination.z).normalized;
		Vector3 direction_offseted = transform.forward;
		GameObject bullet = Instantiate(bulletPefab, transform.position + transform.forward, Quaternion.identity);
		Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
		bulletRb.velocity = direction_offseted.normalized * bulletSpeed;

		// Optionally, you can rotate the bullet to face the shooting direction.
		//bullet.transform.rotation = Quaternion.LookRotation(direction_offseted, Vector3.up);
	}
}
