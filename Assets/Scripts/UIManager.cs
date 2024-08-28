using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    public TextMeshProUGUI ammoText;

    public UnityEngine.UI.Image healthBar;
    public UnityEngine.UI.Image bossHealthBar;

    public GameManager gameManager;

    public Player playerScript;
    public BossEnemy bossScript;
    public float playerUIHealth;
    public float bossUIHealth;


    // Start is called before the first frame update
    void Start()
    {
        playerUIHealth = playerScript.playerCurrentHealth;
        bossUIHealth = bossScript.bossCurrentHealth;
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

        if (bossScript.bossCurrentHealth != bossUIHealth)
        {
            bossUIHealth = bossScript.bossCurrentHealth;
            bossHealthBar.fillAmount = (float)(bossUIHealth / (float)bossScript.bossMaxHealth);
            Debug.Log((float)(bossUIHealth / bossScript.bossMaxHealth));
        }

    }

    


}