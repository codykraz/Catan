using UnityEngine;
using System.Collections;

public class VictoryDialog : MonoBehaviour {
	public GUISkin g;

	float pic_width = 70;
	int vic_winID = 1337;
	Texture AMan;
	public static bool show_vic = false;

	void Start() {
		AMan = Resources.Load ("A-Man", typeof(Texture)) as Texture;

	}

	// Use this for initialization
	void OnGUI () {
		//Background
		GUI.skin = g;
		if (show_vic){
			GUI.ModalWindow (vic_winID, new Rect (Screen.width / 5, Screen.height / 3, Screen.width * 3 / 5, Screen.height / 3), ModalContents, "Victory!");
		}
	}

	void ModalContents (int windowID)
	{
		if(GUI.Button(new Rect(Screen.width/10,Screen.height*1/12,Screen.width*2/5,Screen.height*1/6), "Continue")) {
			//END GAME FUNCTION
			hide ();
		}
	}

	public static void show (){
		show_vic = true;
	}

	public static void hide (){
		show_vic = false;
	}
}