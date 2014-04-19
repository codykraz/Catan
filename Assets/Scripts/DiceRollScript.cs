using UnityEngine;
using System.Collections;

public class DiceRollScript : MonoBehaviour {

	public int diceRoll = -1;

	void roll()
	{
		diceRoll = Random.Range(1, 6) + Random.Range(1, 6);

		if(diceRoll == 7)
		{
			//CALL ROBBER
			return;
		}

		GameObject[] numbers = GameObject.FindGameObjectsWithTag(diceRoll.ToString());


	}
}
