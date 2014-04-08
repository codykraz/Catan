using UnityEngine;
using System.Collections;

public class GSButtonGUI : MonoBehaviour {

	float width_buffer = 20;
	float button_height = 50;
	bool show_actions;

	void Start() {
		show_actions = false;
	}

	void OnGUI () {

		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(width_buffer,Screen.height-(button_height+width_buffer),Screen.width/2-3*width_buffer/2,button_height), "Actions")) {
			//CALL ACTION SCREEN
			show_actions = true;
		}

		if (show_actions) {
			GUI.ModalWindow (1094, new Rect (Screen.width/5, Screen.height/3, Screen.width*3/5, Screen.height/3), ActionModalContents,"Actions");		
		}
		
		// Make the second button.
		if(GUI.Button(new Rect(Screen.width/2+width_buffer/2,Screen.height-(button_height+width_buffer),Screen.width/2-3*width_buffer/2,button_height), "End Turn")) {
			//CALL END TURN FUNCTION
			VictoryDialog.show();
		}
	}

	void ActionModalContents (int windowID)
	{
		if(GUI.Button(new Rect(Screen.width/10,Screen.height*1/12,Screen.width*2/5,Screen.height*1/6), "Actions here")) {
			//END GAME FUNCTION
			show_actions = false;
		}
	}
}
