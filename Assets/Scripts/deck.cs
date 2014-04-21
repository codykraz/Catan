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
				DevCard value = list [k];  
				list [k] = list [n];  
				list [n] = value;  
			}  
						
		}
	}

	// Use this for initialization
	void Awake ()
	{
		cards = new List<DevCard>{
			DevCard.RoadBuilding,DevCard.RoadBuilding,
			
			DevCard.YearOfPlenty,DevCard.YearOfPlenty,
			DevCard.Monopoly, DevCard.Monopoly,
			DevCard.Victory,DevCard.Victory,DevCard.Victory,DevCard.Victory,DevCard.Victory,
			DevCard.Knight,DevCard.Knight,DevCard.Knight,DevCard.Knight,DevCard.Knight,
			DevCard.Knight,DevCard.Knight,DevCard.Knight,DevCard.Knight,DevCard.Knight,
			DevCard.Knight,DevCard.Knight,DevCard.Knight,DevCard.Knight
		};
		
		Shuffle(ref cards);
	}
	
	public DevCard draw(){
		if (curCard >= 25) {
			GameObject.Find(GameObject.Find("TurnController").GetComponent<TurnControllerScript>().currentPlayer).GetComponent<PlayerScript>().knightDevCard++;
			return DevCard.Knight;
		}
		
		switch (cards[curCard]){
			case DevCard.Knight:
				GameObject.Find(GameObject.Find("TurnController").GetComponent<TurnControllerScript>().currentPlayer).GetComponent<PlayerScript>().knightDevCard++;
				break;
			case DevCard.Victory:
				GameObject.Find(GameObject.Find("TurnController").GetComponent<TurnControllerScript>().currentPlayer).GetComponent<PlayerScript>().victoryDevCard++;
				break;
			case DevCard.Monopoly:
				GameObject.Find(GameObject.Find("TurnController").GetComponent<TurnControllerScript>().currentPlayer).GetComponent<PlayerScript>().monopolyDevCard++;
				break;
			case DevCard.YearOfPlenty:
				GameObject.Find(GameObject.Find("TurnController").GetComponent<TurnControllerScript>().currentPlayer).GetComponent<PlayerScript>().yearOfPlentyDevCard++;
				break;
			case DevCard.RoadBuilding:
				GameObject.Find(GameObject.Find("TurnController").GetComponent<TurnControllerScript>().currentPlayer).GetComponent<PlayerScript>().roadBuildingDevCard++;
				break;
			default:
				break;
		}
		
		
		return cards[curCard++];
		
	}
	
}

