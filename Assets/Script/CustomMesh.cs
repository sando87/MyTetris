using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomMesh : MonoBehaviour
{
    public Material mat;
    float width = 1f;
    float height = 1f;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<MeshRenderer>().material = mat;

        Mesh mesh = new Mesh();
        Vector3[] verticies = new Vector3[4];
        verticies[0] = new Vector3(-width, -height, 0);
        verticies[1] = new Vector3(-width, height, 0);
        verticies[2] = new Vector3(width, -height, 0);
        verticies[3] = new Vector3(width, height, 0);
        mesh.vertices = verticies;

        mesh.triangles = new int[] { 0, 1, 2, 1, 3, 2 };
        mesh.uv = new Vector2[]
        {
            new Vector2(0, 0),
            new Vector2(0, 1),
            new Vector2(1, 0),
            new Vector2(1, 1),
        };
        GetComponent<MeshFilter>().mesh = mesh;
    }
}
