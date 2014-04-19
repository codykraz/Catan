using UnityEngine;
using System.Collections;

public class CityScript : MonoBehaviour
{
	private PlayerScript player;
	private TurnControllerScript turnController;

	void Start()
	{
		turnController = GameObject.Find("TurnController").GetComponent<TurnControllerScript>();
		player = GameObject.Find(turnController.currentPlayer).GetComponent<PlayerScript>();
		player.renderer.material.color = player.playerColor;

		Collider[] colliders = Physics.OverlapSphere(this.transform.position, 4, LayerMask.NameToLayer ("Settlement"));

		player.citiesUsed++;
		player.settlementsUsed--;

		Destroy(colliders[0].gameObject);
	}

	public void Rolled(TileType tileType)
	{		
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
