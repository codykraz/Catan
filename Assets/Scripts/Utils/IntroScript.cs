using UnityEngine;
using System.Collections;

public class IntroScript : MonoBehaviour {
	public Texture2D pic;

	void Awake(){

	}

	void OnGUI() {
		GUI.DrawTexture(new Rect(0, 0, Screen.width, 3 * Screen.height / 4), pic, ScaleMode.ScaleToFit, true, 9.0f/12.0f);
		if(GUI.Button(new Rect (0,7*Screen.height/8,Screen.width,Screen.height/8), "Rules")) {
			Application.LoadLevel("Rules");
		}
		if(GUI.Button(new Rect (0,6*Screen.height/8,Screen.width,Screen.height/8), "New Game")) {
			Application.LoadLevel("WorldMap");
		}
	}
}
