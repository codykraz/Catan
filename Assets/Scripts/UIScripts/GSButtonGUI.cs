using UnityEngine;
using System.Collections;

public class GSButtonGUI : MonoBehaviour {

	float width_buffer = 20;
	float button_height = Screen.height* 3 /25;
	public static bool show;

	void Start() {
		show = true;
	}

	void OnGUI () {

		if(show){
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(width_buffer,Screen.height-(button_height+width_buffer),Screen.width/2-3*width_buffer/2,button_height), "Actions")) {
				//CALL ACTION SCREEN
				ActionsDialog.show();
			}
			
			// Make the second button.
			if(GUI.Button(new Rect(Screen.width/2+width_buffer/2,Screen.height-(button_height+width_buffer),Screen.width/2-3*width_buffer/2,button_height), "End Turn")) {
				//CALL END TURN FUNCTION
				VictoryDialog.show();
			}
		}
	}
}
