using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSBlock : MonoBehaviour
{
    /*
    enum BlockType
    {
        NONE, I, J, L, O, S, T, Z
    };
    BlockType mType = BlockType.NONE;
    byte[,] mShape = new byte[4,4];
    int mState = 0;
    int mMaxState = 0;

    CSBlock(BlockType _type)
    {
        mType = _type;
        mState = 0;
        switch(mType)
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
        UpdateShape();
    }

    void UpdateShape()
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
                        { 1, 1, 0, 0},
                        { 1, 0, 0, 0},
                        { 1, 0, 0, 0}
                    };
                }
                else
                {
                    mShape = new byte[4, 4] {
                        { 0, 0, 0, 0},
                        { 1, 1, 1, 0},
                        { 0, 0, 1, 0},
                        { 0, 0, 0, 0}
                    };
                }
                break;
            case BlockType.L:
                if (mState == 0)
                {
                    mShape = new byte[4, 4] {
                        { 0, 0, 0, 0},
                        { 1, 0, 0, 0},
                        { 1, 0, 0, 0},
                        { 1, 1, 0, 0}
                    };
                }
                else if (mState == 1)
                {
                    mShape = new byte[4, 4] {
                        { 0, 0, 0, 0},
                        { 1, 1, 1, 0},
                        { 1, 0, 0, 0},
                        { 0, 0, 0, 0}
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
                        { 0, 1, 0, 0},
                        { 1, 1, 0, 0}
                    };
                }
                else
                {
                    mShape = new byte[4, 4] {
                        { 0, 0, 0, 0},
                        { 1, 0, 0, 0},
                        { 1, 1, 1, 0},
                        { 0, 0, 1, 0}
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
                        { 0, 1, 0, 0},
                        { 0, 1, 1, 0}
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
        UpdateShape();
    }

    */

    // Start is called before the first frame update
    void Start()
    {
        Camera.current.aspect = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(5f, 0, 0);
    }
}
