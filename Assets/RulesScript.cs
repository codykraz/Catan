using UnityEngine;
using System.Collections;

public class RulesScript : MonoBehaviour {
	public GUIStyle g;

	private int rule = 0;

	public Texture2D R1, R2, R3;
	private Texture2D[] rules;
	private int buttonDivider = 1;

	void Start() {
		rules = new Texture2D[3];
		rules [0] = R1;
		rules [1] = R2;
		rules [2] = R3;
	}

	// Use this for initialization
	void OnGUI() {


		GUI.DrawTexture(new Rect(0, 0, Screen.width, 3 * Screen.height / 4), rules[rule], ScaleMode.ScaleToFit, true, 9.0f/12.0f);
		if (rule == 1)
			buttonDivider = 2;
		else
			buttonDivider = 1;
		if (rule > 0){
			if(GUI.Button(new Rect (0,7*Screen.height/8,Screen.width/buttonDivider,Screen.height/8), "Back",g)) {
				rule--;
			}
		}

		if (rule < 2){
			if (rule == 1){
				if(GUI.Button(new Rect (Screen.width/2,7*Screen.height/8,Screen.width/buttonDivider,Screen.height/8), "Next",g)) {
					rule++;
				}
			}
			
			else{
				if(GUI.Button(new Rect (0,7*Screen.height/8,Screen.width/buttonDivider,Screen.height/8), "Next",g)) {
					rule++;
				}
			}
		}
		if(GUI.Button(new Rect (0,6*Screen.height/8,Screen.width,Screen.height/8), "New Game",g)) {
			Application.LoadLevel("WorldMap");
		}
	}

}
