using UnityEngine;
using System.Collections;

public class VictoryDialog : MonoBehaviour {
	public GUISkin g;

	float pic_width = 70;
	int vic_winID = 1337;
	Texture AMan;
	public static bool show_vic = false;

	private PlayerScript player1;
	private PlayerScript player2;
	private PlayerScript player3;
	private PlayerScript player4;

	private GSButtonGUI gs;

	string winner;

	void Start() {
		AMan = Resources.Load ("A-Man", typeof(Texture)) as Texture;

		player1 = GameObject.Find("Player1").GetComponent<PlayerScript>();
		player2 = GameObject.Find("Player2").GetComponent<PlayerScript>();
		player3 = GameObject.Find("Player3").GetComponent<PlayerScript>();
		player4 = GameObject.Find("Player4").GetComponent<PlayerScript>();

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