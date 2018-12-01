using UnityEngine;

public class PathFollowing : MonoBehaviour
{
    public float speed = 3f;
    public GameObject path;
    Vector3 initialPosition;
    Transform targetNode;
	float timeScale;
	int nextNode;

	void Start()
	{
		timeScale = Time.timeScale;
		initialPosition = transform.localPosition;
		targetNode = path.transform.GetChild(nextNode);
	}

	void FixedUpdate()
    {
        var direction = targetNode.localPosition - transform.localPosition;

        if (Time.timeScale > timeScale)
			speed += (timeScale - Time.timeScale) * 2;

		if (direction.magnitude <= speed * Time.fixedDeltaTime)
			GetNextNode();

		else if (transform.position.x > -10f)
			transform.Translate(direction.normalized * speed * Time.fixedDeltaTime, Space.World);

		timeScale = Time.timeScale;
	}

	void GetNextNode()
	{
		if (nextNode < path.transform.childCount - 1)
			nextNode++;

		else
		{
			transform.localPosition = initialPosition;

			for (int i = 0; i < path.transform.childCount; i++)
			{
				var node = path.transform.GetChild(i);
				var nodePosition = node.GetComponent<RandomPosition>();

				if (nodePosition != null)
					nodePosition.Randomize();
			}

			nextNode = 0;
		}

		targetNode = path.transform.GetChild(nextNode);
	}
}
