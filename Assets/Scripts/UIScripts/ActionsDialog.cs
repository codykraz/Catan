using UnityEngine;
using System.Collections;

public enum actions{menu, devCard, yop, mono, rb};

public class ActionsDialog : MonoBehaviour {
	public GUISkin g;

	float pic_width = 70;
	int act_winID = 2142;

	float width_buffer = 20;
	TradeDialog td;
	PlayerScript current_player;
	int toGain = 0;
	
	private TurnControllerScript turnController;

	public static bool show_act = false;
	actions Amenu = actions.menu;
	
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

	void monopoly(TileType t){
		GameObject[] players = GameObject.FindGameObjectsWithTag ("Player");
		int res;
		for (int i = 0; i < 4; i++) {
			//players[i].GetComponent<PlayerScript>().
		}
	}
	
	void ModalContents (int windowID)
	{
		current_player = GameObject.Find(turnController.currentPlayer).GetComponent<PlayerScript>();
		GUILayout.BeginArea (new Rect (Screen.width / 10, Screen.height / 10, Screen.width * 3 / 5, Screen.height * 4 / 5));
		GUILayout.BeginVertical ();

		if (Amenu == actions.menu) {
				if (GUILayout.Button ("Build", GUILayout.Height (Screen.height * 3 / 25))) {
						BuildDialog.show ();
						hide ();
				}
				if (GUILayout.Button ("Trade with Player", GUILayout.Height (Screen.height * 3 / 25))) {
						TradeDialog.show ();
						hide ();
				}
				if (current_player.brick >= 4 || current_player.sheep >= 4 || current_player.wheat >= 4 || current_player.wood >= 4 || current_player.ore >= 4) {
						if (GUILayout.Button ("Exchange With Bank", GUILayout.Height (Screen.height * 3 / 25))) {
								ExchangeDialog.show ();
								hide ();
						}
				}
				if (current_player.knightDevCard > 0 || current_player.victoryDevCard > 0 || current_player.yearOfPlentyDevCard > 0 || current_player.monopolyDevCard > 0 || current_player.roadBuildingDevCard > 0) {
						if (GUILayout.Button ("Play Development Card", GUILayout.Height (Screen.height * 3 / 25))) {
							Amenu = actions.devCard;
						}
				}
			if (GUILayout.Button ("Cancel", GUILayout.Height (Screen.height * 3 / 25))) {
				hide ();
				Amenu = actions.menu;
			}
				
		}
		else if (Amenu == actions.devCard){
			if (current_player.knightDevCard > 0) {
				if (GUILayout.Button ("Play Knight Card", GUILayout.Height (Screen.height * 3 / 25))) {

				}
			}
			if (current_player.yearOfPlentyDevCard > 0){
				if (GUILayout.Button ("Play Year of Plenty", GUILayout.Height (Screen.height * 3 / 25))) {
					Amenu = actions.yop;
					toGain = 2;
				}
			}

			if(current_player.monopolyDevCard > 0) {
				if (GUILayout.Button ("Play Monopoly Card", GUILayout.Height (Screen.height * 3 / 25))) {
					Amenu = actions.mono;
				}
			}

			if(current_player.roadBuildingDevCard > 0){
				if (GUILayout.Button ("Play Road Building", GUILayout.Height (Screen.height * 3 / 25))) {
					Amenu = actions.rb;
				}
			}
			if (GUILayout.Button ("Cancel", GUILayout.Height (Screen.height * 3 / 25))) {
				hide ();
				Amenu = actions.menu;
			}
		}
		else if (Amenu == actions.mono){
			if (GUILayout.Button ("Brick", GUILayout.Height (Screen.height * 3 / 25))) {
			
			}
			if (GUILayout.Button ("Ore", GUILayout.Height (Screen.height * 3 / 25))) {
			
			}
			if (GUILayout.Button ("Sheep", GUILayout.Height (Screen.height * 3 / 25))) {
			
			}
			if (GUILayout.Button ("Wheat", GUILayout.Height (Screen.height * 3 / 25))) {
				
			}
			if (GUILayout.Button ("Wood", GUILayout.Height (Screen.height * 3 / 25))) {
				
			}
			if (GUILayout.Button ("Cancel", GUILayout.Height (Screen.height * 3 / 25))) {
				hide ();
				Amenu = actions.menu;
			}
		}
		else if (Amenu == actions.yop){
			if (GUILayout.Button ("Brick", GUILayout.Height (Screen.height * 3 / 25))) {
				current_player.brick++;
				toGain--;
			}
			if (GUILayout.Button ("Ore", GUILayout.Height (Screen.height * 3 / 25))) {
				current_player.ore++;
				toGain--;
			}
			if (GUILayout.Button ("Sheep", GUILayout.Height (Screen.height * 3 / 25))) {
				current_player.sheep++;
				toGain--;
			}
			if (GUILayout.Button ("Wheat", GUILayout.Height (Screen.height * 3 / 25))) {
				current_player.wheat++;
				toGain--;
			}
			if (GUILayout.Button ("Wood", GUILayout.Height (Screen.height * 3 / 25))) {
				current_player.wood++;
				toGain--;
			}
			if (toGain == 0){
				current_player.yearOfPlentyDevCard--;
				Amenu = actions.menu;
				hide();
			}
		}
		else if (Amenu == actions.rb){
			if (GUILayout.Button ("Add 2 Brick, 2 Wood", GUILayout.Height (Screen.height * 3 / 25))) {
				current_player.brick+=2;
				current_player.wood+=2;
				current_player.roadBuildingDevCard--;
				hide ();
			}
			if (GUILayout.Button ("Cancel", GUILayout.Height (Screen.height * 3 / 25))) {
				hide ();
				Amenu = actions.menu;
			}
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
