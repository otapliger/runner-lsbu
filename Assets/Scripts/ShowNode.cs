using UnityEngine;

public class ShowNode : MonoBehaviour
{
	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(transform.position, transform.localScale);

		for (int i = 0; i < transform.parent.gameObject.transform.childCount; i++)
		{
			if (i > 0)
			{
				var point1 = transform.parent.gameObject.transform.GetChild(i - 1);
				var point2 = transform.parent.gameObject.transform.GetChild(i );
				Gizmos.DrawLine(point1.position, point2.position);
			}
		}
	}
}
