using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Clearing
    [SerializeField] private int columns;
    [SerializeField] private int rows;
    [SerializeField] private Sprite blockSprite;
    private SpriteRenderer[,] spriteRenderers;
    private bool[,] grid;
    private bool[,] block;
    private bool isRowTrue = true;
    private int gridColumnCount = 0;
    private int gridRowCount = 0;
    private bool IsCreated = false;
    [SerializeField]private float m_repeatRate;
    private int timesCleared = 0;
    


    private void InstantiateSP()
    {
        spriteRenderers = new SpriteRenderer[rows, columns];
        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < columns; x++)
            {
                spriteRenderers[y, x] = new GameObject("(" + x + ", " + y + ")", typeof(SpriteRenderer)).GetComponent<SpriteRenderer>();
                spriteRenderers[y, x].sprite = blockSprite;
                spriteRenderers[y, x].transform.position = new Vector3(x, y, 0f);

            }
        }
    }

    public void UpdateVisualGrid()
    {
        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < columns; x++)
            {
                spriteRenderers[y, x].color = grid[y, x] ? Color.black : Color.white;

            }
        }
        if (IsCreated == true)
        {
            for (int y = 0; y < selectedBlock.GetLength(2); y++)
            {
                for (int x = 0; x < selectedBlock.GetLength(1); x++)
                {                    
                        if(selectedBlockPosition.x + x >= 0 && selectedBlockPosition.x + x < columns && selectedBlockPosition.y + y >= 0 && selectedBlockPosition.y + y < rows && selectedBlock[rotationIndex, y, x])
                        spriteRenderers[y + selectedBlockPosition.y, x + selectedBlockPosition.x].color = Color.black;                    
                }
            }
        }
    }

    private void MoveRowsDownFromPosition(int yPos)
    {
        for (int y = yPos; y < rows; y++)
        {
            for (int x = 0; x < columns; x++)
            {
                if (y != rows - 1)
                {
                    grid[y, x] = grid[y + 1, x];
                }
                else
                {
                    grid[y, x] = false;
                }
            }
        }
        UpdateVisualGrid();
    }

    private void CheckArrays()
    {
        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < columns; x++)
            {
                //Checken of de ene array false is of true is. als hij door hele rows gekeken heeeft, return hij true op isrowtrue,
                if (grid[y, x] == false)
                {
                    isRowTrue = false;
                    break;
                }
            }
            if (isRowTrue == true)
            {

                for (int x = 0; x < columns; x++)
                {
                    // Ik zet die rij nu op false
                    grid[y, x] = false;

                }
                MoveRowsDownFromPosition(y);

            }
            else
            {
                //hier na gaan we terug
                isRowTrue = true;
            }

        }

    }


    #endregion

    #region Blocks

    public bool[,,] iBlock = new bool[,,]
    {
        {
            { false, false, false, false },
            { true, true, true, true },
            { false, false, false, false },
            { false, false, false, false }
        }, {
            {false,false,true,false },
            {false,false,true,false },
            {false,false,true,false },
            {false,false,true,false }

        },
        {
            {false,false,false,false },
            {false,false,false,false },
            {true,true,true,true },
            {false,false,false,false }
        },
        {
            {false,true,false,false },
            {false,true,false,false },
            {false,true,false,false },
            {false,true,false,false }
        }
    };
    public bool[,,] jBlock = new bool[,,]
    {
        {
            {true,false,false },
            {true,true,true },
            {false,false,false}
        },
        {
            {false,true,true },
            {false,true,false },
            {false,true,false }
        },
        {
            {false,false,false },
            {true,true,true },
            {false,false,true }
        },
        {
            {false,true,false },
            {false,true,false },
            {true,true,false }
        },
    };
    public bool[,,] lBlock = new bool[,,]
    {
        {
            {false,false,true },
            {true,true,true },
            {false,false,false }
        },
        {
            {false,true,false },
            {false,true,false },
            {false,true,true }
        },
        {
            {false,false,false },
            {true,true,true },
            {true,false,false }
        },
        {
            {true,true,false },
            {false,true,false },
            {false,true,false }
        },
    };
    public bool[,,] oBlock = new bool[,,]
    {
        {
            {true,true },
            {true,true },
        },
        {
            {true,true },
            {true,true },
        },
        {
            {true,true },
            {true,true },
        },
        {
            {true,true },
            {true,true },
        },
    };
    public bool[,,] sBlock = new bool[,,]
    {
        {
            {false,true,true },
            {true,true,false },
            {false,false,false }
        },
        {
            {false,true,false },
            {false,true,true },
            {false,false,true }
        },
        {
            {false,false,false },
            {false,true,true },
            {true,true,false }
        },
        {
            {true,false,false },
            {true,true,false },
            {false,true,false }
        },
    };
    public bool[,,] tBlock = new bool[,,]
    {
        {
            {false,true,false },
            {true,true,true },
            {false,false,false }
        },
        {
            {false,true,false },
            {false,true,true },
            {false,true,false }
        },
        {
            {false,false,false },
            {true,true,true },
            {false,true,false }
        },
        {
            {false,true,false },
            {true,true,false },
            {false,true,false }
        },
    };
    public bool[,,] zBlock = new bool[,,]
    {
        {
            {true,true,false },
            {false,true,true },
            {false,false,false }
        },
        {
            {false,false,true },
            {false,true,true },
            {false,true,false }
        },
        {
            {false,false,false },
            {true,true,false },
            {false,true,true }
        },
        {
            {false,true,false },
            {true,true,false },
            {true,false,false }
        },
    };
    public bool[,,] donutBlock = new bool[,,]
    {
        {
            {true,true,true },
            {true,false,true },
            {true,true,true }
        },
        {
            {true,true,true },
            {true,false,true },
            {true,true,true }
        },
        {
            {true,true,true },
            {true,false,true },
            {true,true,true }
        },
        {
            {true,true,true },
            {true,false,true },
            {true,true,true }
        },
    };

    [SerializeField] private Vector2Int selectedBlockPosition;

    private bool[,,] selectedBlock;

    private int rotationIndex = 0;

    private void ChangeTheIndex()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            int FutureIndex = rotationIndex + 1;
            if(FutureIndex >= selectedBlock.GetLength(0))
            {
                FutureIndex = 0;
            }
            if (!DetectCollision(selectedBlock, FutureIndex, selectedBlockPosition))
            {
                rotationIndex = FutureIndex;
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            int FutureIndex = rotationIndex - 1;
            if (FutureIndex < 0)
            {
                FutureIndex = selectedBlock.GetLength(0) - 1;
            }
            if (!DetectCollision(selectedBlock, FutureIndex, selectedBlockPosition))
            {
                rotationIndex = FutureIndex;
            }
        }
        UpdateVisualGrid();

    }

    private void CreateBlock()
    {
        if (IsCreated == false)
        {
            int random;
            random = Random.Range(0, 8);
            switch (random)
            {
                case 0:
                    selectedBlock = iBlock;
                    break;
                case 1:
                    selectedBlock = jBlock;
                    break;
                case 2:
                    selectedBlock = lBlock;
                    break;
                case 3:
                    selectedBlock = oBlock;
                    break;
                case 4:
                    selectedBlock = sBlock;
                    break;
                case 5:
                    selectedBlock = tBlock;
                    break;
                case 6:
                    selectedBlock = zBlock;
                    break;
                case 7:
                    selectedBlock = donutBlock;
                    break;
                case 8:
                    selectedBlock = donutBlock;
                    break;
                default:
                    selectedBlock = iBlock;
                    break;
            }
            IsCreated = true;
            selectedBlockPosition.x = columns - selectedBlock.GetLength(2) * 2;
            selectedBlockPosition.y = rows - selectedBlock.GetLength(1);
        }
        UpdateVisualGrid();
    }

    private void MoveBlockYEverySecond()
    {
        if(!DetectCollision(selectedBlock,rotationIndex,selectedBlockPosition + Vector2Int.down))
        selectedBlockPosition.y -= 1;
        else
        {
            SnapTheGrid();
        }
        UpdateVisualGrid();
    }

    private void MoveBlockPos()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(!DetectCollision(selectedBlock,rotationIndex,selectedBlockPosition + Vector2Int.right))

                selectedBlockPosition.x += 1;
            
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            if (!DetectCollision(selectedBlock, rotationIndex, selectedBlockPosition + Vector2Int.left))
                selectedBlockPosition.x -= 1;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (!DetectCollision(selectedBlock, rotationIndex, selectedBlockPosition + Vector2Int.down))
                selectedBlockPosition.y -= 1;
            else
            {
                SnapTheGrid();
            }
        }
        UpdateVisualGrid();
    }

    private void SnapTheGrid()
    {
        Vector2Int blockSize = new Vector2Int(selectedBlock.GetLength(2), selectedBlock.GetLength(1));
        for (int y = 0; y < blockSize.y; y++)
        {
            for (int x = 0; x < blockSize.x; x++)
            {
                if (selectedBlock[rotationIndex, y, x])
                {
                    grid[selectedBlockPosition.y + y, selectedBlockPosition.x + x] = true;
                }
            }
        }

        selectedBlock = null;
        IsCreated = false;
        CreateBlock();
        UpdateVisualGrid();
        //CheckArrays();
    }

    private bool DetectCollision(bool[,,] block, int blockIndex, Vector2Int position)
    {
        Vector2Int blockSize = new Vector2Int(block.GetLength(2), block.GetLength(1));
        for (int y = 0; y < blockSize.y; y++)
        {
            for (int x = 0; x < blockSize.x; x++)
            {
                if(position.x + x < 0 || position.x + x >= columns || position.y + y < 0)
                {
                    //Debug.Log("blockindex: " + blockIndex + " x: " + x + " y: " + y);
                    if (block[blockIndex, y, x])
                    {
                        return true;
                    }
                } else
                {
                    if (block[blockIndex, y, x] && grid[position.y + y, position.x + x])
                    {
                        return true;
                    }
                }
            }
        }
        return false;


    }

    #endregion

    private void Start()
    {
        grid = new bool[rows, columns];
        //grid[3, 3] = true;
        block = new bool[0, 0];
        InstantiateSP();
        CreateBlock();
        InvokeRepeating("MoveBlockYEverySecond",m_repeatRate,m_repeatRate);
        
    }

    private void Update()
    {
        //UpdateVisualGrid();
        MoveBlockPos();
        CheckArrays();
        //CreateBlock();
        ChangeTheIndex();
    }

    private void Randomd()
    {

        Random.Range(0,100);


    }

}
