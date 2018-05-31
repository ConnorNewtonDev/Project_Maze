using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Maze : MonoBehaviour {
    //Set Current
    public Cell[,] Cells = new Cell[0,0];
    public int sizeX, sizeZ;
    public Cell cellPrefab;
    public List<Cell> path = new List<Cell>();
    public GameObject goal;

    public void Generate(int newx, int newz)
    {
        sizeX = newx;
        sizeZ = newz;
        Cells = new Cell[sizeX, sizeZ];

        for (int x = 0; x < sizeX; x++)
        {
            for (int z = 0; z < sizeZ; z++)
            {
                Cells[x, z] = NewCell(x, z);
            }
        }

        //Instantiate(goal, Cells[sizeX - 1, sizeZ - 1].transform.position, Quaternion.identity, null);
        Navigate(0, 0);
    }

    void Navigate(int x, int z)
    {
        Cell curCell = Cells[x, z];
        curCell.visited = true;
        while (curCell.dir.Count != 0)
        {
            int temp = curCell.dir[Random.Range(0, curCell.dir.Count)];
            switch (temp)
            {
                case 0:
                    {
                        if ((curCell.posZ + 1) < sizeZ)
                        {
                            if (Cells[x, z + 1].visited == false)
                            {
                                // Debug.Log("GOTO:" + (posX) + " , " + (posZ + 1));
                                path.Add(curCell);
                                Destroy(curCell.nWall);
                                Destroy(Cells[x, z + 1].sWall);
                                Navigate(x, z + 1);
                            }
                            else
                            {
                                curCell.dir.Remove(temp);
                            }
                        }
                        else
                        {
                            curCell.dir.Remove(temp);
                        }

                    }
                    break;
                case 1:
                    {
                        if ((x + 1) < sizeX)
                        {
                            if (Cells[x + 1, z].visited == false)
                            {
                                // Debug.Log("GOTO:" + (posX) + " , " + (posZ + 1));
                                path.Add(curCell);
                                Destroy(curCell.eWall);
                                Destroy(Cells[x + 1, z].wWall);
                                Navigate(x + 1, z);
                            }
                            else
                            {
                                curCell.dir.Remove(temp);
                            }
                        }
                        else
                        {
                            curCell.dir.Remove(temp);
                        }

                    }
                    break;
                case 2:
                    {
                        if ((z - 1) >= 0)
                        {
                            if (Cells[x, z - 1].visited == false)
                            {
                                // Debug.Log("GOTO:" + (posX) + " , " + (posZ + 1));
                                path.Add(curCell);
                                Destroy(curCell.sWall);
                                Destroy(Cells[x, z - 1].nWall);
                                Navigate(x, z - 1);
                            }
                            else
                            {
                                curCell.dir.Remove(temp);
                            }
                        }
                        else
                        {
                            curCell.dir.Remove(temp);
                        }
                    }
                    break;
                case 3:
                    {
                        if ((x - 1) >= 0)
                        {
                            if (Cells[x - 1, z].visited == false)
                            {
                                // Debug.Log("GOTO:" + (posX) + " , " + (posZ + 1));
                                path.Add(curCell);
                                Destroy(curCell.wWall);
                                Destroy(Cells[x - 1, z].eWall);
                                Navigate(x - 1, z);
                            }
                            else
                            {
                                curCell.dir.Remove(temp);
                            }
                        }
                        else
                        {
                            curCell.dir.Remove(temp);
                        }
                    }
                    break;
            }
        }
    }

    Cell NewCell(int x, int z)
    {
        Cell NewCell = Instantiate(cellPrefab) as Cell;
        NewCell.gameObject.name = "Cell (" + x + " , " + z + ")";
        NewCell.posX = x;
        NewCell.posZ = z;
        NewCell.transform.parent = this.transform;
        NewCell.transform.localPosition = new Vector3(x, 0, z);
        NewCell.visited = false;
        return NewCell;
    }
}
