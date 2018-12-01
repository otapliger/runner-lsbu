using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class EndlessScrolling : MonoBehaviour
{
	bool wasVisible = false;

	Vector3 initialPosition;
	BoxCollider boxCollider;

	void Start()
	{
		initialPosition = transform.position;
		boxCollider = GetComponent<BoxCollider>();
	}

	void Update()
	{
		var bounds = boxCollider.bounds.extents;

		var topFrontLeftCorner = new Vector3(transform.position.x - bounds.x, transform.position.y - bounds.y, transform.position.z + bounds.z);
		var topRearLeftCorner = new Vector3(transform.position.x - bounds.x, transform.position.y - bounds.y, transform.position.z - bounds.z);
		var topFrontRightCorner = new Vector3(transform.position.x + bounds.x, transform.position.y - bounds.y, transform.position.z + bounds.z);
		var topRearRightCorner = new Vector3(transform.position.x + bounds.x, transform.position.y - bounds.y, transform.position.z - bounds.z);
		var bottomFrontLeftCorner = new Vector3(transform.position.x - bounds.x, transform.position.y + bounds.y, transform.position.z + bounds.z);
		var bottomRearLeftCorner = new Vector3(transform.position.x - bounds.x, transform.position.y + bounds.y, transform.position.z - bounds.z);
		var bottomFrontRightCorner = new Vector3(transform.position.x + bounds.x, transform.position.y + bounds.y, transform.position.z + bounds.z);
		var bottomRearRightCorner = new Vector3(transform.position.x + bounds.x, transform.position.y + bounds.y, transform.position.z - bounds.z);

		var topFrontLeftPoint = Camera.main.WorldToViewportPoint(topFrontLeftCorner);
		var topRearLeftPoint = Camera.main.WorldToViewportPoint(topRearLeftCorner);
		var topFrontRightPoint = Camera.main.WorldToViewportPoint(topFrontRightCorner);
		var topRearRightPoint = Camera.main.WorldToViewportPoint(topRearRightCorner);
		var bottomFrontLeftPoint = Camera.main.WorldToViewportPoint(bottomFrontLeftCorner);
		var bottomRearLeftPoint = Camera.main.WorldToViewportPoint(bottomRearLeftCorner);
		var bottomFrontRightPoint = Camera.main.WorldToViewportPoint(bottomFrontRightCorner);
		var bottomRearRightPoint = Camera.main.WorldToViewportPoint(bottomRearRightCorner);

		if (Camera.main.rect.Contains(topFrontLeftPoint) &&
			Camera.main.rect.Contains(topRearLeftPoint) &&
			Camera.main.rect.Contains(bottomFrontLeftPoint) &&
			Camera.main.rect.Contains(bottomRearLeftPoint) &&
			Camera.main.rect.Contains(topFrontRightPoint) &&
			Camera.main.rect.Contains(topRearRightPoint) &&
			Camera.main.rect.Contains(bottomFrontRightPoint) &&
			Camera.main.rect.Contains(bottomRearRightPoint))
		{
			wasVisible = true;
		}

		if (Camera.main.rect.Contains(topFrontLeftPoint) == false &&
			Camera.main.rect.Contains(topRearLeftPoint) == false &&
			Camera.main.rect.Contains(bottomFrontLeftPoint) == false &&
			Camera.main.rect.Contains(bottomRearLeftPoint) == false &&
			Camera.main.rect.Contains(topFrontRightPoint) == false &&
			Camera.main.rect.Contains(topRearRightPoint) == false &&
			Camera.main.rect.Contains(bottomFrontRightPoint) == false &&
			Camera.main.rect.Contains(bottomRearRightPoint) == false)
		{
			if (wasVisible)
			{
				wasVisible = false;
				transform.position = initialPosition;
			}
		}
	}
}
