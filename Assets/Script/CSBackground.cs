using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSBackground : MonoBehaviour
{
    public GameObject mBlockObject;
    public Material mMaterial;
    public int mCountX;
    public int mCountY;

    public static float mBlockSize = 0.25f;

    private byte[,] mBlockArray = null;
    // Start is called before the first frame update
    void Start()
    {
        //InitBackground();
        InitBlocks();
    }

    float timeAcc = 0;
    // Update is called once per frame
    void Update()
    {
        timeAcc += Time.deltaTime;
        if(timeAcc > 3)
        {
            CreateNewBlock();
            timeAcc = 0;
        }
    }

    void InitBlocks()
    {
        List<Vector3> vertices = new List<Vector3>();
        List<int> indicies = new List<int>();
        List<Vector2> uvs = new List<Vector2>();

        mBlockArray = new byte[mCountX, mCountY];
        for(int y = 0; y<mCountY; ++y)
        {
            for (int x = 0; x < mCountX; ++x)
            {
                vertices.Add(new Vector3((mBlockSize * (x + 0)), (mBlockSize * (y + 0)), 0));
                vertices.Add(new Vector3((mBlockSize * (x + 0)), (mBlockSize * (y + 1)), 0));
                vertices.Add(new Vector3((mBlockSize * (x + 1)), (mBlockSize * (y + 0)), 0));
                vertices.Add(new Vector3((mBlockSize * (x + 1)), (mBlockSize * (y + 1)), 0));

                int cnt = indicies.Count;
                indicies.AddRange( new int[] {
                    cnt+0, cnt+1, cnt+2, cnt+1, cnt+3, cnt+2,
                });

                int rand = Random.Range(0, 7);
                uvs.Add(new Vector2(0.125f * (rand + 0), 0));
                uvs.Add(new Vector2(0.125f * (rand + 0), 1));
                uvs.Add(new Vector2(0.125f * (rand + 1), 0));
                uvs.Add(new Vector2(0.125f * (rand + 1), 1));
            }
        }

        Mesh mesh = new Mesh();
        mesh.vertices = vertices.ToArray();
        mesh.triangles = indicies.ToArray();
        mesh.uv = uvs.ToArray();
        GetComponent<MeshFilter>().mesh = mesh;

        GetComponent<MeshRenderer>().material = mMaterial;
    }

    void InitBackground()
    {
        mBlockArray = new byte[mCountX, mCountY];

        Mesh mesh = new Mesh();
        float MaxX = mBlockSize * mCountX;
        float MaxY = mBlockSize * mCountY;
        mesh.vertices = new Vector3[4]
        {
            new Vector3(0,      0,      0),
            new Vector3(0,      MaxY,   0),
            new Vector3(MaxX,   0,      0),
            new Vector3(MaxX,   MaxY,   0)
        };
        mesh.triangles = new int[] 
        {
            0, 1, 2, 1, 3, 2,
        };
        mesh.uv = new Vector2[]
        {
            new Vector2(0, 0),
            new Vector2(0, 1),
            new Vector2(1, 0),
            new Vector2(1, 1),
        };
        GetComponent<MeshFilter>().mesh = mesh;

        GetComponent<MeshRenderer>().material = mMaterial;
    }

    void CreateNewBlock()
    {
        int rand = Random.Range(0, 7) + 1;
        CSBlock.BlockType type = (CSBlock.BlockType)rand;
        GameObject obj = Instantiate(mBlockObject, new Vector3(rand, 0, 0), Quaternion.identity) as GameObject;
        obj.GetComponent<CSBlock>().mType = type;
    }
}
