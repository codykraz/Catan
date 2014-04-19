using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class deck : MonoBehaviour
{
	public List<DevCard> cards;
	private int curCard = 0;

	void Shuffle(ref List<DevCard> list)  
	{  
		for (int i = 0; i < 10; i++) {
			System.Random rng = new System.Random ();  
			int n = list.Count;  
			while (n > 1) {  
				n--;  
				int k = rng.Next (n + 1);  
				devCard value = list [k];  
				list [k] = list [n];  
				list [n] = value;  
			}  
						
		}
	}

	// Use this for initialization
	void Awake ()
	{
		cards = new List<DevCard>{
			RoadBuilding,RoadBuilding,
			
			YearOfPlenty,YearOfPlenty,
			Monopoly, Monopoly,
			Victory,Victory,Victory,Victory,Victory,
			Knight,Knight,Knight,Knight,Knight,Knight,Knight,Knight,Knight,Knight,Knight,Knight,Knight,Knight
		};
		
		Shuffle(cards);
	}
	
	public DevCard draw(){
		if (curCard >= 25) {
			GameObject.Find(GameObject.Find("TurnController").GetComponent<TurnControllerScript>().currentPlayer).GetComponent<PlayerScript>().knightDevCard++;
			return Knight;
		}
		
		switch (cards[curCard]){
			case Knight:
				GameObject.Find(GameObject.Find("TurnController").GetComponent<TurnControllerScript>().currentPlayer).GetComponent<PlayerScript>().knightDevCard++;
				break;
			case Victory:
				GameObject.Find(GameObject.Find("TurnController").GetComponent<TurnControllerScript>().currentPlayer).GetComponent<PlayerScript>().victoryDevCard++;
				break;
			case Monopoly:
				GameObject.Find(GameObject.Find("TurnController").GetComponent<TurnControllerScript>().currentPlayer).GetComponent<PlayerScript>().monopolyDevCard++;
				break;
			case YearOfPlenty:
				GameObject.Find(GameObject.Find("TurnController").GetComponent<TurnControllerScript>().currentPlayer).GetComponent<PlayerScript>().yearOfPlentyDevCard++;
				break;
			case RoadBuilding:
				GameObject.Find(GameObject.Find("TurnController").GetComponent<TurnControllerScript>().currentPlayer).GetComponent<PlayerScript>().roadBuildingDevCard++;
				break;
			default:
				break;
		}
		
		
		return cards[curCard++];
		
	}
	
}

