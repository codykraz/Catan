using UnityEngine;
using System.Collections;

public class ScoreGUI : MonoBehaviour {

	private Texture2D victoryPointsTex;

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

		victoryPointsTex = new Texture2D(10, 10);
		
		turnController = turnController = GameObject.Find("TurnController").GetComponent<TurnControllerScript>();

		if(turnController.currentPlayer == "Player1")
		{
			currentPlayer = player1;
		}
		else if(turnController.currentPlayer == "Player2")
		{
			currentPlayer = player2;
		}
		else if(turnController.currentPlayer == "Player3")
		{
			currentPlayer = player3;
		}
		else if(turnController.currentPlayer == "Player4")
		{
			currentPlayer = player4;
		}
	}

	void OnGUI () {

		GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height / 10));
		GUILayout.BeginHorizontal();

		GUILayout.Space(10);

		GUILayout.Label(GameObjectManager.GetTileTexture("Wood"), GUILayout.Width(30));
		GUILayout.Label(currentPlayer.wood.ToString());
		GUILayout.Label(GameObjectManager.GetTileTexture("Ore"), GUILayout.Width(30));
		GUILayout.Label(currentPlayer.ore.ToString());
		GUILayout.Label(GameObjectManager.GetTileTexture("Brick"), GUILayout.Width(30));
		GUILayout.Label(currentPlayer.brick.ToString());
		GUILayout.Label(GameObjectManager.GetTileTexture("Wheat"), GUILayout.Width(30));
		GUILayout.Label(currentPlayer.wheat.ToString());
		GUILayout.Label(GameObjectManager.GetTileTexture("Sheep"), GUILayout.Width(30));
		GUILayout.Label(currentPlayer.sheep.ToString());

		GUILayout.BeginVertical();




		GUILayout.EndVertical();
		GUILayout.EndHorizontal();
		GUILayout.EndArea();
	}
}
