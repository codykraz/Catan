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

		GUI.Label (new Rect (resources_box_unit*3, 10, resources_box_unit*2, resources_box_unit*2), current_player_score.ToString());
		GUI.Label (new Rect (resources_box_unit*1, 10, resources_box_unit*2, resources_box_unit*2), GameObjectManager.GetTileTexture("Wood"));
		
		GUI.Label (new Rect (resources_box_unit*8, 10, resources_box_unit*2, resources_box_unit*2), current_player_score.ToString());
		GUI.Label (new Rect (resources_box_unit*6, 10, resources_box_unit*2, resources_box_unit*2), GameObjectManager.GetTileTexture("Ore"));
		
		GUI.Label (new Rect (resources_box_unit*13, 10, resources_box_unit*2, resources_box_unit*2), current_player_score.ToString());
		GUI.Label (new Rect (resources_box_unit*11, 10, resources_box_unit*2, resources_box_unit*2), GameObjectManager.GetTileTexture("Brick"));
		
		GUI.Label (new Rect (resources_box_unit*18, 10, resources_box_unit*2, resources_box_unit*2), current_player_score.ToString());
		GUI.Label (new Rect (resources_box_unit*16, 10, resources_box_unit*2, resources_box_unit*2), GameObjectManager.GetTileTexture("Wheat"));
		
		GUI.Label (new Rect (resources_box_unit*23, 10, resources_box_unit*2, resources_box_unit*2), current_player_score.ToString());
		GUI.Label (new Rect (resources_box_unit*21, 10, resources_box_unit*2, resources_box_unit*2), GameObjectManager.GetTileTexture("Sheep"));
		
		// Current player's score on top right
		float current_score_box_width = Screen.width*1/4;
		float current_score_box_unit = current_score_box_width/10;
		float current_score_box_height = current_score_box_unit*5;
		
		GUI.Label (new Rect (Screen.width - current_score_box_unit*5, 10, current_score_box_unit*4, current_score_box_unit*4), "8/10");
		GUI.Label (new Rect (Screen.width - current_score_box_unit*9, 10, current_score_box_unit*4, current_score_box_unit*4), AMan);
		
		// Other player's score's below that
		float others_score_box_width = Screen.width*1/8;
		float others_score_box_unit = others_score_box_width/10;
		
		GUI.Label (new Rect (Screen.width - others_score_box_unit*5, current_score_box_height, others_score_box_unit*4, others_score_box_unit*4), "6/10");
		GUI.Label (new Rect (Screen.width - others_score_box_unit*9, current_score_box_height, others_score_box_unit*4, others_score_box_unit*4), AMan);
		
		GUI.Label (new Rect (Screen.width - others_score_box_unit*5, current_score_box_height + others_score_box_unit*4, others_score_box_unit*4, others_score_box_unit*4), "5/10");
		GUI.Label (new Rect (Screen.width - others_score_box_unit*9, current_score_box_height + others_score_box_unit*4, others_score_box_unit*4, others_score_box_unit*4), AMan);
		
		GUI.Label (new Rect (Screen.width - others_score_box_unit*5, current_score_box_height + others_score_box_unit*8, others_score_box_unit*4, others_score_box_unit*4), "7/10");
		GUI.Label (new Rect (Screen.width - others_score_box_unit*9, current_score_box_height + others_score_box_unit*8, others_score_box_unit*4, others_score_box_unit*4), AMan);
	}
}
