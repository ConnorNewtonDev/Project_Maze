using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    private GameManager gM;
    public Text timerText;
    private bool Active { get; set; }
    public float curTime, maxTime;

    // Use this for initialization

    void Start ()
    {
        gM = FindObjectOfType<GameManager>();
        Active = false;
        SetTimer(0);
        Active = true;
       timerText =  GameObject.Find("Player").GetComponentInChildren<Text>();      

    }
	
	// Update is called once per frame
	void Update ()
    {
        if(Active)
        {
            if(curTime > 0)
            {
                curTime -= Time.deltaTime;
                timerText.text = ((int)curTime).ToString();
            }
            else
            {
                Active = false;
                gM.GameOver();
            }
        }
		
	}

    public void SetTimer(float newTime)
    {
        maxTime = 90 + (10 * gM.mazeCompleted) + newTime;
        curTime = maxTime;
    }

    public void SwapActive()
    {
        Active = !Active;
    }

}
