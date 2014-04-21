using UnityEngine;
using System.Collections;

public class GSButtonGUI : MonoBehaviour {

	float width_buffer = 20;
	float button_height = Screen.height* 3 /25;
	public static bool show;

	private bool turnStart = true;
	private bool robber = false;

	private TurnControllerScript turnController;

	private DiceRollScript dice;

	private PlayerScript player1;
	private PlayerScript player2;
	private PlayerScript player3;
	private PlayerScript player4;

	void Start() {
		show = true;
		turnController = GameObject.Find("TurnController").GetComponent<TurnControllerScript>();

		dice = GameObject.Find("Dice").GetComponent<DiceRollScript>();

		player1 = GameObject.Find("Player1").GetComponent<PlayerScript>();
		player2 = GameObject.Find("Player2").GetComponent<PlayerScript>();
		player3 = GameObject.Find("Player3").GetComponent<PlayerScript>();
		player4 = GameObject.Find("Player4").GetComponent<PlayerScript>();
	}

	void OnGUI () {
		if(player1.victoryPoints >= 10)
		{
			VictoryDialog.show();
			return;
		}
		else if(player2.victoryPoints >= 10)
		{
			VictoryDialog.show();
			return;
		}
		else if(player3.victoryPoints >= 10)
		{
			VictoryDialog.show();
			return;
		}
		else if(player4.victoryPoints >= 10)
		{
			VictoryDialog.show();
			return;
		}

		if(turnController.initialComplete == false)
		{



			//Do setup stuff here


			turnController.initialNextTurn();





		}
		else
		{
			if(robber == true)
			{








				//ROBBER STUFF HERE
				robber = false;








			}
			else if(turnStart == true)
			{
				if(GUI.Button(new Rect(width_buffer,Screen.height-(button_height+width_buffer),Screen.width/2-3*width_buffer/2,button_height), "Play Knight")) {






					//PLAY KNIGHT HERE







				}
				
				// Make the second button.
				if(GUI.Button(new Rect(Screen.width/2+width_buffer/2,Screen.height-(button_height+width_buffer),Screen.width/2-3*width_buffer/2,button_height), "Roll Dice")) {
					if(dice.roll() == 7)
					{
						robber = true;
					}

					turnStart = false;
				}
			}
			else
			{
				if(show){
					if(GUI.Button(new Rect(width_buffer,Screen.height-(button_height+width_buffer),Screen.width/2-3*width_buffer/2,button_height), "Actions")) {
						ActionsDialog.show();
					}

					if(GUI.Button(new Rect(Screen.width/2+width_buffer/2,Screen.height-(button_height+width_buffer),Screen.width/2-3*width_buffer/2,button_height), "End Turn")) {
						turnController.nextTurn();
						turnStart = true;
					}
				}
			}
		}
	}
}
