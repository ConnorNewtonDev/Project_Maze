using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    private GameManager gM;
	// Use this for initialization
	void Start ()
    {
        gM = FindObjectOfType<GameManager>();
        if(gM.mazeCompleted == 0)
        {
            this.GetComponent<Text>().text = "No Mazes Completed";
        }
        else if(gM.mazeCompleted == 1)
        {
            this.GetComponent<Text>().text = gM.mazeCompleted + " Maze Completed";
        }
        else
        {
            this.GetComponent<Text>().text = gM.mazeCompleted + " Mazes Completed";
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
