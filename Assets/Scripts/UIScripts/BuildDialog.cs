using UnityEngine;
using System.Collections;

public class BuildDialog : MonoBehaviour {
	float pic_width = 70;
	int build_bldID = 1026;
	int res_alert2_winID= 7320;
	PlayerScript current_player;
	
	float width_buffer = 20;
	float button_height = 50;

	Texture AMan;
	
	public static bool show_bld = false;
	public static bool res_alert_exc = false;

	private TurnControllerScript turnController;
	
	void Start() {
		AMan = Resources.Load ("A-Man", typeof(Texture)) as Texture;
		
	}
	
	// Use this for initialization
	void OnGUI () {
		//Background
		if (show_bld){
			GUI.ModalWindow (build_bldID, new Rect (Screen.width / 10, Screen.height / 10, Screen.width * 4 / 5, Screen.height * 4 / 5), ModalContents, "Build");
		}
		if(res_alert_exc){
			GUI.ModalWindow (res_alert2_winID, new Rect (Screen.width / 5, Screen.height / 6, Screen.width * 3 / 5, Screen.height *2/ 3), ResAlrtContents, "Not Enough Resources");	
		}
	}
	
	void ModalContents (int windowID)
	{
		GUILayout.BeginArea (new Rect (Screen.width / 10, Screen.height * 7 / 80, Screen.width * 3 / 5, Screen.height * 4 / 5));
		GUILayout.BeginVertical ();

		//current_player = GameObject.Find(turnController.currentPlayer).GetComponent<PlayerScript>();

		//Road
		GUILayout.BeginHorizontal ();
		GUILayout.Label ("Road\nCost: 1 Wood, 1 Brick");
		if (GUILayout.Button (AMan,GUILayout.Width(Screen.height* 3 /25), GUILayout.Height (Screen.height* 3 /25))) {
			/*if(current_player.wood < 1 || current_player.brick < 1)
			{
				res_alert_exc = true;
				hide();
			}*/
		}
		GUILayout.EndHorizontal ();

		//Settlement
		GUILayout.BeginHorizontal ();
		GUILayout.Label ("Settlement\nCost: 1 Wood, 1 Brick, 1 Wheat, 1 Sheep");
		if (GUILayout.Button (AMan,GUILayout.Width(Screen.height* 3 /25), GUILayout.Height (Screen.height* 3 /25))) {
			/*if(current_player.wood < 1 || current_player.brick < 1 || current_player.wheat < 1 || current_player.sheep < 1)
			{
				res_alert_exc = true;
				hide();
			}	*/		
		}
		GUILayout.EndHorizontal ();

		//City
		GUILayout.BeginHorizontal ();
		GUILayout.Label ("City\nCost: 2 Wheat, 3 Ore");
		if (GUILayout.Button (AMan,GUILayout.Width(Screen.height* 3 /25), GUILayout.Height (Screen.height* 3 /25))) {
			/*if(current_player.wheat < 2 || current_player.ore < 3)
			{
				res_alert_exc = true;
				hide();
			}*/				
		}

		GUILayout.EndHorizontal ();

		//Dev Card
		GUILayout.BeginHorizontal ();
		GUILayout.Label ("Development Card\nCost: 1 Sheep, 1 Wheat, 1 Ore");
		if (GUILayout.Button (AMan,GUILayout.Width(Screen.height* 3 /25), GUILayout.Height (Screen.height* 3 /25))) {
			/*if(current_player.sheep < 1 || current_player.wheat < 1 || current_player.ore < 1)
			{
				res_alert_exc = true;
				hide();
			}*/			
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

	void ResAlrtContents (int windowID)
	{
		GUILayout.BeginArea (new Rect (Screen.width / 20, Screen.height* 1 / 27, Screen.width * 5 / 10, Screen.height* 16 / 27));
		GUILayout.BeginVertical ();
		
		GUILayout.Space (Screen.width*5 / 27);
		GUILayout.Label ("You cannot afford to build that!");
		GUILayout.Space (Screen.width*1/27);
		if(GUILayout.Button("Continue",GUILayout.Height (Screen.height*7/96)))
		{
			res_alert_exc = false;
		}
		
		GUILayout.EndVertical ();
		GUILayout.EndArea ();
	}
}