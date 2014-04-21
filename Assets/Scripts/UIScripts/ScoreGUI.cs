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
		GUIContent content = new GUIContent(currentPlayer.wood.ToString(), GameObjectManager.GetTileTexture("Wood"));
		GUILayout.Label(content, GUILayout.Width(Screen.width / 10));
		content.text = currentPlayer.ore.ToString();
		content.image = GameObjectManager.GetTileTexture("Ore");

		GUILayout.Label(content, GUILayout.Width(Screen.width / 10));
		content.text = currentPlayer.brick.ToString();
		content.image = GameObjectManager.GetTileTexture("Brick");
		GUILayout.Label(content, GUILayout.Width(Screen.width / 10));
		content.text = currentPlayer.wheat.ToString();
		content.image = GameObjectManager.GetTileTexture("Wheat");
		GUILayout.Label(content, GUILayout.Width(Screen.width / 10));
		content.text = currentPlayer.sheep.ToString();
		content.image = GameObjectManager.GetTileTexture("Sheep");
		GUILayout.Label(content, GUILayout.Width(Screen.width / 10));

		/*GUILayout.Label(GameObjectManager.GetTileTexture("Brick"), GUILayout.Width(Screen.width / 10));
		GUILayout.Label(currentPlayer.brick.ToString());
		GUILayout.Label(GameObjectManager.GetTileTexture("Wheat"), GUILayout.Width(Screen.width / 10));
		GUILayout.Label(currentPlayer.wheat.ToString());
		GUILayout.Label(GameObjectManager.GetTileTexture("Sheep"), GUILayout.Width(Screen.width / 10));
		GUILayout.Label(currentPlayer.sheep.ToString());*/

		GUILayout.BeginVertical();




		GUILayout.EndVertical();
		GUILayout.EndHorizontal();
		GUILayout.EndArea();
	}
}
