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
    public int meleeKnockback;
    public float meleeStunDur;
    public GameObject meleeHitbox;

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
        meleeHitbox.SetActive(true);
        //meleeHitbox.GetComponent<PolygonCollider2D>().OnTriggerEnter(Collider collision)
        //{

        //}
       
        // deal damage to enemies
        // knock back enemies
        // stun enemies

        //collision.TakeDamage(meleeDamage);
        //collision.KnockBack(collision.GetComponenet<Transform>().position - transform.position, meleeKnockback);
        //collision.Stun(meleeStunDur);
        meleeHitbox.SetActive(false);

        playerAmmo++;
    }

    public void PlayerRangedAttack()
    {       
        GameObject projectile = Instantiate(simpleProjectile, transform.position, transform.rotation);
            // spawns projectile on player's location
        projectile.GetComponent<SimpleProjectile>().SetInfo(PlayerToMouse(), projectileSpeed, projectileDamage);
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