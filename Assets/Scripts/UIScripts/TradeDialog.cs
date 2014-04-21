using UnityEngine;
using System.Collections;

public class TradeDialog : MonoBehaviour {

	int trd_winID = 5293;
	private TurnControllerScript turnController;
	private bool show_trd;

	PlayerScript current_player, partner;	
	public string[] playerList;
	int iterator, ignore;

	Texture wood_resource_tex, brick_resource_tex, ore_resource_tex, wheat_resource_tex, sheep_resource_tex;
	
	void Start() {
		turnController = GameObject.Find("TurnController").GetComponent<TurnControllerScript>();
		
		wood_resource_tex = GameObjectManager.GetTileTexture ("Wood");
		brick_resource_tex = GameObjectManager.GetTileTexture ("Brick");
		ore_resource_tex = GameObjectManager.GetTileTexture ("Ore");
		wheat_resource_tex = GameObjectManager.GetTileTexture ("Wheat");
		sheep_resource_tex = GameObjectManager.GetTileTexture ("Sheep");

		show_trd = false;

		playerList = new string[] {"Player1", "Player2", "Player3", "Player4"};
	}
	// Use this for initialization
	void OnGUI () {
		//Background
		if (show_trd){
			GUI.ModalWindow (trd_winID, new Rect (Screen.width / 10, Screen.height *8/ 30, Screen.width * 4 / 5, Screen.height * 7 / 15), ModalContents, "Trade Window");
		}
	}

	void ModalContents (int windowID)
	{
		current_player = GameObject.Find(turnController.currentPlayer).GetComponent<PlayerScript>();
		//partner = GameObject.Find ().GetComponent<PlayerScript> ();
	}

	public void show (){
		show_trd = true;
		switch(turnController.currentPlayer)
		{
			case "Player1":
				playerList = new string[] {"Player2", "Player3", "Player4"};
				break;
			case "Player2":
				playerList = new string[] {"Player1", "Player3", "Player4"};
				break;
			case "Player3":
				playerList = new string[] {"Player1", "Player2", "Player4"};
				break;
			case "Player4":
				playerList = new string[] {"Player1", "Player2", "Player3"};
				break;
			default:
				break;
		}
	}
	
	public void hide (){
		show_trd = false;
	}
}
