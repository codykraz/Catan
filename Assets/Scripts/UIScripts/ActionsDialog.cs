using UnityEngine;
using System.Collections;

public enum actions{menu, devCard, yop, mono, rb};

public class ActionsDialog : MonoBehaviour {
	public GUISkin g;
	
	public float button_height = Screen.height* 3 /25;
	int act_winID = 2142;
	TradeDialog td;
	PlayerScript current_player;
	int toGain = 0;
	
	private TurnControllerScript turnController;

	private bool playKnight = false;

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
		int res = 0;

		if (t == TileType.Wood) {
			for (int i = 0; i < 4; i++) {
				res += players[i].GetComponent<PlayerScript>().wood;
				players[i].GetComponent<PlayerScript>().wood = 0;
			}
			current_player.wood = res;
		}
		if (t == TileType.Sheep) {
			for (int i = 0; i < 4; i++) {
				res += players[i].GetComponent<PlayerScript>().sheep;
				players[i].GetComponent<PlayerScript>().sheep = 0;
			}
			current_player.sheep = res;
		}
		if (t == TileType.Brick){
			for (int i = 0; i < 4; i++) {
				res += players[i].GetComponent<PlayerScript>().brick;
				players[i].GetComponent<PlayerScript>().brick = 0;
			}
			current_player.brick = res;
		}
		if (t == TileType.Ore) {
			for (int i = 0; i < 4; i++) {
				res += players[i].GetComponent<PlayerScript>().ore;
				players[i].GetComponent<PlayerScript>().ore = 0;
			}
			current_player.ore = res;
		}
		if (t == TileType.Wheat) {
			for (int i = 0; i < 4; i++) {
				res += players[i].GetComponent<PlayerScript>().wheat;
				players[i].GetComponent<PlayerScript>().wheat = 0;
			}
			current_player.wheat = res;
		}
	}

	
	void ModalContents (int windowID)
	{
		current_player = GameObject.Find(turnController.currentPlayer).GetComponent<PlayerScript>();
		GUILayout.BeginArea (new Rect (Screen.width / 10, Screen.height / 10, Screen.width * 3 / 5, Screen.height * 4 / 5));
		GUILayout.BeginVertical ();

		if(playKnight)
		{
			if(GUI.Button(new Rect(Screen.width/2,Screen.height-button_height,Screen.width/2,button_height), "Cancel")) {
				playKnight = false;
			}
			
			GUILayout.BeginArea(new Rect(0, Screen.height -button_height, Screen.width, button_height));
			GUILayout.Box(turnController.currentPlayer +": Select a position to place the knight", GUILayout.ExpandHeight(true));
			GUILayout.EndArea();

			CameraControler cc = GameObject.Find("Main Camera").GetComponent<CameraControler>();

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

					playKnight = false;
				}
			}
		}
		else if (Amenu == actions.menu) {
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
					
					GameObject.Find("Main Camera").GetComponent<CameraControler>().selectedObject = null;
					playKnight = true;
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
				monopoly(TileType.Brick);
				current_player.monopolyDevCard--;
				hide ();
				Amenu = actions.menu;
			}
			if (GUILayout.Button ("Ore", GUILayout.Height (Screen.height * 3 / 25))) {
				monopoly(TileType.Ore);
				current_player.monopolyDevCard--;
				hide ();
				Amenu = actions.menu;
			}
			if (GUILayout.Button ("Sheep", GUILayout.Height (Screen.height * 3 / 25))) {
				monopoly(TileType.Sheep);
				current_player.monopolyDevCard--;
				hide ();
				Amenu = actions.menu;
			}
			if (GUILayout.Button ("Wheat", GUILayout.Height (Screen.height * 3 / 25))) {
				monopoly(TileType.Wheat);
				current_player.monopolyDevCard--;
				hide ();
				Amenu = actions.menu;
			}
			if (GUILayout.Button ("Wood", GUILayout.Height (Screen.height * 3 / 25))) {
				monopoly(TileType.Wood);
				current_player.monopolyDevCard--;
				hide ();
				Amenu = actions.menu;
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
				Amenu = actions.menu;
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
