using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


public class Player : MonoBehaviour
{
    //Test variables

    //Initialize Variables
    public Rigidbody2D rb;


    //Health Variables
    public int playerCurrentHealth;
    public int PlayerMaxHealth;


    //Attack Variables
    // Projectile Attack
    public int projectileDamage;
    public int projectileSpeed;
    public GameObject simpleProjectile;

    // Melee Attack
    public int meleeDamage;
    public int meleeReach;
    public int meleeAngle;
    public int meleeKnockback;
    public float meleeStunDur;

    public Vector3 towardsMouseFromPlayer;

    //Movement Variables
    public int dashDistance;
    public int playerSpeed;
    public int dashCooldown;
    float vertical;
    float horizontal;

    //Misc Variables
    public int playerAmmo;
    public int playerScore;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCurrentHealth = PlayerMaxHealth;
    }


    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown("space"))
        {
            PlayerDash();
        }
        if (Input.GetMouseButtonDown(0)) //left click
        {
            PlayerMeleeAttack();
        }
        if (Input.GetMouseButtonDown(1) && playerAmmo > 0) //right click
        {
            PlayerRangedAttack();
        }
    }

    private void FixedUpdate()
    {
        // plauer movement
        rb.velocity += new Vector2(horizontal, vertical) * Time.deltaTime * playerSpeed;
    }


    // Player Actions

    public void PlayerDash()
    {

        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");
        // gets the raw value (1, 0 or -1, of each axis)
        Vector2 dashDirection = new Vector2(h, v).normalized;
        // converts to a vector and normalizes
        rb.AddForce(dashDirection * dashDistance, ForceMode2D.Impulse);
        // applies the force in the correct direction, and multiplies it by the distance provided
    }

    public Vector3 PlayerToMouse()
    {
        Vector3 positionMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        positionMouse.z = transform.position.z;
            // gets mouse global position

        towardsMouseFromPlayer = (positionMouse - transform.position).normalized;

        return towardsMouseFromPlayer;
    }

    public void PlayerMeleeAttack()
    {
        Vector3 mouseVector = PlayerToMouse();
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, meleeReach);
        Debug.DrawRay(transform.position, mouseVector, Color.green, 2, false);
        
        foreach (Collider2D collider in hitColliders)
        {
            if (!(collider.CompareTag("Player"))&& !(collider.CompareTag("Wall")))
            {
                //if ((Vector2.Angle(transform.position, collider.transform.position) - Vector2.Angle(transform.position, mouseVector) < mouseVector + meleeAngle))
                if(Vector2.Angle(transform.position, collider.transform.position) > Vector2.Angle(transform.position, mouseVector) + meleeAngle
                    && Vector2.Angle(transform.position, collider.transform.position) < Vector2.Angle(transform.position, mouseVector) - meleeAngle)
                {
                    Debug.Log(Vector2.Angle(transform.position, collider.transform.position));
                    Debug.Log(Vector2.Angle(transform.position, mouseVector) + meleeAngle);

                    Debug.DrawLine(transform.position, collider.transform.position, Color.red, 2, false);
                    if (collider.CompareTag("SimpleEnemy"))
                    {
                        collider.GetComponent<SimpleEnemy>().TakeDamage(meleeDamage);

                        playerAmmo++;

                        Debug.Log("Enemy Hit");
                    }
                    else if (collider.CompareTag("BossEnemy"))
                    {
                        collider.GetComponent<BossEnemy>().TakeDamage(meleeDamage);

                        playerAmmo++;

                        Debug.Log("Enemy Hit");
                    }

                }

                Debug.Log("Enemy Targeted");
            }
            
        }

        //meleeHitbox.GetComponent<PolygonCollider2D>().OnTriggerEnter(Collider collision)
        //{

        //}

        // deal damage to enemies
        // knock back enemies
        // stun enemies

        //collision.TakeDamage(meleeDamage);
        //collision.KnockBack(collision.GetComponenet<Transform>().position - transform.position, meleeKnockback);
        //collision.Stun(meleeStunDur);
        

    }

    public void PlayerRangedAttack()
    {
        Vector3 mouseVector = PlayerToMouse();

        float rot = Mathf.Atan2(mouseVector.y, mouseVector.x) * Mathf.Rad2Deg;

        GameObject projectile = Instantiate(simpleProjectile, transform.position, Quaternion.Euler(0, 0, rot + -90));
            // spawns projectile on player's location
        projectile.GetComponent<SimpleProjectile>().SetInfo(mouseVector, projectileSpeed, projectileDamage);
            // feeds projectile its stats from the player's variables to allow for easier tweaking
        playerAmmo--;
            // reduces ammo count


        // deal damage

    }

    // Player Damage Functions

    public void TakeDamage(int damageTaken)
    {
        playerCurrentHealth -= damageTaken;
        if (playerCurrentHealth <= 0)
        {
            PlayerDeath();
        }
    }

    public void KnockBack(Vector2 damageDirection, float damageForce)
    {
        rb.AddForce(damageDirection * damageForce, ForceMode2D.Impulse);
    }


    void PlayerDeath()
    {
        Destroy(gameObject);
    }


}

//yield return new WaitForSeconds(1);