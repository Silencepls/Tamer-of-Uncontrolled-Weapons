using UnityEngine;

public class FirstStateMovement : IMovement
{
	public void Move(GameObject g, Vector3 destination, float moveSpeed)
	{
		g.transform.position = Vector3.MoveTowards(g.transform.position, destination, moveSpeed * Time.deltaTime);

		if (Vector3.Distance(g.transform.position, destination) < 0.1f)
		{
			GameManager.saved_Civilians++;
			GameManager.RemoveFromList(g);
		}
	}
}
