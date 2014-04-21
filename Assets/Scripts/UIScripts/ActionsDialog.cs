using UnityEngine;
using System.Collections;

public class ActionsDialog : MonoBehaviour {
	float pic_width = 70;
	int act_winID = 2142;

	float width_buffer = 20;
	float button_height = 50;
	TradeDialog td;

	public static bool show_act = false;
	
	void Start() {
	}
	
	// Use this for initialization
	void OnGUI () {
		//Background
		if (show_act){
			GUI.ModalWindow (act_winID, new Rect (Screen.width / 10, Screen.height / 10, Screen.width * 4 / 5, Screen.height * 4 / 5), ModalContents, "Actions");
		}
	}
	
	void ModalContents (int windowID)
	{
		GUILayout.BeginArea (new Rect (Screen.width / 10, Screen.height / 10, Screen.width * 3 / 5, Screen.height * 4 / 5));
		GUILayout.BeginVertical ();

		if(GUILayout.Button("Build", GUILayout.Height (Screen.height* 3 /25)))
		{
			BuildDialog.show();
			hide ();
		}
		if(GUILayout.Button("Trade with Player", GUILayout.Height (Screen.height* 3 /25)))
		{
			TradeDialog.show();
			hide ();
		}
		if(GUILayout.Button("Exchange Resource", GUILayout.Height (Screen.height* 3 /25)))
		{
			ExchangeDialog.show();
			hide ();
		}
		if(GUILayout.Button("Play Development Card", GUILayout.Height (Screen.height* 3 /25)))
		{
			//DevCard();
		}
		if(GUILayout.Button("Cancel", GUILayout.Height (Screen.height* 3 /25)))
		{
			hide ();
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
