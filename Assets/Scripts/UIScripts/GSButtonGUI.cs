using UnityEngine;
using System.Collections;

public class GSButtonGUI : MonoBehaviour {

	void OnGUI () {
		float width_buffer = 20;
		float button_height = 50;

		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(width_buffer,Screen.height-(button_height+width_buffer),Screen.width/2-3*width_buffer/2,button_height), "Actions")) {
			//CALL ACTION SCREEN
		}
		
		// Make the second button.
		if(GUI.Button(new Rect(Screen.width/2+width_buffer/2,Screen.height-(button_height+width_buffer),Screen.width/2-3*width_buffer/2,button_height), "End Turn")) {
			//CALL END TURN FUNCTION
		}
	}
}
