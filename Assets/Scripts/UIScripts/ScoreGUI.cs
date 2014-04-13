using UnityEngine;
using System.Collections;

public class ScoreGUI : MonoBehaviour {
	int current_player_score = 0;
	Texture AMan;

	void Start() {
		AMan = Resources.Load ("A-Man", typeof(Texture)) as Texture;
	}

	void OnGUI () {
		current_player_score+=1;

		// Resources on top left of screen
		float resources_box_width = Screen.width*3/4;
		float resources_box_unit = resources_box_width/26;

		//GUI.Box (new Rect (-5,-5,Screen.width+10,resources_box_unit*6+10), "");

		GUI.Label (new Rect (resources_box_unit*1, 5, resources_box_unit*5, resources_box_unit*5), GameObjectManager.GetTileTexture("Wood"));
		GUI.Label (new Rect (resources_box_unit*1, 5, resources_box_unit*5, resources_box_unit*5), current_player_score.ToString());

		GUI.Label (new Rect (resources_box_unit*6, 5, resources_box_unit*5, resources_box_unit*5), GameObjectManager.GetTileTexture("Ore"));
		GUI.Label (new Rect (resources_box_unit*6, 5, resources_box_unit*5, resources_box_unit*5), current_player_score.ToString());

		GUI.Label (new Rect (resources_box_unit*11, 5, resources_box_unit*5, resources_box_unit*5), GameObjectManager.GetTileTexture("Brick"));
		GUI.Label (new Rect (resources_box_unit*11, 5, resources_box_unit*5, resources_box_unit*5), current_player_score.ToString());

		GUI.Label (new Rect (resources_box_unit*16, 5, resources_box_unit*5, resources_box_unit*5), GameObjectManager.GetTileTexture("Wheat"));
		GUI.Label (new Rect (resources_box_unit*16, 5, resources_box_unit*5, resources_box_unit*5), current_player_score.ToString());

		GUI.Label (new Rect (resources_box_unit*21, 5, resources_box_unit*5, resources_box_unit*5), GameObjectManager.GetTileTexture("Sheep"));
		GUI.Label (new Rect (resources_box_unit*21, 5, resources_box_unit*5, resources_box_unit*5), current_player_score.ToString());

		// Current player's score on top right
		float score_box_width = Screen.width*1/4;
		float score_box_unit = score_box_width/10;

		//GUI.Box (new Rect (Screen.width - score_box_width, -5, score_box_width+5, 15+score_box_unit*17), "");

		GUI.Label (new Rect (Screen.width - score_box_unit*9, 10, score_box_unit*4, score_box_unit*4), "8/10");
		GUI.Label (new Rect (Screen.width - score_box_unit*5, 10, score_box_unit*5, score_box_unit*5), AMan);

		// Other player's score's below that

		GUI.Label (new Rect (Screen.width - score_box_unit*8, 10 + score_box_unit*5, score_box_unit*4, score_box_unit*4), "6/10");
		GUI.Label (new Rect (Screen.width - score_box_unit*4, 10 + score_box_unit*5, score_box_unit*4, score_box_unit*4), AMan);

		GUI.Label (new Rect (Screen.width - score_box_unit*8, 10 + score_box_unit*9, score_box_unit*4, score_box_unit*4), "5/10");
		GUI.Label (new Rect (Screen.width - score_box_unit*4, 10 + score_box_unit*9, score_box_unit*4, score_box_unit*4), AMan);

		GUI.Label (new Rect (Screen.width - score_box_unit*8, 10 + score_box_unit*13, score_box_unit*4, score_box_unit*4), "7/10");
		GUI.Label (new Rect (Screen.width - score_box_unit*4, 10 + score_box_unit*13, score_box_unit*4, score_box_unit*4), AMan);
	}
}
