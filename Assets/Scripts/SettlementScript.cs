using UnityEngine;
using System.Collections;

public class SettlementScript : MonoBehaviour
{
	public bool Player1CanBuildHere = false;
	public bool Player2CanBuildHere = false;
	public bool Player3CanBuildHere = false;
	public bool Player4CanBuildHere = false;

	public GameObject city;
	
	private bool nearbySettlement = false;

	private bool hasOwner = false;

	private PlayerScript player;

	private TurnControllerScript turnController;

	void Awake()
	{
		turnController = GameObject.Find("TurnController").GetComponent<TurnControllerScript>();
	}

	public bool buildInitial()
	{
		if(this.nearbySettlement == true)
		{
			return false;
		}

		player = GameObject.Find(turnController.currentPlayer).GetComponent<PlayerScript>();
		this.renderer.material.color = player.playerColor;
		player.settlementsUsed++;

		this.nearbySettlement = true;
		this.hasOwner = true;

		Collider[] colliders = Physics.OverlapSphere(this.transform.position, 12, LayerMask.NameToLayer("Settlement"));

		foreach(Collider coll in colliders)
		{
			coll.GetComponent<SettlementScript>().nearbySettlement = true;
		}

		checkForPorts();

		return true;
	}

	public bool build()
	{
		if(this.nearbySettlement == true)
		{
			return false;
		}

		if((turnController.currentPlayer == "Player1" && Player1CanBuildHere == true)
		   || (turnController.currentPlayer == "Player2" && Player2CanBuildHere == true)
		   || (turnController.currentPlayer == "Player3" && Player3CanBuildHere == true)
		   || (turnController.currentPlayer == "Player4" && Player4CanBuildHere == true))
		{
			
			player = GameObject.Find(turnController.currentPlayer).GetComponent<PlayerScript>();
			this.renderer.material.color = player.playerColor;
			
			this.nearbySettlement = true;
			this.hasOwner = true;
			
			Collider[] colliders = Physics.OverlapSphere(this.transform.position, 12, LayerMask.NameToLayer("Settlement"));
			
			foreach(Collider coll in colliders)
			{
				coll.GetComponent<SettlementScript>().nearbySettlement = true;
			}

			checkForPorts();

			return true;
		}
		else
		{
			return false;
		}
	}

	public bool buildCity()
	{
		if(this.hasOwner == false)
		{
			return false;
		}

		if((turnController.currentPlayer == "Player1" && player.gameObject.name == "Player1")
		   || (turnController.currentPlayer == "Player2" && player.gameObject.name == "Player2")
		   || (turnController.currentPlayer == "Player3" && player.gameObject.name == "Player3")
		   || (turnController.currentPlayer == "Player4" && player.gameObject.name == "Player4"))
		{
			Instantiate(city, this.transform.position, this.transform.rotation);

			return true;
		}
		else
		{
			return false;
		}
	}

	private void checkForPorts()
	{
		Collider[] colliders = Physics.OverlapSphere(this.transform.position, 6, LayerMask.NameToLayer("Port"));

		if(colliders.Length > 0)
		{
			foreach(Collider coll in colliders)
			{
				coll.GetComponent<PortScript>().takeControl();
			}
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
			player.brick++;
		}
		else if(tileType == TileType.Wood)
		{
			player.wood++;
		}
		else if(tileType == TileType.Ore)
		{
			player.ore++;
		}
		else if(tileType == TileType.Sheep)
		{
			player.sheep++;
		}
		else if(tileType == TileType.Wheat)
		{
			player.wheat++;
		}
	}
}
