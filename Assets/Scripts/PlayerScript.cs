﻿using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
	public Color playerColor = Color.black;

	public int victoryPoints = 0;

	public int handSize = 0;

	public int brick = 0;
	public int wheat = 0;
	public int sheep = 0;
	public int wood = 0;
	public int ore = 0;

	public bool hasLongestRoad = false;
	public int longestRoadCount = 0;

	public bool hasLargestArmy = false;
	public int largestArmyCount = 0;

	public int citiesUsed = 0;
	public int maxCities = 4;
	public int settlementsUsed = 0;
	public int maxSettlements = 5;
	public int roadsUsed = 0;
	public int maxRoads = 15;

	public int brickTradeIn = 4;
	public int wheatTradeIn = 4;
	public int sheepTradeIn = 4;
	public int woodTradeIn = 4;
	public int oreTradeIn = 4;

	public int victoryDevCard = 0;
	public int monopolyDevCard = 0;
	public int roadBuildingDevCard = 0;
	public int yearOfPlentyDevCard = 0;
	public int knightDevCard = 0;

	public string lastDevCardRecieved = "";

	void Update()
	{
		victoryPoints = settlementsUsed + citiesUsed * 2 + victoryDevCard;

		if(hasLargestArmy == true)
		{
			victoryPoints += 2;
		}

		if(hasLongestRoad == true)
		{
			victoryPoints += 2;
		}

		handSize = wood + brick + ore + sheep + wheat;
	}
}
