using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer), typeof(MeshCollider))]
public class Hex : MonoBehaviour {

    public Vector2 hexPosition;
    public HexModel hexModel { get; set; }
	public TileType tileType;
	private int tileVal;
	protected Tile tileScript;
	public bool blocked = false;
	private int settlementObjects = 0;
	private GameObject[] settlements = new GameObject[6];
	
	
	protected MeshRenderer meshRenderer;
	protected MeshCollider meshCollider;

	public void InitializeModel(TileType t, int value) {
		gameObject.name = "Hex";
		gameObject.AddComponent("HexModel");
        hexModel = GetComponent<HexModel>();
		renderer.material.shader = Shader.Find("Diffuse");  

		meshRenderer = GetComponent<MeshRenderer>();
		meshCollider = GetComponent<MeshCollider>();
		tileVal = value;

		SetTileType(t);
    }


	public void SetTileType(TileType type) {
		// Tile type enum
		this.tileType = type;

		if(type == TileType.Desert)
		{
			GameObject robber = GameObject.Find("Robber");
			robber.transform.position = this.transform.position;
			this.blocked = true;
		}

		// Set Texture
		Texture2D text = GameObjectManager.GetTileTexture(type.ToString());
		if (text != null)
			meshRenderer.sharedMaterial.mainTexture = text;

		// Get Tile Script
		Tile script = GameObjectManager.GetTileScript(type.ToString());
		if (script != null)
			tileScript = script;
	}

	void OnCollisionEnter(Collision coll)
	{
		if(coll.gameObject.CompareTag("Settlement"))
		{
			addSettlement(coll.gameObject);
		}
	}
	
	public void addSettlement(GameObject settlement){
		settlements[settlementObjects] = settlement;
		settlementObjects++;
		
	}
	
	public void Rolled(){
		if (!blocked){
			for (int i = 0; i < settlementObjects; i++){
				settlements[i].GetComponent<SettlementScript>().Rolled(tileType);
			}
		}
		
	}

}
