using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCursor : MonoBehaviour
{
	public float cursorSpeed = 5f;
	public static Vector3 destination;
	public Vector3 offset;
	public float offset_val = 1f;

	//private int currentTimer = 0;
	public int updateRateSeconds = 1;

	private void Start()
	{
		Cursor.visible = false;
		//TimerEvent.Timer += (object sender, TimerEvent.TimerEventHandler e) =>
		//{
		//	currentTimer++;

		//	if(currentTimer == updateRateSeconds)
		//	{
		//		GenerateOffset();
		//		currentTimer = 0;
		//	}
		//};
	}

	private void Update()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
		{
			destination = new Vector3(hit.point.x, transform.position.y, hit.point.z);
		}

		transform.position = Vector3.Lerp(transform.position, destination, cursorSpeed * Time.deltaTime);
	}

	//private void GenerateOffset()
	//{
	//	offset = new Vector3(Random.Range(-offset_val, offset_val), transform.position.y, Random.Range(-offset_val, offset_val));
	//}
}
