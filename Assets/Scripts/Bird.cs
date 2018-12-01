using UnityEngine;

public class Bird : MonoBehaviour
{
	bool wasVisible = false;

	void OnBecameVisible()
	{
		wasVisible = true;
	}

	void OnBecameInvisible()
	{
		if (wasVisible)
			wasVisible = false;
	}
}
