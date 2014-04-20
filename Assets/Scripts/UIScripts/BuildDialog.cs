using UnityEngine;
using System.Collections;

public class BuildDialog : MonoBehaviour {
	float pic_width = 70;
	int build_bldID = 1026;
	
	float width_buffer = 20;
	float button_height = 50;

	Texture AMan;
	
	public static bool show_bld = false;
	
	void Start() {
		AMan = Resources.Load ("A-Man", typeof(Texture)) as Texture;
		
	}
	
	// Use this for initialization
	void OnGUI () {
		//Background
		if (show_bld){
			GUI.ModalWindow (build_bldID, new Rect (Screen.width / 10, Screen.height / 10, Screen.width * 4 / 5, Screen.height * 4 / 5), ModalContents, "Build");
		}
	}
	
	void ModalContents (int windowID)
	{
		GUILayout.BeginArea (new Rect (Screen.width / 10, Screen.height * 7 / 80, Screen.width * 3 / 5, Screen.height * 4 / 5));
		GUILayout.BeginVertical ();

		//Road
		GUILayout.BeginHorizontal ();
		GUILayout.Label ("Road");
		if (GUILayout.Button (AMan,GUILayout.Width(Screen.height* 3 /25), GUILayout.Height (Screen.height* 3 /25))) {
				
		}
		GUILayout.EndHorizontal ();

		//Settlement
		GUILayout.BeginHorizontal ();
		GUILayout.Label ("Settlement");
		if (GUILayout.Button (AMan,GUILayout.Width(Screen.height* 3 /25), GUILayout.Height (Screen.height* 3 /25))) {
			
		}
		GUILayout.EndHorizontal ();

		//City
		GUILayout.BeginHorizontal ();
		GUILayout.Label ("City");
		if (GUILayout.Button (AMan,GUILayout.Width(Screen.height* 3 /25), GUILayout.Height (Screen.height* 3 /25))) {
			
		}

		GUILayout.EndHorizontal ();
		//Dev Card
		GUILayout.BeginHorizontal ();
		GUILayout.Label ("Development Card");
		if (GUILayout.Button (AMan,GUILayout.Width(Screen.height* 3 /25), GUILayout.Height (Screen.height* 3 /25))) {
			
		}
		GUILayout.EndHorizontal ();
		GUILayout.Space (Screen.height * 2 / 80);
		//Cancel
		if(GUILayout.Button("Cancel", GUILayout.Height (Screen.height* 3 /25)))
		{
			hide ();
		}
		
		GUILayout.EndVertical ();
		GUILayout.EndArea ();
	}
	
	public static void show (){
		show_bld = true;
	}
	
	public static void hide (){
		show_bld = false;
	}
}