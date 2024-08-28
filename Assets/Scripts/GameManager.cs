using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{


    public float timeRemaining;
    public bool timerIsRunning;
    public Player playerScript;
    public bool key1;
    public bool key2;
    public bool key3;


    // Start is called before the first frame update
    void Start()
    {
        timerIsRunning = true;
    }


    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;

                // put death trigger or smth
            }
        }

    }

}