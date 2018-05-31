using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public Maze maze;
    public bool visited;
    public int posX, posZ;
    //Walls saved in prefab
    public GameObject nWall;
    public GameObject eWall;
    public GameObject sWall;
    public GameObject wWall;

    private enum Directions { NORTH, EAST, SOUTH, WEST};
    Directions curdirection;

    public List<int> dir = new List<int> { 0, 1, 2, 3};

    private void Awake()
    {
        maze = GameObject.Find("Maze").GetComponent<Maze>();
        visited = false;
    }
   
}
