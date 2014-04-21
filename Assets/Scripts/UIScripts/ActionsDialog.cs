using UnityEngine;
using System.Collections;

public class ActionsDialog : MonoBehaviour {
	public GUISkin g;

	float pic_width = 70;
	int act_winID = 2142;

	float width_buffer = 20;
	TradeDialog td;
	PlayerScript current_player;
	
	private TurnControllerScript turnController;

	public static bool show_act = false;
	bool devCardMenu = false;
	
	void Start() {
		turnController = GameObject.Find("TurnController").GetComponent<TurnControllerScript>();
	}
	
	// Use this for initialization
	void OnGUI () {
		GUI.skin = g;
		//Background
		if (show_act){
			GUI.ModalWindow (act_winID, new Rect (Screen.width / 10, Screen.height / 10, Screen.width * 4 / 5, Screen.height * 4 / 5), ModalContents, "Actions");
		}
			
	}
	
	void ModalContents (int windowID)
	{
		current_player = GameObject.Find(turnController.currentPlayer).GetComponent<PlayerScript>();
		GUILayout.BeginArea (new Rect (Screen.width / 10, Screen.height / 10, Screen.width * 3 / 5, Screen.height * 4 / 5));
		GUILayout.BeginVertical ();

		if (!devCardMenu) {
				if (GUILayout.Button ("Build", GUILayout.Height (Screen.height * 3 / 25))) {
						BuildDialog.show ();
						hide ();
				}
				if (GUILayout.Button ("Trade with Player", GUILayout.Height (Screen.height * 3 / 25))) {
						TradeDialog.show ();
						hide ();
				}
			if (current_player.brick >= current_player.brickTradeIn || current_player.sheep >= current_player.sheepTradeIn || current_player.wheat >= current_player.wheatTradeIn || current_player.wood >= current_player.woodTradeIn || current_player.ore >= current_player.oreTradeIn) {
						if (GUILayout.Button ("Exchange With Bank", GUILayout.Height (Screen.height * 3 / 25))) {
								ExchangeDialog.show ();
								hide ();
						}
				}
				if (current_player.knightDevCard > 0 || current_player.victoryDevCard > 0 || current_player.yearOfPlentyDevCard > 0 || current_player.monopolyDevCard > 0 || current_player.roadBuildingDevCard > 0) {
						if (GUILayout.Button ("Play Development Card", GUILayout.Height (Screen.height * 3 / 25))) {
							devCardMenu = true;
						}
				}
				
		}
		else{
			if (current_player.knightDevCard > 0) {
				if (GUILayout.Button ("Play Knight Card", GUILayout.Height (Screen.height * 3 / 25))) {

				}
			}
			if (current_player.yearOfPlentyDevCard > 0){
				if (GUILayout.Button ("Play Year of Plenty", GUILayout.Height (Screen.height * 3 / 25))) {

				}
			}

			if(current_player.monopolyDevCard > 0) {
				if (GUILayout.Button ("Play Monopoly Card", GUILayout.Height (Screen.height * 3 / 25))) {
					
				}
			}

			if(current_player.roadBuildingDevCard > 0){
				if (GUILayout.Button ("Play Road Building", GUILayout.Height (Screen.height * 3 / 25))) {
					
				}
			}
		}
		if (GUILayout.Button ("Cancel", GUILayout.Height (Screen.height * 3 / 25))) {
			hide ();
			devCardMenu = false;
		}
		GUILayout.EndVertical ();
		GUILayout.EndArea ();
	}
	
	public static void show (){
		show_act = true;
	}
	
	public static void hide (){
		show_act = false;
	}
}
