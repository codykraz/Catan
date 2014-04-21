using UnityEngine;
using System.Collections;

public class TradeDialog : MonoBehaviour {
	public GUISkin g;

	int trd_winID = 5293;
	private TurnControllerScript turnController;
	private static bool show_trd;

	PlayerScript current_player, partner;	
	public string[] playerList;
	int iterator, ignore;
	int[] res_amounts = new int[10];

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
		iterator = 0;
	}
	// Use this for initialization
	void OnGUI () {
		//Background
		GUI.skin = g;
		if (show_trd){
			GUI.ModalWindow (trd_winID, new Rect (Screen.width / 20, Screen.height *6/ 30, Screen.width * 9 / 10, Screen.height * 9 / 15), ModalContents, "Trade Window");
		}
	}

	void ModalContents (int windowID)
	{
		current_player = GameObject.Find(turnController.currentPlayer).GetComponent<PlayerScript>();

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

		//-----//CURRENT PLAYER//-----//

		GUILayout.BeginArea (new Rect (Screen.width / 40, Screen.height/23, Screen.width * 9 / 10, Screen.height * 9 / 15));
		GUILayout.BeginHorizontal ();
		GUILayout.BeginVertical ();
		GUILayout.Label (current_player.name);
		GUILayout.BeginHorizontal ();
		if(GUILayout.Button (wood_resource_tex, GUILayout.Height (Screen.height*7/96),GUILayout.Width (Screen.width*1/10))) {
		
		}
		if (GUILayout.Button (res_amounts[0].ToString(), GUILayout.Height (Screen.height * 7 / 96), GUILayout.Width (Screen.width*1 / 11))) {
		}
		if(GUILayout.Button ("+", GUILayout.Height (Screen.height*7/96),GUILayout.Width (Screen.width*1/11))) {
			if(res_amounts[0]<current_player.wood){
			   res_amounts[0]++;
			}
			else if(res_amounts[0] > current_player.wood){
				res_amounts[0] = current_player.wood; //Case should not happen
			}
			else{
				//Nothing, can't trade what you don't have
			}
		}
		if(GUILayout.Button ("-", GUILayout.Height (Screen.height*7/96),GUILayout.Width (Screen.width*1/11))) {
			if(res_amounts[0]>0){
				res_amounts[0]--;
			}
		}
		GUILayout.EndHorizontal ();
		GUILayout.BeginHorizontal ();
		if(GUILayout.Button (brick_resource_tex, GUILayout.Height (Screen.height*7/96),GUILayout.Width (Screen.width*1/10))) {
			
		}
		if (GUILayout.Button (res_amounts[1].ToString(), GUILayout.Height (Screen.height * 7 / 96), GUILayout.Width (Screen.width*1 / 11))) {
		}
		if(GUILayout.Button ("+", GUILayout.Height (Screen.height*7/96),GUILayout.Width (Screen.width*1/11))) {
			if(res_amounts[1]<current_player.brick){
				res_amounts[1]++;
			}
			else if(res_amounts[1] > current_player.brick){
				res_amounts[1] = current_player.brick; //Case should not happen
			}
			else{
				//Nothing, can't trade what you don't have
			}
		}
		if(GUILayout.Button ("-", GUILayout.Height (Screen.height*7/96),GUILayout.Width (Screen.width*1/11))) {
			if(res_amounts[1]>0){
				res_amounts[1]--;
			}
		}
		GUILayout.EndHorizontal ();
		GUILayout.BeginHorizontal ();
		if(GUILayout.Button (ore_resource_tex, GUILayout.Height (Screen.height*7/96),GUILayout.Width (Screen.width*1/10))) {
			
		}
		if (GUILayout.Button (res_amounts[2].ToString(), GUILayout.Height (Screen.height * 7 / 96), GUILayout.Width (Screen.width*1 / 11))) {
		}		
		if(GUILayout.Button ("+", GUILayout.Height (Screen.height*7/96),GUILayout.Width (Screen.width*1/11))) {
			if(res_amounts[2]<current_player.ore){
				res_amounts[2]++;
			}
			else if(res_amounts[2] > current_player.ore){
				res_amounts[2] = current_player.ore; //Case should not happen
			}
			else{
				//Nothing, can't trade what you don't have
			}
		}
		if(GUILayout.Button ("-", GUILayout.Height (Screen.height*7/96),GUILayout.Width (Screen.width*1/11))) {
			if(res_amounts[2]>0){
				res_amounts[2]--;
			}
		}
		GUILayout.EndHorizontal ();
		GUILayout.BeginHorizontal ();
		if(GUILayout.Button (wheat_resource_tex, GUILayout.Height (Screen.height*7/96),GUILayout.Width (Screen.width*1/10))) {
			
		}
		if (GUILayout.Button (res_amounts[3].ToString(), GUILayout.Height (Screen.height * 7 / 96), GUILayout.Width (Screen.width*1 / 11))) {
		}
		if(GUILayout.Button ("+", GUILayout.Height (Screen.height*7/96),GUILayout.Width (Screen.width*1/11))) {
			if(res_amounts[3]<current_player.wheat){
				res_amounts[3]++;
			}
			else if(res_amounts[3] > current_player.wheat){
				res_amounts[3] = current_player.wheat; //Case should not happen
			}
			else{
				//Nothing, can't trade what you don't have
			}
		}
		if(GUILayout.Button ("-", GUILayout.Height (Screen.height*7/96),GUILayout.Width (Screen.width*1/11))) {
			if(res_amounts[3]>0){
				res_amounts[3]--;
			}
		}
		GUILayout.EndHorizontal ();
		GUILayout.BeginHorizontal ();
		if(GUILayout.Button (sheep_resource_tex, GUILayout.Height (Screen.height*7/96),GUILayout.Width (Screen.width*1/10))) {
			
		}
		if (GUILayout.Button (res_amounts[4].ToString(), GUILayout.Height (Screen.height * 7 / 96), GUILayout.Width (Screen.width*1 / 11))) {
		}
		if(GUILayout.Button ("+", GUILayout.Height (Screen.height*7/96),GUILayout.Width (Screen.width*1/11))) {
			if(res_amounts[4]<current_player.sheep){
				res_amounts[4]++;
			}
			else if(res_amounts[4] > current_player.sheep){
				res_amounts[4] = current_player.sheep; //Case should not happen
			}
			else{
				//Nothing, can't trade what you don't have
			}
		}
		if(GUILayout.Button ("-", GUILayout.Height (Screen.height*7/96),GUILayout.Width (Screen.width*1/11))) {
			if(res_amounts[4]>0){
				res_amounts[4]--;
			}
		}
		GUILayout.EndHorizontal ();
		if (GUILayout.Button ("Cancel", GUILayout.Height (Screen.height*7/96),GUILayout.Width (Screen.width*35/88))) {
			hide ();
			for(int i=0; i<10; i++)
			{
				res_amounts[i] = 0;
			}
		}
		GUILayout.EndVertical ();

		//-----// Partner //-----//

		partner = GameObject.Find (playerList[iterator]).GetComponent<PlayerScript> ();

		GUILayout.BeginVertical ();
		GUILayout.BeginHorizontal ();
		if(GUILayout.Button (partner.name, GUILayout.Height (Screen.height*3/96),GUILayout.Width (Screen.width*35/88))) {
			iterator++;
			if(iterator>=3){
				iterator = 0;
			}

			for(int i=5; i<10; i++)
			{
				res_amounts[i] = 0;
			}
		}
		GUILayout.EndHorizontal ();
		GUILayout.BeginHorizontal ();
		if(GUILayout.Button (wood_resource_tex, GUILayout.Height (Screen.height*7/96),GUILayout.Width (Screen.width*1/10))) {
			
		}
		if (GUILayout.Button (res_amounts[5].ToString(), GUILayout.Height (Screen.height * 7 / 96), GUILayout.Width (Screen.width*1 / 11))) {
		}
		if(GUILayout.Button ("+", GUILayout.Height (Screen.height*7/96),GUILayout.Width (Screen.width*1/11))) {
			if(res_amounts[5]<partner.wood){
				res_amounts[5]++;
			}
			else if(res_amounts[5] > partner.wood){
				res_amounts[5] = partner.wood; //Case should not happen
			}
			else{
				//Nothing, can't trade what you don't have
			}
		}
		if(GUILayout.Button ("-", GUILayout.Height (Screen.height*7/96),GUILayout.Width (Screen.width*1/11))) {
			if(res_amounts[5]>5){
				res_amounts[5]--;
			}
		}
		GUILayout.EndHorizontal ();
		GUILayout.BeginHorizontal ();
		if(GUILayout.Button (brick_resource_tex, GUILayout.Height (Screen.height*7/96),GUILayout.Width (Screen.width*1/10))) {
			
		}
		if (GUILayout.Button (res_amounts[6].ToString(), GUILayout.Height (Screen.height * 7 / 96), GUILayout.Width (Screen.width*1 / 11))) {
		}
		if(GUILayout.Button ("+", GUILayout.Height (Screen.height*7/96),GUILayout.Width (Screen.width*1/11))) {
			if(res_amounts[6]<partner.brick){
				res_amounts[6]++;
			}
			else if(res_amounts[6] > partner.brick){
				res_amounts[6] = partner.brick; //Case should not happen
			}
			else{
				//Nothing, can't trade what you don't have
			}
		}
		if(GUILayout.Button ("-", GUILayout.Height (Screen.height*7/96),GUILayout.Width (Screen.width*1/11))) {
			if(res_amounts[6]>0){
				res_amounts[6]--;
			}
		}
		GUILayout.EndHorizontal ();
		GUILayout.BeginHorizontal ();
		if(GUILayout.Button (ore_resource_tex, GUILayout.Height (Screen.height*7/96),GUILayout.Width (Screen.width*1/10))) {
			
		}
		if (GUILayout.Button (res_amounts[7].ToString(), GUILayout.Height (Screen.height * 7 / 96), GUILayout.Width (Screen.width*1 / 11))) {
		}		
		if(GUILayout.Button ("+", GUILayout.Height (Screen.height*7/96),GUILayout.Width (Screen.width*1/11))) {
			if(res_amounts[7]<partner.ore){
				res_amounts[7]++;
			}
			else if(res_amounts[7] > partner.ore){
				res_amounts[7] = partner.ore; //Case should not happen
			}
			else{
				//Nothing, can't trade what you don't have
			}
		}
		if(GUILayout.Button ("-", GUILayout.Height (Screen.height*7/96),GUILayout.Width (Screen.width*1/11))) {
			if(res_amounts[7]>0){
				res_amounts[7]--;
			}
		}
		GUILayout.EndHorizontal ();
		GUILayout.BeginHorizontal ();
		if(GUILayout.Button (wheat_resource_tex, GUILayout.Height (Screen.height*7/96),GUILayout.Width (Screen.width*1/10))) {
			
		}
		if (GUILayout.Button (res_amounts[8].ToString(), GUILayout.Height (Screen.height * 7 / 96), GUILayout.Width (Screen.width*1 / 11))) {
		}
		if(GUILayout.Button ("+", GUILayout.Height (Screen.height*7/96),GUILayout.Width (Screen.width*1/11))) {
			if(res_amounts[8]<partner.wheat){
				res_amounts[8]++;
			}
			else if(res_amounts[8] > partner.wheat){
				res_amounts[8] = partner.wheat; //Case should not happen
			}
			else{
				//Nothing, can't trade what you don't have
			}
		}
		if(GUILayout.Button ("-", GUILayout.Height (Screen.height*7/96),GUILayout.Width (Screen.width*1/11))) {
			if(res_amounts[8]>0){
				res_amounts[8]--;
			}
		}
		GUILayout.EndHorizontal ();
		GUILayout.BeginHorizontal ();
		if(GUILayout.Button (sheep_resource_tex, GUILayout.Height (Screen.height*7/96),GUILayout.Width (Screen.width*1/10))) {
			
		}
		if (GUILayout.Button (res_amounts[9].ToString(), GUILayout.Height (Screen.height * 7 / 96), GUILayout.Width (Screen.width*1 / 11))) {
		}
		if(GUILayout.Button ("+", GUILayout.Height (Screen.height*7/96),GUILayout.Width (Screen.width*1/11))) {
			if(res_amounts[9]<partner.sheep){
				res_amounts[9]++;
			}
			else if(res_amounts[9] > partner.sheep){
				res_amounts[9] = partner.sheep; //Case should not happen
			}
			else{
				//Nothing, can't trade what you don't have
			}
		}
		if(GUILayout.Button ("-", GUILayout.Height (Screen.height*7/96),GUILayout.Width (Screen.width*1/11))) {
			if(res_amounts[9]>0){
				res_amounts[9]--;
			}
		}
		GUILayout.EndHorizontal ();
		if (GUILayout.Button ("Trade", GUILayout.Height (Screen.height*7/96),GUILayout.Width (Screen.width*35/88))) {
			current_player.wood = current_player.wood - res_amounts[0] + res_amounts[5];
			current_player.brick = current_player.brick - res_amounts[1] + res_amounts[6];
			current_player.ore = current_player.ore - res_amounts[2] + res_amounts[7];
			current_player.wheat = current_player.wheat - res_amounts[3] + res_amounts[8];
			current_player.sheep = current_player.sheep - res_amounts[4] + res_amounts[9];

			partner.wood = partner.wood + res_amounts[0] - res_amounts[5];
			partner.brick = partner.brick + res_amounts[1] - res_amounts[6];
			partner.ore = partner.ore + res_amounts[2] - res_amounts[7];
			partner.wheat = partner.wheat + res_amounts[3] - res_amounts[8];
			partner.sheep = partner.sheep + res_amounts[4] - res_amounts[9];
			
			hide ();
			for(int i=0; i<10; i++)
			{
				res_amounts[i] = 0;
			}
		}
		GUILayout.EndVertical ();
		GUILayout.EndHorizontal ();

		GUILayout.EndArea ();
	}

	public static void show (){
		show_trd = true;

	}
	
	public static void hide (){
		show_trd = false;
	}
}
