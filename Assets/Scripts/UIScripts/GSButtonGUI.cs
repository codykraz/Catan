using UnityEngine;
using System.Collections;

public class GSButtonGUI : MonoBehaviour {

	float width_buffer = 20;
	float button_height = Screen.height* 3 /25;
	public static bool show;
	public static bool show_next_turn;
	int snt_winID = 4992;

	private bool turnStart = true;

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

		show_next_turn = false;
	}

	void OnGUI () 
	{

		if(show)
		{
			if(turnStart)
			{
				if(GameObject.Find(turnController.currentPlayer).GetComponent<PlayerScript>().knightDevCard > 0)
				{
					if(GUI.Button(new Rect(width_buffer,Screen.height-(button_height+width_buffer),Screen.width/2-3*width_buffer/2,button_height), "Play Knight")) {


						//PLAY KNIGHT


					}
				}

				if(GUI.Button(new Rect(Screen.width/2+width_buffer/2,Screen.height-(button_height+width_buffer),Screen.width/2-3*width_buffer/2,button_height), "Roll Dice")) {
					if(dice.roll() == 7)
					{
						discard();






						//ROBBER HAPPENES


					}

					turnStart = false;
				}
			}
			else
			{
				// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
				if(GUI.Button(new Rect(width_buffer,Screen.height-(button_height+width_buffer),Screen.width/2-3*width_buffer/2,button_height), "Actions")) {
						//CALL ACTION SCREEN
						ActionsDialog.show();
					}
					
				// Make the second button.
				if(GUI.Button(new Rect(Screen.width/2+width_buffer/2,Screen.height-(button_height+width_buffer),Screen.width/2-3*width_buffer/2,button_height), "End Turn")) {
					//CALL END TURN FUNCTION
					turnController.nextTurn();

					show_next_turn = true;
				}
				if(show_next_turn)
				{
					GUI.ModalWindow (snt_winID, new Rect (Screen.width / 5, Screen.height / 3, Screen.width * 3 / 5, Screen.height / 3), turnModalContents, turnController.currentPlayer + "'s Turn");
				}
			}
		}
	}

	void turnModalContents (int windowID)
	{
		if(GUI.Button(new Rect(Screen.width/10,Screen.height*1/12,Screen.width*2/5,Screen.height*1/6), "Continue")) {
			turnStart = true;
			show_next_turn = false;
		}
	}

	void discard()
	{
		int rand = 0;

		int half = player1.handSize / 2;

		while(player1.handSize > half)
		{
			rand = Random.Range(0, 5);
			
			if(rand == 0 && player1.wood > 0)
			{
				player1.wood--;
				player1.handSize--;
			}
			else if(rand == 1 && player1.ore > 0)
			{
				player1.ore--;
				player1.handSize--;
			}
			else if(rand == 2 && player1.sheep > 0)
			{
				player1.sheep--;
				player1.handSize--;
			}
			else if(rand == 3 && player1.wheat > 0)
			{
				player1.wheat--;
				player1.handSize--;
			}
			else if(rand == 4 && player1.brick > 0)
			{
				player1.brick--;
				player1.handSize--;
			}
		}
		
		half = player2.handSize / 2;
		
		while(player2.handSize > half)
		{
			rand = Random.Range(0, 5);
			
			if(rand == 0 && player2.wood > 0)
			{
				player2.wood--;
				player2.handSize--;
			}
			else if(rand == 1 && player2.ore > 0)
			{
				player2.ore--;
				player2.handSize--;
			}
			else if(rand == 2 && player2.sheep > 0)
			{
				player2.sheep--;
				player2.handSize--;
			}
			else if(rand == 3 && player2.wheat > 0)
			{
				player2.wheat--;
				player2.handSize--;
			}
			else if(rand == 4 && player2.brick > 0)
			{
				player2.brick--;
				player2.handSize--;
			}
		}

		half = player3.handSize / 2;
		
		while(player3.handSize > half)
		{
			rand = Random.Range(0, 5);
			
			if(rand == 0 && player3.wood > 0)
			{
				player3.wood--;
				player3.handSize--;
			}
			else if(rand == 1 && player3.ore > 0)
			{
				player3.ore--;
				player3.handSize--;
			}
			else if(rand == 2 && player3.sheep > 0)
			{
				player3.sheep--;
				player3.handSize--;
			}
			else if(rand == 3 && player3.wheat > 0)
			{
				player3.wheat--;
				player3.handSize--;
			}
			else if(rand == 4 && player3.brick > 0)
			{
				player3.brick--;
				player3.handSize--;
			}
		}
		
		half = player4.handSize / 2;
		
		while(player4.handSize > half)
		{
			rand = Random.Range(0, 5);
			
			if(rand == 0 && player4.wood > 0)
			{
				player4.wood--;
				player4.handSize--;
			}
			else if(rand == 1 && player4.ore > 0)
			{
				player4.ore--;
				player4.handSize--;
			}
			else if(rand == 2 && player4.sheep > 0)
			{
				player4.sheep--;
				player4.handSize--;
			}
			else if(rand == 3 && player4.wheat > 0)
			{
				player4.wheat--;
				player4.handSize--;
			}
			else if(rand == 4 && player4.brick > 0)
			{
				player4.brick--;
				player4.handSize--;
			}
		}
	}
}
