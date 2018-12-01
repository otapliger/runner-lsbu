using UnityEngine;

public class RandomPosition : MonoBehaviour
{
	public Vector3 range = Vector3.zero;

	public void Randomize()
	{
		var randomX = transform.position.x + Random.Range(-range.x, range.x);
		var randomY = transform.position.y + Random.Range(-range.y, range.y);
		var randomZ = transform.position.z + Random.Range(-range.z, range.z);
		transform.position = new Vector3(randomX, randomY, randomZ);
	}
}
