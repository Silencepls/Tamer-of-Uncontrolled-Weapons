using UnityEngine;
using UnityEngine.UI;

public class BuildingMovement : MonoBehaviour
{
	public GameObject fance;

	public GameObject[] buildings;
	public Material[] textures;

	private void Start()
	{
		int randomNumber = Random.Range(0, textures.Length);
        foreach (var b in buildings)
        {
            b.GetComponent<Renderer>().material = textures[randomNumber];
        }

		if (fance != null)
		{
			int random_number = Random.Range(0, 2);
			if (random_number == 0)
			{
				Destroy(fance);
			}
		}
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
