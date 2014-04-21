using UnityEngine;
using System.Collections;

public class RoadScript : MonoBehaviour
{
	public bool Player1CanBuildHere = false;
	public bool Player2CanBuildHere = false;
	public bool Player3CanBuildHere = false;
	public bool Player4CanBuildHere = false;

	public bool hasOwner = false;
	
	private PlayerScript player;
	
	private TurnControllerScript turnController;
	
	void Awake()
	{
		turnController = GameObject.Find("TurnController").GetComponent<TurnControllerScript>();
	}

	public bool build()
	{
		if(this.hasOwner == true)
		{
			return false;
		}

		if((turnController.currentPlayer == "Player1" && Player1CanBuildHere == true)
		   || (turnController.currentPlayer == "Player2" && Player2CanBuildHere == true)
		   || (turnController.currentPlayer == "Player3" && Player3CanBuildHere == true)
		   || (turnController.currentPlayer == "Player4" && Player4CanBuildHere == true))
		{

			this.hasOwner = true;

			player = GameObject.Find(turnController.currentPlayer).GetComponent<PlayerScript>();
			this.renderer.material.color = player.playerColor;
			this.renderer.enabled = true;

			Collider[] colliders = Physics.OverlapSphere(this.transform.position, 6, 1 << LayerMask.NameToLayer("Settlement"));
			
			foreach(Collider coll in colliders)
			{
				if(turnController.currentPlayer == "Player1")
				{
					coll.GetComponent<SettlementScript>().Player1CanBuildHere = true;
				}
				else if(turnController.currentPlayer == "Player2")
				{
					coll.GetComponent<SettlementScript>().Player2CanBuildHere = true;
				}
				else if(turnController.currentPlayer == "Player3")
				{
					coll.GetComponent<SettlementScript>().Player3CanBuildHere = true;
				}
				else if(turnController.currentPlayer == "Player4")
				{
					coll.GetComponent<SettlementScript>().Player4CanBuildHere = true;
				}
			}

			Collider[] colliders2 = Physics.OverlapSphere(this.transform.position, 12, 1 << LayerMask.NameToLayer("Road"));

			foreach(Collider coll in colliders2)
			{
				if(turnController.currentPlayer == "Player1")
				{
					coll.GetComponent<RoadScript>().Player1CanBuildHere = true;
				}
				else if(turnController.currentPlayer == "Player2")
				{
					coll.GetComponent<RoadScript>().Player2CanBuildHere = true;
				}
				else if(turnController.currentPlayer == "Player3")
				{
					coll.GetComponent<RoadScript>().Player3CanBuildHere = true;
				}
				else if(turnController.currentPlayer == "Player4")
				{
					coll.GetComponent<RoadScript>().Player4CanBuildHere = true;
				}
			}

			return true;
		}
		else
		{
			return false;
		}
	}
}
