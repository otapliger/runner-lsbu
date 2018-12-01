using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	public float jumpSpeed;
	public Text scoreText;
	public Text deathText;
	bool isGrounded;

	void Start()
	{
		GameManager.playerPosition = transform.position;
		deathText.gameObject.SetActive(false);
	}

	void Update()
	{
		if (GameManager.isDead == false)
		{
			if (Input.GetKeyDown(KeyCode.Escape))
				Application.Quit();

			if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
			{
				GetComponent<Rigidbody>().AddForce(transform.up * jumpSpeed);
				transform.GetChild(0).GetComponent<Animator>().SetInteger("Animation", 1);
			}

			if (GetComponent<Rigidbody>().velocity.y < 0)
				transform.GetChild(0).GetComponent<Animator>().SetInteger("Animation", 2);

			scoreText.text = GameManager.score.ToString();
		}

		else
		{
			deathText.gameObject.SetActive(true);

			if (GameManager.isDead)
			{
				if (Input.GetKeyDown(KeyCode.Escape))
					Application.Quit();

				if (Input.GetKeyDown(KeyCode.Return))
				{
					SceneManager.LoadScene(0);
					GameManager.score = 0;
					GameManager.isDead = false;
				}
			}
		}
	}

	void OnCollisionEnter(Collision info)
	{
		if (GameManager.isDead == false)
		{
			if (info.gameObject.CompareTag("Ground"))
			{
				transform.GetChild(0).GetComponent<Animator>().SetInteger("Animation", 0);
				isGrounded = true;
			}
		}
	}

	void OnCollisionExit(Collision info)
	{
		if (GameManager.isDead == false)
			if (info.gameObject.CompareTag("Ground"))
				isGrounded = false;
	}

	void OnTriggerEnter(Collider info)
	{
		if (GameManager.isDead == false)
		{
			if (info.gameObject.CompareTag("Obstacle"))
			{
				GameManager.isDead = true;
				transform.GetChild(0).GetComponent<Animator>().SetInteger("Animation", 3);
			}

			if (info.gameObject.CompareTag("Ground"))
				isGrounded = false;
		}
	}
}
