using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class TestEnemy : MonoBehaviour, IDamageable
{
    public int hp;

    public void TakeDamage()
    {
        hp -= 1;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
