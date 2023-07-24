using UnityEngine;

public class BuildingMovement : MonoBehaviour
{
	private void Update()
	{
		transform.position += BuildingManager.velocity * Time.deltaTime * Vector3.left;
	}
}
