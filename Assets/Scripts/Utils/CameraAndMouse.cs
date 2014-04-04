using UnityEngine;
using System.Collections;

public enum CameraPos {
	FromX,
	FromY,
	FromZ
}

public class CameraToMouse : MonoBehaviour {
	
	public static Vector3 GetMouseFromCameraPos(CameraPos camPos) {
		if (camPos == CameraPos.FromX)
			return GetMousePositionXZero();
		else if (camPos == CameraPos.FromY)
			return CameraToMouse.GetMousePositionYZero();
		else
			return CameraToMouse.GetMousePositionZZero();
	}

	public static Vector3 GetMousePositionXZero() {
		if (Camera.main != null) {
			Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(
				Input.mousePosition.x,
				Input.mousePosition.y, 
				Camera.main.transform.position.x
				));
			return new Vector3(0f, pos.y, pos.z);
		}
		else {
			return Vector3.zero;
		}
	}
	
	public static Vector3 GetMousePositionYZero() {
		if (Camera.main != null) {
			Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(
				Input.mousePosition.x,
				Input.mousePosition.y, 
				Camera.main.transform.position.y
				));
			return new Vector3(pos.x, 0f, pos.z);
		}
		else {
			return Vector3.zero;
		}
	}
	
	public static Vector3 GetMousePositionZZero() {
		if (Camera.main != null) {
			Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(
				Input.mousePosition.x,
				Input.mousePosition.y, 
				Camera.main.transform.position.z
				));
			return new Vector3(pos.x, pos.y, 0f);
		}
		else {
			return Vector3.zero;
		}
	}
}
