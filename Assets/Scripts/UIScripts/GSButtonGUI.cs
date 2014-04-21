using UnityEngine;
using System.Collections;

public class GSButtonGUI : MonoBehaviour {
	public GUISkin g;
	float width_buffer = 20;
	public float button_height = Screen.height* 3 /25;
	public bool show;
	public static bool show_next_turn;
	int snt_winID = 4992;

	private bool turnStart = true;
	private bool rolled = false;
	private bool playknight = false;

	private TurnControllerScript turnController;

	private DiceRollScript dice;
	
	private PlayerScript player1;
	private PlayerScript player2;
	private PlayerScript player3;
	private PlayerScript player4;

	private CameraControler cc;
	private bool settlement = true;
	

	void Start() {
		show = true;
		turnController = GameObject.Find("TurnController").GetComponent<TurnControllerScript>();
		dice = GameObject.Find("Dice").GetComponent<DiceRollScript>();
		
		player1 = GameObject.Find("Player1").GetComponent<PlayerScript>();
		player2 = GameObject.Find("Player2").GetComponent<PlayerScript>();
		player3 = GameObject.Find("Player3").GetComponent<PlayerScript>();
		player4 = GameObject.Find("Player4").GetComponent<PlayerScript>();

		show_next_turn = false;
		cc = Camera.main.GetComponent<CameraControler> ();
	}

	void OnGUI () 
	{
		GUI.skin = g;
		if (!turnController.initialComplete){
			
			
			if (settlement){
				GUILayout.BeginArea(new Rect(0, Screen.height -button_height, Screen.width, button_height));
				GUILayout.Box(turnController.currentPlayer +": Select a position to place a settlement", GUILayout.ExpandHeight(true));
				GUILayout.EndArea();
				if(cc.selectedObject != null && cc.selectedObject.tag == "Settlement"){
					
					if(cc.selectedObject.GetComponent<SettlementScript>().buildInitial()){
						if(turnController.reverse == true)
						{
							cc.selectedObject.GetComponent<SettlementScript>().initialResources();
						}
						settlement = false;
					}
					cc.selectedObject = null;
					
					
				}
				
			}
			else {
				GUILayout.BeginArea(new Rect(0, Screen.height -button_height, Screen.width, button_height));
				GUILayout.Box(turnController.currentPlayer +": Select a position to place a road", GUILayout.ExpandHeight(true));
				GUILayout.EndArea();
				if(cc.selectedObject != null && cc.selectedObject.tag == "Road"){
					
					if(cc.selectedObject.GetComponent<RoadScript>().buildInitial()){
						turnController.initialNextTurn();
						settlement = true;
					}
					cc.selectedObject = null;
					
					
				}
			}
		}
		else if(show)
		{


			if(turnStart)
			{
				if(rolled == false)
				{
					if(playknight == true)
					{
						if(GUI.Button(new Rect(Screen.width/2,Screen.height-button_height,Screen.width/2,button_height), "Cancel")) {
							playknight = false;
						}

						GUILayout.BeginArea(new Rect(0, Screen.height -button_height, Screen.width, button_height));
						GUILayout.Box(turnController.currentPlayer +": Select a position to place the knight", GUILayout.ExpandHeight(true));
						GUILayout.EndArea();

						if(cc.selectedObject != null && string.Equals(cc.selectedObject.name, "Hex"))
						{
							if(cc.selectedObject.GetComponent<Hex>().blocked == false)
							{
								GameObject[] objects = GameObject.FindObjectsOfType<GameObject>();
								
								foreach(GameObject obj in objects)
								{
									if(string.Equals(obj.name, "Hex"))
									{
										if(obj.GetComponent<Hex>().tileType != TileType.Desert)
										{
											obj.GetComponent<Hex>().blocked = false;
										}
									}
								}
								
								cc.selectedObject.GetComponent<Hex>().blocked = true;
								GameObject robber = GameObject.Find("Robber");
								robber.transform.position = cc.selectedObject.transform.position;
								GameObject.Find(turnController.currentPlayer).GetComponent<PlayerScript>().knightDevCard--;
								playknight = false;
							}
						}
					}
					else
					{
						if(GameObject.Find(turnController.currentPlayer).GetComponent<PlayerScript>().knightDevCard > 0)
						{
							if(GUI.Button(new Rect(0,Screen.height-button_height,Screen.width/2,button_height), "Play Knight")) 
							{
								cc.selectedObject = null;
								playknight = true;

							}
						}

						if(GUI.Button(new Rect(Screen.width/2,Screen.height-button_height,Screen.width/2,button_height), turnController.currentPlayer +": Roll Dice")) {
							if(dice.roll() == 7)
							{
								cc.selectedObject = null;
								discard();
							}

							rolled = true;
						}
					}
				}
				else
				{
					if(dice.diceRoll == 7)
					{
						GUILayout.BeginArea(new Rect(0, Screen.height -button_height, Screen.width, button_height));
						GUILayout.Box(turnController.currentPlayer +": Select a position to place the robber", GUILayout.ExpandHeight(true));
						GUILayout.EndArea();

						if(cc.selectedObject != null && string.Equals(cc.selectedObject.name, "Hex"))
						{
							if(cc.selectedObject.GetComponent<Hex>().blocked == false)
							{
								GameObject[] objects = GameObject.FindObjectsOfType<GameObject>();

								foreach(GameObject obj in objects)
								{
									if(string.Equals(obj.name, "Hex"))
									{
										if(obj.GetComponent<Hex>().tileType != TileType.Desert)
										{
											obj.GetComponent<Hex>().blocked = false;
										}
									}
								}

								cc.selectedObject.GetComponent<Hex>().blocked = true;
								GameObject robber = GameObject.Find("Robber");
								robber.transform.position = cc.selectedObject.transform.position;

								turnStart = false;
								rolled = false;
							}
						}
					}
					else
					{
						turnStart = false;
						rolled = false;
					}
				}
			}
			else
			{
				if(GUI.Button(new Rect(0,Screen.height-button_height,Screen.width/2,button_height), "Actions")) {
						//CALL ACTION SCREEN
						ActionsDialog.show();
					}
					
				// Make the second button.
				if(GUI.Button(new Rect(Screen.width/2,Screen.height-button_height,Screen.width/2,button_height), "End Turn")) {
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
		if(player1.handSize > 7){
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
		}
		
		half = player2.handSize / 2;

		if(player2.handSize > 7){
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
		}

		half = player3.handSize / 2;

		if(player3.handSize>7){
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
		}
		
		half = player4.handSize / 2;

		if(player4.handSize > 7){
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
}
