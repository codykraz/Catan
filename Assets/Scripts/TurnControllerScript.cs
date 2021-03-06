﻿using UnityEngine;
using System.Collections;

public class TurnControllerScript : MonoBehaviour
{
	public string currentPlayer = "Player1";
	public int numPlayers = 4;
	
	public string[] turnOrder;

	public bool initialComplete = false;
	public bool reverse = false;

	private int turn = 0;

	void shuffleArray(ref string[] arr)
	{
		for(int i = arr.Length - 1; i > 0; i--)
		{
			int r = Random.Range(0, i); 
			string temp = arr[i];
			arr[i] = arr[r];
			arr[r] = temp;
		}
	}

	void Awake()
	{
		if (numPlayers == 4)
			turnOrder = new string[] {"Player1", "Player2", "Player3", "Player4"};
		else
			turnOrder = new string[] {"Player1", "Player2", "Player3"};
		shuffleArray(ref turnOrder);
		currentPlayer = turnOrder[0];
	}

	public void initialNextTurn()
	{
		if(reverse)
		{
			if (turn == 0)
			{
				initialComplete = true;
			}
			else
			{
				turn--;
				currentPlayer = turnOrder[turn];
			}
		}
		else
		{
			if(turn == 3)
			{
				turn = 3;
				currentPlayer = turnOrder[3];
				reverse = true;
			}
			else
			{
				turn++;
				currentPlayer = turnOrder[turn];
			}
		}
	}

	public void nextTurn()
	{
		if(turn == 3)
		{
			turn = 0;
			currentPlayer = turnOrder[0];
		}
		else
		{
			turn++;
			currentPlayer = turnOrder[turn];
		}
	}

}
