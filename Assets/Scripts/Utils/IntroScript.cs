using UnityEngine;
using System.Collections;

public class IntroScript : MonoBehaviour {

	void OnGui() {


		if(GUI.Button(new Rect (0,0,100,50), "New Game")) {
			Application.LoadLevel("WorldMap");
		}
	}
}
