using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tesxt : MonoBehaviour
{

    public Transform enemy;
    public Vector2 forwardDirection;
    public Vector2 enemyDirection;
    public Vector2 mousePosition;
    public float angle;
    public bool enemyHit;

    // Update is called once per frame
    void Update()
    {
        CalculateAngle();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (enemy != null)
            {
                enemy.GetComponent<IDamagable>().TakeDamage();
            }
        }
    }

    public void CalculateAngle()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        forwardDirection = mousePosition - (Vector2)transform.position;
        transform.up = forwardDirection;

        enemyDirection = enemy.position - transform.position;
        angle = Vector2.Angle(forwardDirection, enemyDirection);

        if(angle <= 30)
        {
            enemyHit = true;
        }
        else
        {
            enemyHit = false;
        }
    }
}
