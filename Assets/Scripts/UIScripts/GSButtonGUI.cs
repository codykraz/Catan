using UnityEngine;
using System.Collections;

public class GSButtonGUI : MonoBehaviour {

	float width_buffer = 20;
	float button_height = Screen.height* 3 /25;
	public static bool show;
	public static bool show_next_turn;
	TurnControllerScript turnController;
	int snt_winID = 4992;

	void Start() {
		show = true;
		show_next_turn = false;
	}

	void OnGUI () 
	{

		if(show)
		{
			// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
			if(GUI.Button(new Rect(width_buffer,Screen.height-(button_height+width_buffer),Screen.width/2-3*width_buffer/2,button_height), "Actions")) {
					//CALL ACTION SCREEN
					ActionsDialog.show();
				}
				
			// Make the second button.
			if(GUI.Button(new Rect(Screen.width/2+width_buffer/2,Screen.height-(button_height+width_buffer),Screen.width/2-3*width_buffer/2,button_height), "End Turn")) {
				//CALL END TURN FUNCTION
				turnController = turnController = GameObject.Find("TurnController").GetComponent<TurnControllerScript>();
				turnController.nextTurn();

				show_next_turn = true;
			}
			if(show_next_turn)
			{
				GUI.ModalWindow (snt_winID, new Rect (Screen.width / 5, Screen.height / 3, Screen.width * 3 / 5, Screen.height / 3), turnModalContents, "New Turn");
			}
		}
	}

	void turnModalContents (int windowID)
	{
		if(GUI.Button(new Rect(Screen.width/10,Screen.height*1/12,Screen.width*2/5,Screen.height*1/6), turnController.currentPlayer + "'s Turn")) {
			//END GAME FUNCTION
			show_next_turn = false;
		}
	}
}
