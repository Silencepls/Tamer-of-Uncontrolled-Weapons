using UnityEngine;

public class BuildingMovement : MonoBehaviour
{
	public GameObject fance;

	private void Start()
	{
		//if(fance != null)
		//{
		//	int random_number = Random.Range(0, 2);
		//	if(random_number == 0 )
		//	{
		//		Destroy( fance );
		//	}
		//}
	}

	private void Update()
	{
		transform.position += BuildingManager.velocity * Time.deltaTime * Vector3.left;
		if(transform.position.x <= -30)
		{
			Destroy(gameObject);
		}
	}
}
