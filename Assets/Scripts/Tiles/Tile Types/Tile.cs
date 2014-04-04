using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Tile : MonoBehaviour {
	
	public TileType type;
	public Texture2D texture;


	protected virtual void Awake () {
		Init(TileType.Desert);
	}

	protected virtual void Update() {}

	protected void Init(TileType type) {
		this.type = type;
	}
}
