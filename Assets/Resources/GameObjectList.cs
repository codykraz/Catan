using UnityEngine;
using System.Collections;

public class GameObjectList : MonoBehaviour {

	public GameObject[] tiles;
	
	private static bool created = false;
	
	void Awake() {
		if(!created) {
			DontDestroyOnLoad(transform.gameObject);
			GameObjectManager.SetGameObjectList(this);
			created = true;
		}
		else {
			Destroy(gameObject);
		}
	}

	public GameObject GetTile(string name) {
		for (int i = 0; i < tiles.Length; i++) {
			if (tiles[i].name == name)
				return tiles[i];
		}
		return null;
	}

	public int GetTileCount() {
		return tiles.Length;
	}

	public string[] GetTileNames() {
		string[] names = new string[tiles.Length];
		for(int i = 0; i < tiles.Length; i++) {
			names[i] = tiles[i].name;
		}
		return names;
	}

	public Texture2D GetTileTexture(string name) {
		for (int i = 0; i < tiles.Length; i++) {
			Texture2D text = tiles[i].GetComponent<Tile>().texture;
			if (text && tiles[i].name == name)
				return text;
		}
		return null;
	}

	public Tile GetTileScript(string name) {
		for (int i = 0; i < tiles.Length; i++) {
			Tile script = (Tile)tiles[i].GetComponent(name);
			if (script && tiles[i].name == name)
				return script;
		}
		return null;
	}


}

