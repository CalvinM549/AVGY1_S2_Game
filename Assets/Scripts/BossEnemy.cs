using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class BossEnemy : MonoBehaviour
{
    //Test Variables
    public int AOETest = 0;
    public GameObject testWarningCircle;


    //Boss Values
    public bool secondPhase;

    public int bossCurrentHealth;
    public int bossMaxHealth;

    public float bossAttackDelay;

    public float damageAreaDelay;
    private Collider2D[] hitColliders;

    private Vector3 circleAreaPosition;
    public int circleAreaSize;
    public int circleAreaDamage;

    //Imported Values
    Player player;
    public UnityEngine.Transform playerTransform;
    public GameObject homingProjectile;


    // Start is called before the first frame update
    void Start()
    {
        player = playerTransform.GetComponent<Player>();

        bossCurrentHealth = bossMaxHealth;
        StartCoroutine(ChooseAttack());
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

        //while(secondPhase)
        //{
        //   Invoke("CircleAOE", 1f);
        //}
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

    IEnumerator ChooseAttack()
    {
        Debug.Log("start");
        while (true)
        {
            yield return new WaitForSeconds(bossAttackDelay);
            int test = Random.Range(0, 3);
            switch (test)
            {
                case 0:
                    Debug.Log("1");
                    CircleAOE();
                    break;

                case 1:
                    Debug.Log("2");
                    HomingProjectile();
                    break;
                case 2:
                    Debug.Log("3");
                    break;
            }
            yield return null;
        }
    }

    IEnumerator AOEDamagePlayer(string areaType, int damage)
    {
        yield return new WaitForSeconds(damageAreaDelay);
        

        if (areaType == "Circle")
        {
            hitColliders = Physics2D.OverlapCircleAll(circleAreaPosition, circleAreaSize);

        }
        

        foreach (Collider2D collider in hitColliders)
        {
            if (collider.CompareTag("Player"))
            {
                collider.gameObject.GetComponent<Player>().TakeDamage(damage);
            }
        }
    }

    public void CircleAOE()
    {
        circleAreaPosition = playerTransform.position; // gets players current position
        //draws a warning circle at player's current position
        GameObject warning = Instantiate(testWarningCircle, circleAreaPosition, transform.rotation);
        warning.GetComponent<ExplosionAnimation>().SetValues(new Vector3(circleAreaSize * 2, circleAreaSize * 2, 0), damageAreaDelay);
        //warning.transform.localScale = new Vector3(circleAreaSize*2, circleAreaSize*2, 0);
        //Destroy(warning, damageAreaDelay); // removes the warning circle when the damage occurs
        // calls the damage script, with a set delay
        StartCoroutine(AOEDamagePlayer("Circle", circleAreaDamage));

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
