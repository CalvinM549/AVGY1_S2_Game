using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SimpleEnemy : MonoBehaviour
{
    public int collisionCount = 0;

    public Rigidbody2D rb;
    //
    public int enemyDamage;
    public float enemyKnockback;
    public bool stunned;

    // Movement
    public int enemySpeed;


    // Health
    public int enemyCurrentHealth;
    public int enemyMaxHealth;


    public Transform player;
    public Player playerScript;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        stunned = false;
        enemyCurrentHealth = enemyMaxHealth;
    }


    // Update is called once per frame
    void Update()
    {
        //cooldowns
        
    }

    


    private void FixedUpdate()
    {
        if(!stunned)
        {
            Vector3 moveDirection = (player.position - transform.position).normalized;
            rb.velocity = moveDirection * Time.deltaTime * enemySpeed;
        }
    }


    public void TakeDamage(int damage)
    {
        enemyCurrentHealth -= damage;
        if (enemyCurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Stun(float stunDur)
    {
        stunned = true;
    }

    public void KnockBack(Vector2 damageDirection, float damageForce)
    {
        rb.AddForce(damageDirection * damageForce, ForceMode2D.Impulse);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        collisionCount++;
        if (collision.CompareTag("Player"))
        {
            // TODO
            playerScript.TakeDamage(enemyDamage);
            playerScript.KnockBack((player.position - transform.position), enemyKnockback);
        }
    }




    public void EnemyDeath()
    {
        // TODO
    }


    public void DealDamage()
    {
        //player.TakeDamage(EnemyDamage);
    }

}