using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    public TextMeshProUGUI ammoText;

    public UnityEngine.UI.Image healthBar;

    public GameManager gameManager;

    public Player playerScript;
    public float playerUIHealth;


    // Start is called before the first frame update
    void Start()
    {
        playerUIHealth = playerScript.playerCurrentHealth;

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
        
        if(playerScript.playerCurrentHealth != playerUIHealth)
        {
            playerUIHealth = playerScript.playerCurrentHealth;
            healthBar.fillAmount =  (float)(playerUIHealth / (float)playerScript.playerMaxHealth);
            Debug.Log((float)(playerUIHealth / playerScript.playerMaxHealth));


        }
    
    }

    


}