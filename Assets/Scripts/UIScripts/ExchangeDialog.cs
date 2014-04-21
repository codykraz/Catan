using UnityEngine;
using System.Collections;

public class ExchangeDialog : MonoBehaviour {
	public GUISkin g;

	int exc_winID = 2014;
	int res_alert_winID = 9102;
	PlayerScript current_player;

	string give_resource;
	string take_resource;
	string sgive;
	string stake;

	int igive;
	int itake;

	int multiplier;

	Texture give_resource_tex;
	Texture take_resource_tex;
	
	private TurnControllerScript turnController;
	
	public static bool show_exc = false;
	public static bool res_alert_exc = false;
	
	void Start() {
		turnController = GameObject.Find("TurnController").GetComponent<TurnControllerScript>();

		give_resource = "Wood";
		take_resource = "Brick";

		stake = "0";
		sgive = "0";

		igive = 0;
		itake = 0;

		give_resource_tex = GameObjectManager.GetTileTexture ("Wood");
		take_resource_tex = GameObjectManager.GetTileTexture ("Brick");
	}
	
	// Use this for initialization
	void OnGUI () {
		GUI.skin = g;
		//Background
		if (show_exc){
			GUI.ModalWindow (exc_winID, new Rect (Screen.width / 10, Screen.height *8/ 30, Screen.width * 4 / 5, Screen.height * 7 / 15), ModalContents, "Exchange");
		}
		if(res_alert_exc){
			GUI.ModalWindow (res_alert_winID, new Rect (Screen.width / 5, Screen.height *3/ 8, Screen.width * 3 / 5, Screen.height *1/ 4), ResAlrtContents, "Not Enough Resources");	
		}
	}
	void ModalContents (int windowID)
	{
		GUILayout.BeginArea (new Rect (Screen.width / 10, Screen.height/23, Screen.width * 3 / 5, Screen.height * 6 / 15));
		GUILayout.BeginVertical ();
		
		current_player = GameObject.Find(turnController.currentPlayer).GetComponent<PlayerScript>();
		multiplier = current_player.woodTradeIn;

		//Horizonal 1
		GUILayout.BeginHorizontal ();

		GUILayout.Label ("Give to Bank:");
		igive = itake * multiplier;
		sgive = igive.ToString();
		GUILayout.Label (sgive);


		if(GUILayout.Button(give_resource_tex, GUILayout.Height (Screen.height*7/96),GUILayout.Width (Screen.height*7/96)))
		{
			switch(give_resource)
			{
			case "Wood":
				give_resource = "Brick";
				give_resource_tex = GameObjectManager.GetTileTexture ("Brick");
				multiplier = current_player.brickTradeIn;
				break;
			case "Brick":
				give_resource = "Sheep";
				give_resource_tex = GameObjectManager.GetTileTexture ("Sheep");
				multiplier = current_player.sheepTradeIn;
				break;
			case "Sheep":
				give_resource = "Wheat";
				give_resource_tex = GameObjectManager.GetTileTexture ("Wheat");
				multiplier = current_player.wheatTradeIn;
				break;
			case "Wheat":
				give_resource = "Ore";
				give_resource_tex = GameObjectManager.GetTileTexture ("Ore");
				multiplier = current_player.oreTradeIn;
				break;
			case "Ore":
				give_resource = "Wood";
				give_resource_tex = GameObjectManager.GetTileTexture ("Wood");
				multiplier = current_player.woodTradeIn;
				break;
			default:
				give_resource = "Wood";
				give_resource_tex = GameObjectManager.GetTileTexture ("Wood");
				multiplier = current_player.woodTradeIn;
				break;
			}

		}
		GUILayout.EndHorizontal ();

		//Horizonal 2
		GUILayout.BeginHorizontal ();
		
		GUILayout.Label ("Take from Bank:");
		stake = GUILayout.TextField (stake, 2);
		if (int.TryParse (stake, out itake)) {
		}
		else
		{
			itake = 0;
		}
		
		if(GUILayout.Button(take_resource_tex, GUILayout.Height (Screen.height*7/96),GUILayout.Width (Screen.height*7/96)))
		{
			switch(take_resource)
			{
			case "Wood":
				take_resource = "Brick";
				take_resource_tex = GameObjectManager.GetTileTexture ("Brick");
				break;
			case "Brick":
				take_resource = "Sheep";
				take_resource_tex = GameObjectManager.GetTileTexture ("Sheep");
				break;
			case "Sheep":
				take_resource = "Wheat";
				take_resource_tex = GameObjectManager.GetTileTexture ("Wheat");
				break;
			case "Wheat":
				take_resource = "Ore";
				take_resource_tex = GameObjectManager.GetTileTexture ("Ore");
				break;
			case "Ore":
				take_resource = "Wood";
				take_resource_tex = GameObjectManager.GetTileTexture ("Wood");
				break;
			default:
				take_resource = "Wood";
				take_resource_tex = GameObjectManager.GetTileTexture ("Wood");
				break;
			}
			
		}
		GUILayout.EndHorizontal ();	

		GUILayout.Label (give_resource + " exchange rate: " + multiplier.ToString() + " to 1");
		//GUILayout.Space (Screen.height*2/96);

		if (GUILayout.Button ("Exchange", GUILayout.Height (Screen.height*7/96))) {
			bool success = false;
			switch(give_resource)
			{
			case "Wood":
				if(current_player.wood>=(multiplier*itake)){
					current_player.wood-=(multiplier*itake);
					success = true;
				}
				break;
			case "Brick":
				if(current_player.brick>=(multiplier*itake)){
					current_player.brick-=(multiplier*itake);
					success = true;
				}
				break;
			case "Sheep":
				if(current_player.sheep>=(multiplier*itake)){
					current_player.sheep-=(multiplier*itake);
					success = true;
				}
				break;
			case "Wheat":
				if(current_player.wheat>=(multiplier*itake)){
					current_player.wheat-=(multiplier*itake);
					success = true;
				}
				break;
			case "Ore":
				if(current_player.ore>=(multiplier*itake)){
					current_player.ore-=(multiplier*itake);
					success = true;
				}
				break;
			default:
				break;
			}

			if(success)
			{
				switch(take_resource)
				{
				case "Wood":
						current_player.wood+=(itake);
					break;
				case "Brick":
						current_player.brick+=(itake);
					break;
				case "Sheep":
						current_player.sheep+=(itake);
					break;
				case "Wheat":
						current_player.wheat+=(itake);
					break;
				case "Ore":
						current_player.ore+=(itake);
					break;
				default:
					break;
				}
			}
			else{
			
				res_alert_exc = true;
			
			}

			hide();
			
			give_resource = "Wood";
			take_resource = "Brick";
			
			give_resource_tex = GameObjectManager.GetTileTexture ("Wood");
			take_resource_tex = GameObjectManager.GetTileTexture ("Brick");
			multiplier = current_player.woodTradeIn;
			
			stake = "0";
			sgive = "0";
			
			itake = 0;
			igive = 0;
			
		}
		if (GUILayout.Button ("Cancel", GUILayout.Height (Screen.height*7/96))) {
			hide();

			give_resource = "Wood";
			take_resource = "Brick";
			
			give_resource_tex = GameObjectManager.GetTileTexture ("Wood");
			take_resource_tex = GameObjectManager.GetTileTexture ("Brick");
			multiplier = current_player.woodTradeIn;

			stake = "0";
			sgive = "0";

			itake = 0;
			igive = 0;
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

	void ResAlrtContents (int windowID)
	{
		GUILayout.BeginArea (new Rect (Screen.width*1/40, Screen.height* 1 / 54, Screen.width * 11 / 20, Screen.height* 9 / 36));
		GUILayout.BeginVertical ();

		GUILayout.Space (Screen.height*1/ 27);
		GUILayout.Label ("You do not possess enough of the selected resource!");
		GUILayout.Space (Screen.height*1/81);
		if(GUILayout.Button("Continue",GUILayout.Height (Screen.height*3/36)))
		{
			res_alert_exc = false;
		}

		GUILayout.EndVertical ();
		GUILayout.EndArea ();
	}
}
