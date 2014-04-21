using UnityEngine;
using System.Collections;

public class BuildDialog : MonoBehaviour {
	public GUISkin g;
	int build_bldID = 1026;
	int res_alert2_winID= 7320;
	int pos_alert2_winID = 819074981;
	PlayerScript current_player;
	
	float width_buffer = 20;
	public float button_height = Screen.height* 3 /25;

	Texture AMan;

	private bool selectBuilding = false;
	private string buildingName = "";

	public static bool show_bld = false;
	public static bool res_alert_exc = false;

	private TurnControllerScript turnController;
	private GSButtonGUI gs;
	private CameraControler camera;
	private deck Deck;
	
	void Start() {
		AMan = Resources.Load ("A-Man", typeof(Texture)) as Texture;

		turnController = GameObject.Find("TurnController").GetComponent<TurnControllerScript>();
		camera = GameObject.Find ("Main Camera").GetComponent<CameraControler>();
		Deck = GameObject.Find("Deck").GetComponent<deck>();
		gs = GetComponent<GSButtonGUI> ();
		
	}
	
	// Use this for initialization
	void OnGUI () {
		//Background
		GUI.skin = g;
		if(res_alert_exc){
			GUI.ModalWindow (res_alert2_winID, new Rect (Screen.width / 5, Screen.height / 6, Screen.width * 3 / 5, Screen.height *2/ 3), ResAlrtContents, "Not Enough Resources");	
		}
		else if (show_bld){
			GUI.ModalWindow (build_bldID, new Rect (Screen.width / 10, Screen.height / 10, Screen.width * 4 / 5, Screen.height * 4 / 5), ModalContents, "Build");
		}
		else if(selectBuilding)
		{
			gs.show = false;
			GUILayout.BeginArea(new Rect(0, Screen.height -(2*button_height), Screen.width, button_height));
			GUILayout.Box("Select a position to place a " + buildingName, GUILayout.ExpandHeight(true));
			GUILayout.EndArea();

			if(GUI.Button(new Rect(Screen.width/2,Screen.height-(button_height),Screen.width/2,button_height), "Cancel")) 
			{
				gs.show = true;
				selectBuilding = false;
			}

			if(camera.selectedObject != null)
			{
				if(buildingName == "Road" && camera.selectedObject.tag == "Road")
				{
						if(camera.selectedObject.GetComponent<RoadScript>().build())
						{
							selectBuilding = false;
							gs.show = true;
							current_player.brick--;
							current_player.wood--;
						}
				}
				else if(buildingName == "Settlement" && camera.selectedObject.tag == "Settlement")
				{
						if(camera.selectedObject.GetComponent<SettlementScript>().build())
						{
							selectBuilding = false;
							gs.show = true;
							current_player.brick--;
							current_player.wood--;
							current_player.sheep--;
							current_player.wheat--;
						}
				}
				else if(buildingName == "City" && camera.selectedObject.tag == "Settlement")
				{
						if(camera.selectedObject.GetComponent<SettlementScript>().buildCity())
						{
							selectBuilding = false;
							gs.show = true;
							current_player.wheat-=2;
							current_player.ore-=3;
						}
				}
			}
		}
	}
	
	void ModalContents (int windowID)
	{
		GUILayout.BeginArea (new Rect (Screen.width / 10, Screen.height * 7 / 80, Screen.width * 3 / 5, Screen.height * 4 / 5));
		GUILayout.BeginVertical ();

		current_player = GameObject.Find(turnController.currentPlayer).GetComponent<PlayerScript>();

		//Road
		GUILayout.BeginHorizontal ();
		GUILayout.Label ("Road\nCost: 1 Wood, 1 Brick");
		if (!(current_player.wood < 1 || current_player.brick < 1)&&(GUILayout.Button (AMan,GUILayout.Width(Screen.height* 3 /25), GUILayout.Height (Screen.height* 3 /25)))) {
			if(current_player.wood < 1 || current_player.brick < 1)
			{
				res_alert_exc = true;
				hide();
			}
			else
			{
				selectBuilding = true;
				camera.selectedObject = null;
				buildingName = "Road";
				hide();
			}
		}
		GUILayout.EndHorizontal ();

		//Settlement
		GUILayout.BeginHorizontal ();
		GUILayout.Label ("Settlement\nCost: 1 Wood, 1 Brick, 1 Wheat, 1 Sheep");
		if (!(current_player.wood < 1 || current_player.brick < 1 || current_player.wheat < 1 || current_player.sheep < 1)&&(GUILayout.Button (AMan,GUILayout.Width(Screen.height* 3 /25), GUILayout.Height (Screen.height* 3 /25)))) {
			if(current_player.wood < 1 || current_player.brick < 1 || current_player.wheat < 1 || current_player.sheep < 1)
			{
				res_alert_exc = true;
				hide();
			}	
			else
			{
				selectBuilding = true;
				camera.selectedObject = null;
				buildingName = "Settlement";
				hide();
			}
		}
		GUILayout.EndHorizontal ();

		//City
		GUILayout.BeginHorizontal ();
		GUILayout.Label ("City\nCost: 2 Wheat, 3 Ore");
		if (!(current_player.wheat < 2 || current_player.ore < 3)&&(GUILayout.Button (AMan,GUILayout.Width(Screen.height* 3 /25), GUILayout.Height (Screen.height* 3 /25)))) {
			if(current_player.wheat < 2 || current_player.ore < 3)
			{
				res_alert_exc = true;
				hide();
			}
			else
			{
				selectBuilding = true;
				camera.selectedObject = null;
				buildingName = "City";
				hide();
			}		
		}

		GUILayout.EndHorizontal ();

		//Dev Card
		GUILayout.BeginHorizontal ();
		GUILayout.Label ("Development Card\nCost: 1 Sheep, 1 Wheat, 1 Ore");
		if (!(current_player.sheep < 1 || current_player.wheat < 1 || current_player.ore < 1)&&(GUILayout.Button (AMan,GUILayout.Width(Screen.height* 3 /25), GUILayout.Height (Screen.height* 3 /25)))) {
			if(current_player.sheep < 1 || current_player.wheat < 1 || current_player.ore < 1)
			{
				res_alert_exc = true;
				hide();
			}
			else
			{
				current_player.ore--;
				current_player.sheep--;
				current_player.wheat--;
				Deck.draw();
				hide();
			}	
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