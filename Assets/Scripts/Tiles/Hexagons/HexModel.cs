using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer), typeof(MeshCollider))]
public class HexModel : MonoBehaviour {
	
    protected Vector3[] Vertices;
    protected Vector3[] Normals;
    protected Vector2[] UV;
    protected int[] Triangles;

	protected MeshFilter meshFilter;
	protected MeshCollider meshCollider;

	void Awake () {
        Vertices = new Vector3[24];
        UV = new Vector2[24];

        DrawTopAndBottom();
        DrawSides();
        SetTriangles();

        Mesh mesh = new Mesh { name = "Hex Mesh" };
        mesh.vertices = Vertices;
        mesh.uv = UV;
        mesh.triangles = Triangles;
        mesh.normals = Normals;

		meshFilter = GetComponent<MeshFilter>();
		meshCollider = GetComponent<MeshCollider>();

		meshFilter.mesh = mesh;
		meshCollider.sharedMesh = mesh;
	}

    private void SetTriangles() {
        Normals = new Vector3[]
            {
                new Vector3(0, 1, 0),
                new Vector3(0, 1, 0),
                new Vector3(0, 1, 0),
                new Vector3(0, 1, 0),
                new Vector3(0, 1, 0),
                new Vector3(0, 1, 0),

                new Vector3(1, 0, 0),
                new Vector3(1, 0, 1),
                new Vector3(-1, 0, 1),
                new Vector3(-1, 0, 0),
                new Vector3(-1, 0, -1),
                new Vector3(1, 0, -1),

                new Vector3(1, 0, 0),
                new Vector3(1, 0, 1),
                new Vector3(-1, 0, 1),
                new Vector3(-1, 0, 0),
                new Vector3(-1, 0, -1),
                new Vector3(1, 0, -1),

                new Vector3(0, -1, 0),
                new Vector3(0, -1, 0),
                new Vector3(0, -1, 0),
                new Vector3(0, -1, 0),
                new Vector3(0, -1, 0),
                new Vector3(0, -1, 0),
            };

        Triangles = new int[]
            {
                1, 0, 5, 2, 4, 3, 2, 1, 4, 1, 5, 4,
                7, 12, 6, 7, 13, 12,
                8, 13, 7, 8, 14, 13,
                9, 14, 8, 9, 15, 14,
                10, 15, 9, 10, 16, 15,
                11, 16, 10, 11, 17, 16,
                6, 17, 11, 6, 12, 17,
                19, 23, 18, 20, 21, 22, 20, 23, 19, 20, 22, 23
            };
    }

    private void DrawTopAndBottom() {
        //top
        Vertices[0] = new Vector3(0, 0, -HexGlobals.Radius);
        UV[0] = new Vector2(0.5f, 1);
        //topright
        Vertices[1] = new Vector3(HexGlobals.HalfWidth, 0, -HexGlobals.Radius / 2);
        UV[1] = new Vector2(1, 0.75f);
        //bottomright
        Vertices[2] = new Vector3(HexGlobals.HalfWidth, 0, HexGlobals.Radius / 2);
        UV[2] = new Vector2(1, 0.25f);
        //bottom
        Vertices[3] = new Vector3(0, 0, HexGlobals.Radius);
        UV[3] = new Vector2(0.5f, 0);
        //bottomleft
        Vertices[4] = new Vector3(-HexGlobals.HalfWidth, 0, HexGlobals.Radius / 2);
        UV[4] = new Vector2(0, 0.25f);
        //topleft
        Vertices[5] = new Vector3(-HexGlobals.HalfWidth, 0, -HexGlobals.Radius / 2);
        UV[5] = new Vector2(0, 0.75f);

        //top
        Vertices[18] = new Vector3(0, -1, -HexGlobals.Radius);
        UV[18] = new Vector2(0.5f, 1);
        //topright
        Vertices[19] = new Vector3(HexGlobals.HalfWidth, -1, -HexGlobals.Radius / 2);
        UV[19] = new Vector2(1, 0.75f);
        //bottomright
        Vertices[20] = new Vector3(HexGlobals.HalfWidth, -1, HexGlobals.Radius / 2);
        UV[20] = new Vector2(1, 0.25f);
        //bottom
        Vertices[21] = new Vector3(0, -1, HexGlobals.Radius);
        UV[21] = new Vector2(0.5f, 0);
        //bottomleft
        Vertices[22] = new Vector3(-HexGlobals.HalfWidth, -1, HexGlobals.Radius / 2);
        UV[22] = new Vector2(0, 0.25f);
        //topleft
        Vertices[23] = new Vector3(-HexGlobals.HalfWidth, -1, -HexGlobals.Radius / 2);
        UV[23] = new Vector2(0, 0.75f);
    }

    private void DrawSides() {
        //top
        Vertices[6] = new Vector3(0, 0, -HexGlobals.Radius);
        UV[6] = new Vector2(0.5f, 1);
        //topright
        Vertices[7] = new Vector3(HexGlobals.HalfWidth, 0, -HexGlobals.Radius / 2);
        UV[7] = new Vector2(1, 0.75f);
        //bottomright
        Vertices[8] = new Vector3(HexGlobals.HalfWidth, 0, HexGlobals.Radius / 2);
        UV[8] = new Vector2(1, 0.25f);
        //bottom
        Vertices[9] = new Vector3(0, 0, HexGlobals.Radius);
        UV[9] = new Vector2(0.5f, 0);
        //bottomleft
        Vertices[10] = new Vector3(-HexGlobals.HalfWidth, 0, HexGlobals.Radius / 2);
        UV[10] = new Vector2(0, 0.25f);
        //topleft
        Vertices[11] = new Vector3(-HexGlobals.HalfWidth, 0, -HexGlobals.Radius / 2);
        UV[11] = new Vector2(0, 0.75f);

        //--------------------------------------

        //top
        Vertices[12] = new Vector3(0, -1, -HexGlobals.Radius);
        UV[12] = new Vector2(0, 0.75f);
        //topright
        Vertices[13] = new Vector3(HexGlobals.HalfWidth, -1, -HexGlobals.Radius / 2);
        UV[13] = new Vector2(0.5f, 1);
        //bottomright
        Vertices[14] = new Vector3(HexGlobals.HalfWidth, -1, HexGlobals.Radius / 2);
        UV[14] = new Vector2(1, 0.75f);
        //bottom
        Vertices[15] = new Vector3(0, -1, HexGlobals.Radius);
        UV[15] = new Vector2(1, 0.25f);
        //bottomleft
        Vertices[16] = new Vector3(-HexGlobals.HalfWidth, -1, HexGlobals.Radius / 2);
        UV[16] = new Vector2(0.5f, 0);
        //topleft
        Vertices[17] = new Vector3(-HexGlobals.HalfWidth, -1, -HexGlobals.Radius / 2);
        UV[17] = new Vector2(0, 0.25f);

    }
}
