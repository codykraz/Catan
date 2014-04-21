using UnityEngine;
using System.Collections;

public class DiceRollScript : MonoBehaviour {

	public int diceRoll = -1;

	public int roll()
	{
		diceRoll = Random.Range(1, 6) + Random.Range(1, 6);

		Debug.Log (diceRoll);

		if(diceRoll == 7)
		{
			return diceRoll;
		}

		GameObject[] hexes = GameObject.FindGameObjectsWithTag(diceRoll.ToString());

		foreach(GameObject hex in hexes)
		{
			hex.GetComponent<Hex>().Rolled();
		}

		return diceRoll;
	}
}
