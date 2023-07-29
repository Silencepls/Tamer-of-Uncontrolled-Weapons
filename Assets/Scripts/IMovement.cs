using UnityEngine;

public interface IMovement
{
	public void Move(GameObject g, Vector3 destination, float moveSpeed);
}