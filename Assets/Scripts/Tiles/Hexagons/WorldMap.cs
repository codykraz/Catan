using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class WorldMap : MonoBehaviour {
	
	public int mapWidth;
	public int mapHeight;

	public List<TileType> board;

    protected Dictionary<Vector2, Hex> hexes { get; set; }

	List<TileType> Shuffle(List<TileType> list)  
	{  
		for (int i = 0; i < 10; i++) {
						System.Random rng = new System.Random ();  
						int n = list.Count;  
						while (n > 1) {  
								n--;  
								int k = rng.Next (n + 1);  
								TileType value = list [k];  
								list [k] = list [n];  
								list [n] = value;  
						}  
				}
		return list;
	}

	void Start () {
		board = new List<TileType> {
			TileType.Desert,
			TileType.Brick,TileType.Brick,TileType.Brick,
			TileType.Ore,TileType.Ore,TileType.Ore,
			TileType.Wood,TileType.Wood,TileType.Wood,TileType.Wood,
			TileType.Sheep,TileType.Sheep,TileType.Sheep,TileType.Sheep,
			TileType.Wheat,TileType.Wheat,TileType.Wheat,TileType.Wheat
		};
		int hexCount = 0;
        hexes = new Dictionary<Vector2, Hex>();
		board = Shuffle (board);
		for (int y = 0; y < mapHeight; y++) {
		    for (int x = 0; x < mapWidth; x++) {
				if (((x==0 || x==4) && (y==0||y==4)) || (x==4 &&  (y==1||y==3))) continue;
	            Vector2 position = new Vector2(x, y);
	            Vector3 pos = ToPixel(position);

	            GameObject hexObject = new GameObject();
				hexObject.transform.localPosition = pos;
				hexObject.transform.parent = this.transform;
				hexObject.AddComponent("Hex");

	            Hex hex = hexObject.GetComponent<Hex>();
	            hex.hexPosition = position;
	            hex.InitializeModel(board[hexCount]);

	            hexes.Add(position, hex);
				hexCount++;

		    }
		}
	}

	public List<Vector2> GetNeighbors(int x, int y) {
		List<Vector2> list = new List<Vector2>();
		for (int row = y - 1; row <= y + 1; row++) {
			for (int col = x - 1; col <= x + 1; col++) {
				if (col >= 0 && col < mapWidth && row >= 0 && row < mapHeight)
					if (((x==0 || x==4) && (y==0||y==4)) || (x==4 &&  (y==1||y==3))) continue;
					list.Add(new Vector2(col, row));
			}
		}
		return list;
	}

	public Vector2 MapHexCenter() {
		return new Vector2((mapWidth - 1)/ 2, (mapHeight - 1) / 2);
	}

	public Vector3 MapGlobalCenter() {
		Vector2 hexCenter = MapHexCenter();
		return new Vector3(((float)hexCenter.x * (HexGlobals.Width - HexGlobals.Radius)),
		                   0,
		                   ((float)hexCenter.y * (HexGlobals.Height - HexGlobals.Radius)));
	}

    private Vector2 ToHex(Vector3 pos) {
        var px = pos.x + HexGlobals.HalfWidth;
        var py = pos.z + HexGlobals.Radius;

        int gridX = (int)Math.Floor(px / HexGlobals.Width);
        int gridY = (int)Math.Floor(py / HexGlobals.RowHeight);

        float gridModX = Math.Abs(px % HexGlobals.Width);
        float gridModY = Math.Abs(py % HexGlobals.RowHeight);

        bool gridTypeA = (gridY % 2) == 0;

        var resultY = gridY;
        var resultX = gridX;
        var m = HexGlobals.ExtraHeight / HexGlobals.HalfWidth;

        if (gridTypeA) {
            // middle
            resultY = gridY;
            resultX = gridX;
            // left
            if (gridModY < (HexGlobals.ExtraHeight - gridModX * m)) {
                resultY = gridY - 1;
                resultX = gridX - 1;
            }
            // right
            else if (gridModY < (-HexGlobals.ExtraHeight + gridModX * m)) {
                resultY = gridY - 1;
                resultX = gridX;
            }
        }
        else {
            if (gridModX >= HexGlobals.HalfWidth) {
                if (gridModY < (2 * HexGlobals.ExtraHeight - gridModX * m)) {
                    // Top
                    resultY = gridY - 1;
                    resultX = gridX;
                }
                else {
                    // Right
                    resultY = gridY;
                    resultX = gridX;
                }
            }

            if (gridModX < HexGlobals.HalfWidth) {
                if (gridModY < (gridModX * m)) {
                    // Top
                    resultY = gridY - 1;
                    resultX = gridX;
                }
                else {
                    // Left
                    resultY = gridY;
                    resultX = gridX - 1;
                }
            }
        }

        return new Vector3(resultX, resultY);
	}

    private Vector3 ToPixel(Vector2 hexCell) {
        float x = (hexCell.x * HexGlobals.Width) + (((int)hexCell.y & 1) * HexGlobals.Width / 2);
        return new Vector3(x, 0f, (float)(hexCell.y * 1.5 * HexGlobals.Radius));
    }

    public IEnumerable<Vector2> GetRing(Vector2 hexCord, int ring) {
        Vector2 left = new Vector2(hexCord.x - ring, hexCord.y);
        yield return left;

        float tx = left.x;
        float ty = left.y;
        for (int i = 1; i < ring + 1; i++) {
            tx = NextX(tx, ty);
            ty = ty + 1;
            yield return new Vector2(tx, ty);
        }

        float bx = left.x;
        float by = left.y;
        for (int i = 1; i < ring + 1; i++) {
            bx = NextX(bx, by);
            by = by - 1;
            yield return new Vector2(bx, by);
        }

        for (int i = 1; i <= ring; i++) {
            yield return new Vector2(tx + i, ty);
            yield return new Vector2(bx + i, by);
        }

        tx += ring;
        bx += ring;
        for (int i = 1; i < ring; i++) {
            tx = NextX(tx, ty);
            ty = ty - 1;
            yield return new Vector2(tx, ty);
        }

        for (int i = 1; i < ring; i++) {
            bx = NextX(bx, by);
            by = by + 1;
            yield return new Vector2(bx, by);
        }

        yield return new Vector2(hexCord.x + ring, hexCord.y);
    }

    private int NextX(float x, float y) {
        if (y % 2 == 0) return (int)x;
        else return (int)(x + 1);
    }
}
