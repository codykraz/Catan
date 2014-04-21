using UnityEngine;
using System.Collections;

public class ScoreGUI : MonoBehaviour {
	public GUISkin g;

	public Texture2D victoryPointsTex;

	private PlayerScript player1;
	private PlayerScript player2;
	private PlayerScript player3;
	private PlayerScript player4;

	private PlayerScript currentPlayer;
	private DiceRollScript die;

	private TurnControllerScript turnController;
	

	void Start() 
	{
		player1 = GameObject.Find("Player1").GetComponent<PlayerScript>();
		player2 = GameObject.Find("Player2").GetComponent<PlayerScript>();
		player3 = GameObject.Find("Player3").GetComponent<PlayerScript>();
		player4 = GameObject.Find("Player4").GetComponent<PlayerScript>();

		turnController = GameObject.Find("TurnController").GetComponent<TurnControllerScript>();
		die = GameObject.Find ("Dice").GetComponent<DiceRollScript> ();

	}

	void OnGUI () {
		GUI.skin = g;
		float resources_box_width = Screen.width*3/4;
		float resources_box_unit = resources_box_width/26;
		if(string.Equals(turnController.currentPlayer, "Player1"))
		{
			currentPlayer = player1;
		}
		else if(string.Equals(turnController.currentPlayer, "Player2"))
		{
			currentPlayer = player2;
		}
		else if(string.Equals(turnController.currentPlayer, "Player3"))
		{
			currentPlayer = player3;
		}
		else if(string.Equals(turnController.currentPlayer, "Player4"))
		{
			currentPlayer = player4;
		}
		GUI.Box (new Rect (0,0,Screen.width,resources_box_unit*8),"");

		GUI.contentColor = Color.white;
		GUI.Label (new Rect (resources_box_unit*0, 0, resources_box_unit*5, resources_box_unit*5), GameObjectManager.GetTileTexture("Wood"));
		GUI.Label (new Rect (resources_box_unit*5, 0, resources_box_unit*5, resources_box_unit*5), GameObjectManager.GetTileTexture("Ore"));
		GUI.Label (new Rect (resources_box_unit*10, 0, resources_box_unit*5, resources_box_unit*5), GameObjectManager.GetTileTexture("Brick"));
		GUI.Label (new Rect (resources_box_unit*15, 0, resources_box_unit*5, resources_box_unit*5), GameObjectManager.GetTileTexture("Wheat"));
		GUI.Label (new Rect (resources_box_unit*20, 0, resources_box_unit*5, resources_box_unit*5), GameObjectManager.GetTileTexture("Sheep"));
		GUI.contentColor = currentPlayer.playerColor;
		GUI.Label (new Rect (resources_box_unit*0, 0, resources_box_unit*5, resources_box_unit*5), currentPlayer.wood.ToString()+ "\nWood\nX:"+currentPlayer.woodTradeIn);
		GUI.Label (new Rect (resources_box_unit*5, 0, resources_box_unit*5, resources_box_unit*5), currentPlayer.ore.ToString()+ "\nOre\nX:"+currentPlayer.oreTradeIn);
		GUI.Label (new Rect (resources_box_unit*10, 0, resources_box_unit*5, resources_box_unit*5), currentPlayer.brick.ToString()+"\nBrick\nX:"+currentPlayer.brickTradeIn);
		GUI.Label (new Rect (resources_box_unit*15, 0, resources_box_unit*5, resources_box_unit*5), currentPlayer.wheat.ToString()+"\nWheat\nX:"+currentPlayer.wheatTradeIn);
		GUI.Label (new Rect (resources_box_unit*20, 0, resources_box_unit*5, resources_box_unit*5), currentPlayer.sheep.ToString()+"\nSheep\nX:"+currentPlayer.sheepTradeIn);


		if (die.diceRoll != -1){
			GUI.Label (new Rect (Screen.width-resources_box_unit*5, 0, resources_box_unit*5, resources_box_unit*5), "Roll:");
			GUI.Label (new Rect (Screen.width-resources_box_unit*5, resources_box_unit*5, resources_box_unit*5, resources_box_unit*5), die.diceRoll.ToString());
		}

		// Current player's score on top right
		float score_box_width = Screen.width*1/4;
		float score_box_unit = score_box_width/10;
		
		//GUI.Box (new Rect (Screen.width - score_box_width, -5, score_box_width+5, 15+score_box_unit*17), "");

		GUI.contentColor = player1.playerColor;
		GUI.Label (new Rect (resources_box_unit*2, resources_box_unit*5, resources_box_unit*5, resources_box_unit*5), player1.victoryPoints.ToString());
		GUI.Label (new Rect (resources_box_unit*0, resources_box_unit*5, resources_box_unit*5, resources_box_unit*5), victoryPointsTex);
		
		GUI.contentColor = player2.playerColor;
		GUI.Label (new Rect (resources_box_unit*7, resources_box_unit*5, resources_box_unit*5, resources_box_unit*5), player2.victoryPoints.ToString());
		GUI.Label (new Rect (resources_box_unit*5, resources_box_unit*5, resources_box_unit*5, resources_box_unit*5), victoryPointsTex);

		GUI.contentColor = player3.playerColor;
		GUI.Label (new Rect (resources_box_unit*12, resources_box_unit*5, resources_box_unit*5, resources_box_unit*5), player3.victoryPoints.ToString());
		GUI.Label (new Rect (resources_box_unit*10, resources_box_unit*5, resources_box_unit*5, resources_box_unit*5), victoryPointsTex);

		GUI.contentColor = player4.playerColor;
		GUI.Label (new Rect (resources_box_unit*17, resources_box_unit*5, resources_box_unit*5, resources_box_unit*5), player4.victoryPoints.ToString());
		GUI.Label (new Rect (resources_box_unit*15, resources_box_unit*5, resources_box_unit*5, resources_box_unit*5), victoryPointsTex);

		GUI.contentColor = Color.white;
	}
}
