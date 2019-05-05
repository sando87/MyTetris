using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSBlock : MonoBehaviour
{
    public Material mMaterialBlock;
    public BlockType mType;

    public enum BlockType
    {
        NONE, I, J, L, O, S, T, Z
    };
    byte[,] mShape = new byte[4,4];
    int mState = 0;
    int mMaxState = 0;

    void InitBlock()
    {
        mState = 0;
        switch (mType)
        {
            case BlockType.I: mMaxState = 2; break;
            case BlockType.J: mMaxState = 4; break;
            case BlockType.L: mMaxState = 4; break;
            case BlockType.O: mMaxState = 1; break;
            case BlockType.S: mMaxState = 2; break;
            case BlockType.T: mMaxState = 4; break;
            case BlockType.Z: mMaxState = 2; break;
            default: mMaxState = 1; break;
        }
        UpdateShapeArray();
        InitMesh();
        GetComponent<MeshRenderer>().material = mMaterialBlock;
    }
    void UpdateShapeArray()
    {
        switch (mType)
        {
            case BlockType.I:
                if(mState == 0)
                {
                    mShape = new byte[4,4] {
                        { 0, 0, 0, 0},
                        { 0, 0, 0, 0},
                        { 1, 1, 1, 1},
                        { 0, 0, 0, 0}
                    };
                }
                else
                {
                    mShape = new byte[4, 4] {
                        { 0, 1, 0, 0},
                        { 0, 1, 0, 0},
                        { 0, 1, 0, 0},
                        { 0, 1, 0, 0}
                    };
                }
                break;
            case BlockType.J:
                if (mState == 0)
                {
                    mShape = new byte[4, 4] {
                        { 0, 0, 0, 0},
                        { 0, 1, 0, 0},
                        { 0, 1, 0, 0},
                        { 1, 1, 0, 0}
                    };
                }
                else if(mState == 1)
                {
                    mShape = new byte[4, 4] {
                        { 0, 0, 0, 0},
                        { 1, 0, 0, 0},
                        { 1, 1, 1, 0},
                        { 0, 0, 0, 0}
                    };
                }
                else if (mState == 2)
                {
                    mShape = new byte[4, 4] {
                        { 0, 0, 0, 0},
                        { 0, 1, 1, 0},
                        { 0, 1, 0, 0},
                        { 0, 1, 0, 0}
                    };
                }
                else
                {
                    mShape = new byte[4, 4] {
                        { 0, 0, 0, 0},
                        { 0, 0, 0, 0},
                        { 1, 1, 1, 0},
                        { 0, 0, 1, 0}
                    };
                }
                break;
            case BlockType.L:
                if (mState == 0)
                {
                    mShape = new byte[4, 4] {
                        { 0, 0, 0, 0},
                        { 0, 1, 0, 0},
                        { 0, 1, 0, 0},
                        { 0, 1, 1, 0}
                    };
                }
                else if (mState == 1)
                {
                    mShape = new byte[4, 4] {
                        { 0, 0, 0, 0},
                        { 0, 0, 0, 0},
                        { 1, 1, 1, 0},
                        { 1, 0, 0, 0}
                    };
                }
                else if (mState == 2)
                {
                    mShape = new byte[4, 4] {
                        { 0, 0, 0, 0},
                        { 1, 1, 0, 0},
                        { 0, 1, 0, 0},
                        { 0, 1, 0, 0}
                    };
                }
                else
                {
                    mShape = new byte[4, 4] {
                        { 0, 0, 0, 0},
                        { 0, 0, 1, 0},
                        { 1, 1, 1, 0},
                        { 0, 0, 0, 0}
                    };
                }
                break;
            case BlockType.O:
                mShape = new byte[4, 4] {
                    { 0, 0, 0, 0},
                    { 0, 1, 1, 0},
                    { 0, 1, 1, 0},
                    { 0, 0, 0, 0}
                };
                break;
            case BlockType.S:
                if (mState == 0)
                {
                    mShape = new byte[4, 4] {
                        { 0, 0, 0, 0},
                        { 0, 1, 1, 0},
                        { 1, 1, 0, 0},
                        { 0, 0, 0, 0}
                    };
                }
                else
                {
                    mShape = new byte[4, 4] {
                        { 0, 0, 0, 0},
                        { 1, 0, 0, 0},
                        { 1, 1, 0, 0},
                        { 0, 1, 0, 0}
                    };
                }
                break;
            case BlockType.T:
                if (mState == 0)
                {
                    mShape = new byte[4, 4] {
                        { 0, 0, 0, 0},
                        { 0, 0, 0, 0},
                        { 1, 1, 1, 0},
                        { 0, 1, 0, 0}
                    };
                }
                else if (mState == 1)
                {
                    mShape = new byte[4, 4] {
                        { 0, 0, 0, 0},
                        { 0, 1, 0, 0},
                        { 1, 1, 0, 0},
                        { 0, 1, 0, 0}
                    };
                }
                else if (mState == 2)
                {
                    mShape = new byte[4, 4] {
                        { 0, 0, 0, 0},
                        { 0, 1, 0, 0},
                        { 1, 1, 1, 0},
                        { 0, 0, 0, 0}
                    };
                }
                else
                {
                    mShape = new byte[4, 4] {
                        { 0, 0, 0, 0},
                        { 0, 1, 0, 0},
                        { 0, 1, 1, 0},
                        { 0, 1, 0, 0}
                    };
                }
                break;
            case BlockType.Z:
                if (mState == 0)
                {
                    mShape = new byte[4, 4] {
                        { 0, 0, 0, 0},
                        { 1, 1, 0, 0},
                        { 0, 1, 1, 0},
                        { 0, 0, 0, 0}
                    };
                }
                else
                {
                    mShape = new byte[4, 4] {
                        { 0, 0, 0, 0},
                        { 0, 1, 0, 0},
                        { 1, 1, 0, 0},
                        { 1, 0, 0, 0}
                    };
                }
                break;
        }
    }
    void NextShape()
    {
        mState = (mState + 1) % mMaxState;
        UpdateShapeArray();
    }
    void InitMesh()
    {
        Mesh mesh = new Mesh();

        Vector2Int[] shapeArray;
        switch(mType)
        {
            case BlockType.I:
                shapeArray = new Vector2Int[4]
                {
                    new Vector2Int(0, 2),
                    new Vector2Int(0, 1),
                    new Vector2Int(0, 0),
                    new Vector2Int(0, -1),
                };
                break;
            case BlockType.J:
                shapeArray = new Vector2Int[4]
                {
                    new Vector2Int(0, 1),
                    new Vector2Int(0, 0),
                    new Vector2Int(0, -1),
                    new Vector2Int(-1, -1),
                };
                break;
            case BlockType.L:
                shapeArray = new Vector2Int[4]
                {
                    new Vector2Int(0, 1),
                    new Vector2Int(0, 0),
                    new Vector2Int(0, -1),
                    new Vector2Int(1, -1),
                };
                break;
            case BlockType.O:
                shapeArray = new Vector2Int[4]
                {
                    new Vector2Int(0, 1),
                    new Vector2Int(1, 1),
                    new Vector2Int(0, 0),
                    new Vector2Int(1, 0),
                };
                break;
            case BlockType.S:
                shapeArray = new Vector2Int[4]
                {
                    new Vector2Int(0, 1),
                    new Vector2Int(1, 1),
                    new Vector2Int(0, 0),
                    new Vector2Int(-1, 0),
                };
                break;
            case BlockType.T:
                shapeArray = new Vector2Int[4]
                {
                    new Vector2Int(-1, 0),
                    new Vector2Int(0, 0),
                    new Vector2Int(1, 0),
                    new Vector2Int(0, -1),
                };
                break;
            case BlockType.Z:
                shapeArray = new Vector2Int[4]
                {
                    new Vector2Int(-1, 1),
                    new Vector2Int(0, 1),
                    new Vector2Int(0, 0),
                    new Vector2Int(1, 0),
                };
                break;
            default:
                return;
        }
        Vector3[] verticies = NewVerticies(shapeArray);
        mesh.vertices = verticies;

        mesh.triangles = new int[] {
            0, 1, 2, 1, 3, 2,
            4, 5, 6, 5, 7, 6,
            8, 9, 10, 9, 11, 10,
            12, 13, 14, 13, 15, 14,
        };
        mesh.uv = NewUVVectors(mType);

        GetComponent<MeshFilter>().mesh = mesh;
    }
    Vector2[] NewUVVectors(BlockType _type)
    {
        int uvIndex = 0;
        float step = 0.125f;
        switch(_type)
        {
            case BlockType.I: uvIndex = 0; break;
            case BlockType.J: uvIndex = 1; break;
            case BlockType.L: uvIndex = 2; break;
            case BlockType.O: uvIndex = 3; break;
            case BlockType.S: uvIndex = 4; break;
            case BlockType.T: uvIndex = 5; break;
            case BlockType.Z: uvIndex = 6; break;
            default: break;
        }
        Vector2[] ret = new Vector2[]
        {
            new Vector2(uvIndex * step,         0),
            new Vector2(uvIndex * step,         1),
            new Vector2((uvIndex + 1) * step,   0),
            new Vector2((uvIndex + 1) * step,   1),
            new Vector2(uvIndex * step,         0),
            new Vector2(uvIndex * step,         1),
            new Vector2((uvIndex + 1) * step,   0),
            new Vector2((uvIndex + 1) * step,   1),
            new Vector2(uvIndex * step,         0),
            new Vector2(uvIndex * step,         1),
            new Vector2((uvIndex + 1) * step,   0),
            new Vector2((uvIndex + 1) * step,   1),
            new Vector2(uvIndex * step,         0),
            new Vector2(uvIndex * step,         1),
            new Vector2((uvIndex + 1) * step,   0),
            new Vector2((uvIndex + 1) * step,   1),
        };
        return ret;
    }
    Vector3[] NewVerticies(Vector2Int[] _array)
    {
        float blockSize = CSBackground.mBlockSize;
        float halfSize = blockSize * 0.5f;
        int blockCount = _array.Length;
        Vector3[] verticies = new Vector3[blockCount * 4];
        for(int i = 0; i < blockCount; ++i)
        {
            int PosX = _array[i].x;
            int PosY = _array[i].y;
            verticies[i * 4 + 0] = new Vector3((blockSize * PosX) - halfSize, (blockSize * PosY) - halfSize , 0);
            verticies[i * 4 + 1] = new Vector3((blockSize * PosX) - halfSize, (blockSize * PosY) + halfSize , 0);
            verticies[i * 4 + 2] = new Vector3((blockSize * PosX) + halfSize, (blockSize * PosY) - halfSize , 0);
            verticies[i * 4 + 3] = new Vector3((blockSize * PosX) + halfSize, (blockSize * PosY) + halfSize , 0);
        }
        return verticies;
    }
    

    // Start is called before the first frame update
    void Start()
    {
        InitBlock();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
