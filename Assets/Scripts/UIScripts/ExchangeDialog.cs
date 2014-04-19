using UnityEngine;
using System.Collections;

public class ExchangeDialog : MonoBehaviour {
	float pic_width = 70;
	int exc_winID = 2014;
	
	float width_buffer = 20;
	float button_height = 50;
	PlayerScript current_player;

	string give_resource;
	string take_resource;

	Texture give_resource_tex;
	Texture take_resource_tex;
	
	private TurnControllerScript turnController;
	
	public static bool show_exc = false;
	
	void Start() {
		turnController = GameObject.Find("TurnController").GetComponent<TurnControllerScript>();

		give_resource = "wood";
		take_resource = "brick";

		give_resource_tex = GameObjectManager.GetTileTexture ("Wood");
		take_resource_tex = GameObjectManager.GetTileTexture ("Brick");
	}
	
	// Use this for initialization
	void OnGUI () {
		//Background
		if (show_exc){
			GUI.ModalWindow (exc_winID, new Rect (Screen.width / 10, Screen.height / 10, Screen.width * 4 / 5, Screen.height * 4 / 5), ModalContents, "Exchange");
		}
	}
	
	void ModalContents (int windowID)
	{
		GUILayout.BeginArea (new Rect (Screen.width / 10, Screen.height / 10, Screen.width * 3 / 5, Screen.height * 4 / 5));
		GUILayout.BeginVertical ();
		
		current_player = GameObject.Find(turnController.currentPlayer).GetComponent<PlayerScript>();

		if(GUILayout.Button(give_resource_tex, GUILayout.Height (pic_width),GUILayout.Width (pic_width)))
		{
			switch(give_resource)
			{
			case "Wood":
				give_resource = "Brick";
				give_resource_tex = GameObjectManager.GetTileTexture ("Brick");
				break;
			case "Brick":
				give_resource = "Sheep";
				give_resource_tex = GameObjectManager.GetTileTexture ("Sheep");
				break;
			case "Sheep":
				give_resource = "Wheat";
				give_resource_tex = GameObjectManager.GetTileTexture ("Wheat");
				break;
			case "Wheat":
				give_resource = "Ore";
				give_resource_tex = GameObjectManager.GetTileTexture ("Ore");
				break;
			case "Ore":
				give_resource = "Wood";
				give_resource_tex = GameObjectManager.GetTileTexture ("Wood");
				break;
			default:
				give_resource = "Wood";
				give_resource_tex = GameObjectManager.GetTileTexture ("Wood");
				break;
			}

		}
		
		GUILayout.EndVertical ();
		GUILayout.EndArea ();
	}
	
	public static void show (){
		show_exc = true;
	}
	
	public static void hide (){
		show_exc = false;
	}
}
