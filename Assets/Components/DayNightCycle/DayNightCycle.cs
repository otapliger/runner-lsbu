using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
	public float timeSpeed;
	float amp = 0.5f;
	float index;

	void Update()
	{
		index += Time.deltaTime / 100;

		if (gameObject.tag == "MainCamera")
		{
			var camera = GetComponent<Camera>();
			var colorAmount = Mathf.Abs(amp * Mathf.Sin(index * timeSpeed));

			if (colorAmount < 0.25f)
				colorAmount = 0.25f;

			var targetColor = new Color(0, colorAmount / 2f, colorAmount / 1.25f, 1);
			camera.backgroundColor = targetColor;
		}
	}
}
