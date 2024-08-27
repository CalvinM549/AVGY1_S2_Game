using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBarrel : MonoBehaviour, IDamageable
{
    public void TakeDamage()
    {
        Destroy(gameObject);
    }
}
