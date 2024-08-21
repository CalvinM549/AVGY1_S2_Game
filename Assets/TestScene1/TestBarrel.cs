using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBarrel : MonoBehaviour, IDamagable
{
    public void TakeDamage()
    {
        Destroy(gameObject);
    }
}
