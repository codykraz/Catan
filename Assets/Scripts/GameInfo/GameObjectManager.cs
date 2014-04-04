using UnityEngine;
using System.Collections;

public static class GameObjectManager {

	private static GameObjectList gameObjectList;

	public static void SetGameObjectList(GameObjectList objectList) {
		gameObjectList = objectList;
	}

	// Tiles
	public static GameObject GetTile(string name) {
		return gameObjectList.GetTile(name);
	}

	public static int GetTileCount() {
		return gameObjectList.GetTileCount();
	}

	public static string[] GetTileNames() {
		return gameObjectList.GetTileNames();
	}

	public static Texture2D GetTileTexture(string name) {
		return gameObjectList.GetTileTexture(name);
	}

	public static Tile GetTileScript(string name) {
		return gameObjectList.GetTileScript(name);
	}
}
