using UnityEngine;
using System.Collections;

public class CameraControler : MonoBehaviour
{
	private float panSpeed = .1f;

	private float xCenter = 27.5f;
	private float xRange = 27.5f;

	private float zCenter = 24;
	private float zRange = 24;
	
	private float fovMax = 90;
	private float fovMin = 15;

	private float zoomSpeed = 4;

	private float minPinchSpeed = 5;

	void Update()
	{
		if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
		{
			Vector2 deltaTouch = Input.GetTouch(0).deltaPosition;

			this.transform.Translate(-deltaTouch.x * panSpeed, 0, -deltaTouch.y * panSpeed);

			Vector3 position = this.transform.position;

			float multiplier = (fovMax - camera.fieldOfView) / (fovMax - fovMin);
			
			position.x = Mathf.Clamp(position.x, xCenter - (xRange * multiplier), xCenter + (xRange * multiplier));
			position.z = Mathf.Clamp(position.z, zCenter - (zRange * multiplier), zCenter - (zRange * multiplier));

			this.transform.position = position;
		}
		else if(Input.touchCount >= 2 && (Input.GetTouch(0).phase == TouchPhase.Moved  || Input.GetTouch(1).phase == TouchPhase.Moved))
		{
			float touch0Speed = Input.GetTouch(0).deltaPosition.magnitude / Input.GetTouch(0).deltaTime;
			float touch1Speed = Input.GetTouch(1).deltaPosition.magnitude / Input.GetTouch(1).deltaTime;

			if(touch0Speed >= minPinchSpeed && touch1Speed >= minPinchSpeed)
			{
				Vector2 currentDistance = Input.GetTouch(0).position - Input.GetTouch(1).position;
				Vector2 previousDistance = (Input.GetTouch(0).position - Input.GetTouch(0).deltaPosition) - (Input.GetTouch(1).position - Input.GetTouch(1).deltaPosition);

				float deltaTouch = currentDistance.magnitude - previousDistance.magnitude;

				if(deltaTouch < 1)
				{
					this.camera.fieldOfView = Mathf.Clamp(this.camera.fieldOfView + zoomSpeed, fovMin, fovMax);
				}
				else
				{
					this.camera.fieldOfView = Mathf.Clamp(this.camera.fieldOfView - zoomSpeed, fovMin, fovMax);
				}
			}
		}
	}
}
