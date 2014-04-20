using UnityEngine;
using System.Collections;

public class TurnControllerScript : MonoBehaviour
{
	public string currentPlayer = "Player1";
	
	public string[] turnOrder;

	public bool initialComplete = false;
	private bool reverse = false;

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
		turnOrder = new string[] {"Player1", "Player2", "Player3", "Player4"};
		shuffleArray(ref turnOrder);
		currentPlayer = turnOrder[0];
	}

	void initialNextTurn()
	{
		if(reverse)
		{
			if(turn == 1)
			{
				turn = 0;
				currentPlayer = turnOrder[0];
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
			if(turn == 2)
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

	void nextTurn()
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
