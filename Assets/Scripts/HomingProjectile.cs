using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingProjectile : MonoBehaviour
{
    public Rigidbody2D rb;
    public int speed;
    Transform player;
    Player playerScript;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 moveDirection = (player.position - transform.position).normalized;
        rb.velocity = moveDirection * Time.deltaTime * speed;
    }

    public void SetPlayer(Player p)
    {
        playerScript = p;
        player = p.transform;
    }
}
