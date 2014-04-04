using UnityEngine;
using System.Collections;

public class Desert : Tile {

	protected override void Awake () {
		Init(TileType.Desert);
	}

}
