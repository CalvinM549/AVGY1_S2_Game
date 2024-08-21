using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    //Test Variables
    public int AOETest = 0;

    //Boss Values
    public bool secondPhase;

    public int bossCurrentHealth;
    public int bossMaxHealth;


    private Vector3 circleAreaPosition;
    public int circleAreaSize;
    public int circleAreaDamage;

    //Imported Values
    Player player;
    public Transform playerTransform;
    public GameObject homingProjectile;


    // Start is called before the first frame update
    void Start()
    {
        player = playerTransform.GetComponent<Player>();

        bossCurrentHealth = bossMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            CircleAOE();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            HomingProjectile();
        }
    }

    public void TakeDamage(int damageTaken)
    {
        bossCurrentHealth -= damageTaken;

        if (bossCurrentHealth <= bossMaxHealth/2)
        {
            secondPhase = true;
        }
        if (bossCurrentHealth <= 0)
        {
            BossDeath();
        }
    }

    void BossDeath()
    {
        Destroy(gameObject);
    }

    void ChooseAttack()
    {

    }

    public void CircleAOE()
    {
        circleAreaPosition = playerTransform.position;
        //draw warning circle
        //delay

        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(circleAreaPosition, circleAreaSize);
        Debug.Log(circleAreaPosition);
        foreach (Collider2D collider in hitColliders) 
        {
            if (collider.CompareTag("Player"))
            {
                collider.gameObject.GetComponent<Player>().TakeDamage(circleAreaDamage);
            }
        }

    }

    void LineAOE()
    {
       // Collider2D[] hitColliders = Physics2D.OverlapAreaAll
    }

    public void HomingProjectile()
    {
        GameObject projectile = Instantiate(homingProjectile, transform.position, transform.rotation);
        projectile.GetComponent<HomingProjectile>().SetPlayer(player);
    }

    void SpawnMinion()
    {
        //for(int i; i<minionCount; i++)
        //{
           // GameObject bossMinion = Instantiate(BossMinion, , );
        //}
    }



    //Attacks
    //Circle AOE spawn on player
    //Fires homing projectiles that track player loosely
    //Line AOE that spawns towards player


    //Summon minions on outskirts of arena


    //Movement
    //Teleport to different area in arena
}
