using UnityEngine;
using System.Collections;

public class ObjectGrabber : MonoBehaviour {
	public float dragFactor = 1f;
	public CameraPos cameraPosition = CameraPos.FromY;
	
	private Vector3 dragVector;
	private Vector3 mousePosition;
	private Vector3 prevMousePosition;
	private bool clicked = false;
	
	void Update () {
		dragVector = Vector3.zero;
		prevMousePosition = mousePosition;
		
		mousePosition = CameraToMouse.GetMouseFromCameraPos(cameraPosition);
		
		// On click, test mouse pos
		if (Input.GetMouseButtonDown(0)) {
			// Get mouse position
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			
			// Get object under mouse
			RaycastHit hit;
			Physics.Raycast(ray, out hit);
			
			// Test if object clicked is this gameObject
			if (hit.collider != null) {
				if (hit.collider.gameObject == gameObject)
					clicked = true;
				else
					clicked = false;
			}
		}
		
		// If dragging object, get mouse movement
		else if (Input.GetMouseButton(0) && clicked)
			dragVector = mousePosition - prevMousePosition;
		
		// On mouse release, unclick
		else if (Input.GetMouseButtonUp(0))
			clicked = false;
		
		// If object is clicked in this frame, update to mouse pos	
		if (dragVector != Vector3.zero) {
			if (rigidbody != null) {
				rigidbody.velocity = Vector3.zero;
				transform.position = mousePosition;
			}
		}
	}
}

