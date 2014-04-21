using UnityEngine;
using System.Collections;

public class VictoryDialog : MonoBehaviour {
	public GUISkin g;

	int vic_winID = 1337;
	public static bool show_vic = false;

	int longRd = 5;
	int lgArmy = 2;

	private PlayerScript player1;
	private PlayerScript player2;
	private PlayerScript player3;
	private PlayerScript player4;
	private PlayerScript[] players;

	private GSButtonGUI gs;

	string winner;

	void Start() {

		player1 = GameObject.Find("Player1").GetComponent<PlayerScript>();
		player2 = GameObject.Find("Player2").GetComponent<PlayerScript>();
		player3 = GameObject.Find("Player3").GetComponent<PlayerScript>();
		player4 = GameObject.Find("Player4").GetComponent<PlayerScript>();

		players = new PlayerScript[]{player1,player2, player3,player4};

		winner = "Player1";
		gs = GetComponent<GSButtonGUI> ();
	}

	// Use this for initialization
	void OnGUI () {
		//Background
		GUI.skin = g;
		if (show_vic){
			GUI.ModalWindow (vic_winID, new Rect (Screen.width / 5, Screen.height / 3, Screen.width * 3 / 5, Screen.height / 3), ModalContents, "Victory!");
		}

		for (int i = 0; i < 4; i++) {
			if (players[i].largestArmyCount>lgArmy){
				for (int x = 0; x < 4; x++) players[x].hasLargestArmy = false;
				players[i].hasLargestArmy = true;
				lgArmy = players[i].largestArmyCount;
			}

			if (players[i].roadsUsed > longRd){
				for (int x = 0; x < 4; x++) players[x].hasLongestRoad = false;
				players[i].hasLongestRoad = true;
				longRd = players[i].roadsUsed;
			}
		}


		if (player1.victoryPoints >= 10) {
			gs.show = false;
			show ();
			winner=player1.name;
		}
		else if (player2.victoryPoints >= 10) {
			gs.show = false;
			show ();
			winner=player2.name;
		}
		else if (player3.victoryPoints >= 10) {
			gs.show = false;
			show ();
			winner=player3.name;
		}
		else if (player4.victoryPoints >= 10) {
			gs.show = false;
			show ();
			winner=player4.name;
		}
	}

	void ModalContents (int windowID)
	{
		if(GUI.Button(new Rect(Screen.width/10,Screen.height*1/12,Screen.width*2/5,Screen.height*1/6), winner + " Wins!")) {
			//END GAME FUNCTION
			hide ();

			Application.LoadLevel("Intro_C");
		}
	}

	public static void show (){
		show_vic = true;
	}

	public static void hide (){
		show_vic = false;
	}
}