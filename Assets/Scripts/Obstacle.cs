using UnityEngine;

public class Obstacle : MonoBehaviour
{
	public float speed;
	float nextTimeScale;
	bool pastPlayer = false;
	bool wasVisible = false;

	void Start()
	{
		nextTimeScale = Time.timeScale;
	}

	void FixedUpdate()
	{
		if (GameManager.isDead == false)
		{
			transform.Translate(-transform.right * speed * Time.fixedDeltaTime, Space.World);

			if (transform.position.x < GameManager.playerPosition.x && pastPlayer == false)
			{
				GameManager.score++;
				pastPlayer = true;
			}

			if (transform.position.x > GameManager.playerPosition.x && pastPlayer == true)
				pastPlayer = false;

			if (GetComponent<MeshRenderer>().isVisible)
				Time.timeScale = Mathf.Lerp(Time.timeScale, nextTimeScale, 1f);
		}

		else
			Time.timeScale = Mathf.Lerp(Time.timeScale, 1f, 1f);
	}

	void OnBecameVisible()
	{
		wasVisible = true;
	}

	void OnBecameInvisible()
	{
		if (wasVisible)
		{
			wasVisible = false;
			nextTimeScale = Time.timeScale + 0.1f;
		}
	}
}
