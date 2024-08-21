using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleProjectile : MonoBehaviour
{
    public Rigidbody2D rb;
    public int speed;
    public int damage;
    public Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetInfo(Vector2 dir, int projectileSpeed, int projectileDamage)
    {
        direction = dir;
        speed = projectileSpeed;
        damage = projectileDamage;
        StartMovement();
    }

    void StartMovement()
    {
        rb.velocity = direction * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SimpleEnemy"))
        {
            collision.gameObject.GetComponent<SimpleEnemy>().TakeDamage(damage);
        }
        else if (collision.gameObject.CompareTag("BossEnemy"))
        {
            collision.gameObject.GetComponent<BossEnemy>().TakeDamage(damage);
        }


        if (!(collision.CompareTag("Player")))
        {
            Destroy(gameObject);
        }

        // get info of hit object
        // apply small force as knockback
        // apply damage effect
    }

}

