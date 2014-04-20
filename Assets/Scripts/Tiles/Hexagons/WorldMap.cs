using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Linq;

public class WorldMap : MonoBehaviour {
	
	public int mapWidth;
	public int mapHeight;

	public List<TileType> board;
	public List<int> numbers;
	
	public HashSet<Vector3> intersections;
	public HashSet<Vector3> edges30, edges60, edges;

    protected Dictionary<Vector2, Hex> hexes { get; set; }

	void Shuffle(ref List<TileType> list)  
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
	}

	void Shuffle(ref List<int> list)  
	{  
		for (int i = 0; i < 10; i++) {
			System.Random rng = new System.Random ();  
			int n = list.Count;  
			while (n > 1) {  
				n--;  
				int k = rng.Next (n + 1);  
				int value = list [k];  
				list [k] = list [n];  
				list [n] = value;  
			}  
		}
	}

	void Awake () {
		board = new List<TileType> {
			TileType.Desert,
			TileType.Brick,TileType.Brick,TileType.Brick,
			TileType.Ore,TileType.Ore,TileType.Ore,
			TileType.Wood,TileType.Wood,TileType.Wood,TileType.Wood,
			TileType.Sheep,TileType.Sheep,TileType.Sheep,TileType.Sheep,
			TileType.Wheat,TileType.Wheat,TileType.Wheat,TileType.Wheat
		};

		numbers = new List<int> {
			2,3,3,4,4,5,5,6,6,8,8,9,9,10,10,11,11,12
		};
		
		intersections = new HashSet<Vector3>();
		edges = new HashSet<Vector3>();
		edges30 = new HashSet<Vector3>();
		edges60 = new HashSet<Vector3>();
		int hexCount = 0;
		int numCount = 0;
        hexes = new Dictionary<Vector2, Hex>();
		Shuffle (ref board);
		Shuffle (ref numbers);
		for (int y = 0; y < mapHeight; y++) {
		    for (int x = 0; x < mapWidth; x++) {
				if (((x==0 || x==4) && (y==0||y==4)) || (x==4 &&  (y==1||y==3))) continue;
	            Vector2 position = new Vector2(x, y);
	            Vector3 pos = ToPixel(position);
	            
	            edges.Add(new Vector3(pos.x+HexGlobals.Radius* Mathf.Sqrt(3)/2, pos.y, pos.z));
	            edges.Add(new Vector3(pos.x-HexGlobals.Radius* Mathf.Sqrt(3)/2, pos.y, pos.z));
	            edges60.Add(new Vector3(pos.x+2*Mathf.Sqrt(3), pos.y, pos.z+6));
	            edges30.Add(new Vector3(pos.x+2*Mathf.Sqrt(3), pos.y, pos.z-6));
	            edges30.Add(new Vector3(pos.x-2*Mathf.Sqrt(3), pos.y, pos.z+6));
	            edges60.Add(new Vector3(pos.x-2*Mathf.Sqrt(3), pos.y, pos.z-6));
	            
	            intersections.Add(new Vector3(pos.x, pos.y, pos.z+HexGlobals.Radius));
	            intersections.Add(new Vector3(pos.x, pos.y, pos.z-HexGlobals.Radius));//* Mathf.Sqrt(3)/2)
	            intersections.Add(new Vector3(pos.x+HexGlobals.Radius* Mathf.Sqrt(3)/2, pos.y, pos.z+HexGlobals.Radius/2));
	            intersections.Add(new Vector3(pos.x+HexGlobals.Radius* Mathf.Sqrt(3)/2, pos.y, pos.z-HexGlobals.Radius/2));
	            intersections.Add(new Vector3(pos.x-HexGlobals.Radius* Mathf.Sqrt(3)/2, pos.y, pos.z+HexGlobals.Radius/2));
	            intersections.Add(new Vector3(pos.x-HexGlobals.Radius* Mathf.Sqrt(3)/2, pos.y, pos.z-HexGlobals.Radius/2));
	            

	            GameObject hexObject = new GameObject();

				if (board[hexCount] != TileType.Desert){
					GameObject tile = (GameObject)Instantiate(Resources.Load(numbers[numCount].ToString()));
					tile.transform.parent = this.transform;
					tile.transform.position = pos+ new Vector3(0,1,0);
					hexObject.tag = numbers[numCount].ToString();
				}

				hexObject.transform.localPosition = pos;
				hexObject.transform.parent = this.transform;
				hexObject.AddComponent("Hex");
	            Hex hex = hexObject.GetComponent<Hex>();
	            hex.hexPosition = position;

				if (board[hexCount] != TileType.Desert)
					hex.InitializeModel(board[hexCount], numbers[numCount++]);
				else hex.InitializeModel(board[hexCount], 0);

	            hexes.Add(position, hex);
				hexCount++;

		    }
		}
		
		IEnumerable<Vector3> distinctIntersections = intersections.Distinct();
		IEnumerable<Vector3> distinctEdges30 = edges30.Distinct();
		IEnumerable<Vector3> distinctEdges60 = edges60.Distinct();
		IEnumerable<Vector3> distinctEdges = edges.Distinct();
		foreach (Vector3 position in distinctIntersections){
			GameObject settlement = (GameObject)Instantiate(Resources.Load("Settlement"));
			settlement.transform.position = position;
		}
		foreach (Vector3 position in distinctEdges) {
			GameObject road = (GameObject)Instantiate(Resources.Load("Road"));
			road.transform.position = position;
		}
		foreach (Vector3 position in distinctEdges30) {
			GameObject road = (GameObject)Instantiate(Resources.Load("Road"));
			road.transform.position = position;
			road.transform.eulerAngles = new Vector3(0,30,0);
		}
		foreach (Vector3 position in distinctEdges60) {
			GameObject road = (GameObject)Instantiate(Resources.Load("Road"));
			road.transform.position = position;
			road.transform.eulerAngles = new Vector3(0,-60,0);
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
