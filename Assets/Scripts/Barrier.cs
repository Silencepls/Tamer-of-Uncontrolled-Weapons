using UnityEngine;

public class Barrier : MonoBehaviour
{
	public GameObject civilian;

	private void Update()
	{
		if(civilian.CompareTag("Civilian"))
		{
			Destroy(gameObject);
		}
	}
}