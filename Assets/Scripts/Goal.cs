using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
	private GameManager gM;
	// Use this for initialization
	void Start ()
	{
        gM = FindObjectOfType<GameManager>();
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {

            gM.NextLevel();

        }
    }
}
