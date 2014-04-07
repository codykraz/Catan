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
		GUI.Label (new Rect (50, 10, 40, 40), current_player_score.ToString());
		GUI.Label (new Rect (10, 10, 40, 40), GameObjectManager.GetTileTexture("Wood"));

		GUI.Label (new Rect (140, 10, 40, 40), current_player_score.ToString());
		GUI.Label (new Rect (100, 10, 40, 40), GameObjectManager.GetTileTexture("Ore"));

		GUI.Label (new Rect (230, 10, 40, 40), current_player_score.ToString());
		GUI.Label (new Rect (190, 10, 40, 40), GameObjectManager.GetTileTexture("Brick"));

		GUI.Label (new Rect (320, 10, 40, 40), current_player_score.ToString());
		GUI.Label (new Rect (280, 10, 40, 40), GameObjectManager.GetTileTexture("Wheat"));

		GUI.Label (new Rect (410, 10, 40, 40), current_player_score.ToString());
		GUI.Label (new Rect (370, 10, 40, 40), GameObjectManager.GetTileTexture("Sheep"));
	}
}
