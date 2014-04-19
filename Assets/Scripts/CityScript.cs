using UnityEngine;
using System.Collections;

public class CityScript : MonoBehaviour
{
	public bool Player1CanBuildHere = false;
	public bool Player2CanBuildHere = false;
	public bool Player3CanBuildHere = false;
	public bool Player4CanBuildHere = false;

	private bool hasOwner = false;
	
	private PlayerScript player;
	
	private TurnControllerScript turnController;

	void Awake()
	{
		turnController = GameObject.Find("TurnController").GetComponent<TurnControllerScript>();
	}
	
	public bool build()
	{
		if(turnController.currentPlayer == "Player1" && Player1CanBuildHere == true
		   || turnController.currentPlayer == "Player2" && Player2CanBuildHere == true
		   || turnController.currentPlayer == "Player3" && Player3CanBuildHere == true
		   || turnController.currentPlayer == "Player4" && Player4CanBuildHere == true)
		{
			
			player = GameObject.Find(turnController.currentPlayer).GetComponent<PlayerScript>();
			this.renderer.material.color = player.playerColor;

			this.hasOwner = true;











			return true;
		}
		else
		{
			return false;
		}
	}

	public void Rolled(TileType tileType)
	{
		if(this.hasOwner == false)
		{
			return;
		}
		
		if(tileType == TileType.Brick)
		{
			player.brick += 2;
		}
		else if(tileType == TileType.Wood)
		{
			player.wood += 2;
		}
		else if(tileType == TileType.Ore)
		{
			player.ore += 2;
		}
		else if(tileType == TileType.Sheep)
		{
			player.sheep += 2;
		}
		else if(tileType == TileType.Wheat)
		{
			player.wheat += 2;
		}
	}
}
