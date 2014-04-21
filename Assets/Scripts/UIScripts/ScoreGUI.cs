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

	private TurnControllerScript turnController;
	

	void Start() 
	{
		player1 = GameObject.Find("Player1").GetComponent<PlayerScript>();
		player2 = GameObject.Find("Player2").GetComponent<PlayerScript>();
		player3 = GameObject.Find("Player3").GetComponent<PlayerScript>();
		player4 = GameObject.Find("Player4").GetComponent<PlayerScript>();

		turnController = GameObject.Find("TurnController").GetComponent<TurnControllerScript>();

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
	}

	void OnGUI () {
		GUI.skin = g;
		float resources_box_width = Screen.width*3/4;
		float resources_box_unit = resources_box_width/26;
		
		//GUI.Box (new Rect (-5,-5,Screen.width+10,resources_box_unit*6+10), "");
		
		GUI.Label (new Rect (resources_box_unit*1, 5, resources_box_unit*5, resources_box_unit*5), GameObjectManager.GetTileTexture("Wood"));
		GUI.Label (new Rect (resources_box_unit*1, 5, resources_box_unit*5, resources_box_unit*5), currentPlayer.wood.ToString());
		
		GUI.Label (new Rect (resources_box_unit*6, 5, resources_box_unit*5, resources_box_unit*5), GameObjectManager.GetTileTexture("Ore"));
		GUI.Label (new Rect (resources_box_unit*6, 5, resources_box_unit*5, resources_box_unit*5), currentPlayer.ore.ToString());
		
		GUI.Label (new Rect (resources_box_unit*11, 5, resources_box_unit*5, resources_box_unit*5), GameObjectManager.GetTileTexture("Brick"));
		GUI.Label (new Rect (resources_box_unit*11, 5, resources_box_unit*5, resources_box_unit*5), currentPlayer.brick.ToString());
		
		GUI.Label (new Rect (resources_box_unit*16, 5, resources_box_unit*5, resources_box_unit*5), GameObjectManager.GetTileTexture("Wheat"));
		GUI.Label (new Rect (resources_box_unit*16, 5, resources_box_unit*5, resources_box_unit*5), currentPlayer.wheat.ToString());
		
		GUI.Label (new Rect (resources_box_unit*21, 5, resources_box_unit*5, resources_box_unit*5), GameObjectManager.GetTileTexture("Sheep"));
		GUI.Label (new Rect (resources_box_unit*21, 5, resources_box_unit*5, resources_box_unit*5), currentPlayer.sheep.ToString());
		
		// Current player's score on top right
		float score_box_width = Screen.width*1/4;
		float score_box_unit = score_box_width/10;
		
		//GUI.Box (new Rect (Screen.width - score_box_width, -5, score_box_width+5, 15+score_box_unit*17), "");
		
		GUI.Label (new Rect (Screen.width - score_box_unit*8, 10 + score_box_unit*1, score_box_unit*4, score_box_unit*4), player1.victoryPoints.ToString());
		GUI.Label (new Rect (Screen.width - score_box_unit*4, 10 + score_box_unit*1, score_box_unit*4, score_box_unit*4), victoryPointsTex);
		
		// Other player's score's below that
		GUI.Label (new Rect (Screen.width - score_box_unit*8, 10 + score_box_unit*5, score_box_unit*4, score_box_unit*4), player2.victoryPoints.ToString());
		GUI.Label (new Rect (Screen.width - score_box_unit*4, 10 + score_box_unit*5, score_box_unit*4, score_box_unit*4), victoryPointsTex);
		
		GUI.Label (new Rect (Screen.width - score_box_unit*8, 10 + score_box_unit*9, score_box_unit*4, score_box_unit*4), player3.victoryPoints.ToString());
		GUI.Label (new Rect (Screen.width - score_box_unit*4, 10 + score_box_unit*9, score_box_unit*4, score_box_unit*4), victoryPointsTex);
		
		GUI.Label (new Rect (Screen.width - score_box_unit*8, 10 + score_box_unit*13, score_box_unit*4, score_box_unit*4), player4.victoryPoints.ToString());
		GUI.Label (new Rect (Screen.width - score_box_unit*4, 10 + score_box_unit*13, score_box_unit*4, score_box_unit*4), victoryPointsTex);
	}
}
