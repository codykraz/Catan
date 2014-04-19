using UnityEngine;
using System.Collections;

public class CityScript : MonoBehaviour
{
	public bool canBuildHere = true;
	
	private bool hasOwner = false;
	
	private PlayerScript player;
	
	private TurnControllerScript turnController;
	
	void Awake()
	{
		turnController = GameObject.Find("TurnController").GetComponent<TurnControllerScript>();
	}
	
	public bool buildInitial()
	{
		if(this.canBuildHere == false)
		{
			return false;
		}
		
		player = GameObject.Find(turnController.currentPlayer).GetComponent<PlayerScript>();
		this.renderer.material.color = player.playerColor;
		
		this.canBuildHere = false;
		this.hasOwner = true;
		
		Collider[] colliders = Physics.OverlapSphere(this.transform.position, 12, LayerMask.NameToLayer("City"));
		
		foreach(Collider coll in colliders)
		{
			coll.GetComponent<CityScript>().canBuildHere = false;
		}
		
		return true;
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
