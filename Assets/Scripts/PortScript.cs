using UnityEngine;
using System.Collections;

public class PortScript : MonoBehaviour
{
	private PlayerScript player;

	public TileType resource = TileType.Desert;
	public int value = 3;

	public void takeControl()
	{
		player = GameObject.Find(GameObject.Find("TurnController").GetComponent<TurnControllerScript>().currentPlayer).GetComponent<PlayerScript>();

		if(resource == TileType.Desert)
		{
			player.brickTradeIn = Mathf.Min(player.brickTradeIn, value);
			player.oreTradeIn = Mathf.Min(player.oreTradeIn, value);
			player.sheepTradeIn = Mathf.Min(player.sheepTradeIn, value);
			player.wheatTradeIn = Mathf.Min(player.wheatTradeIn, value);
			player.woodTradeIn = Mathf.Min(player.woodTradeIn, value);
		}
		else if(resource == TileType.Brick)
		{
			player.brickTradeIn = Mathf.Min(player.brickTradeIn, value);
		}
		else if(resource == TileType.Ore)
		{
			player.oreTradeIn = Mathf.Min(player.oreTradeIn, value);
		}
		else if(resource == TileType.Sheep)
		{
			player.sheepTradeIn = Mathf.Min(player.sheepTradeIn, value);
		}
		else if(resource == TileType.Wheat)
		{
			player.wheatTradeIn = Mathf.Min(player.wheatTradeIn, value);
		}
		else if(resource == TileType.Wood)
		{
			player.woodTradeIn = Mathf.Min(player.woodTradeIn, value);
		}
	}
}
