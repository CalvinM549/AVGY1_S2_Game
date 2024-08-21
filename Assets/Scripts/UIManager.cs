using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    public TextMeshProUGUI ammoText;

    public GameManager gameManager;

    public Player playerScript;



    // Start is called before the first frame update
    void Start()
    {


    }


    // Update is called once per frame
    void Update()
    {
        //Timer Update
        
        if (gameManager.timeRemaining > 0)
        {
            timerText.text = gameManager.timeRemaining.ToString("N0");
        }

        ammoText.text = playerScript.playerAmmo.ToString();

    }


}