using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrap : MonoBehaviour
{

    public GameObject testWarningCircle;
    Collider2D[] hitColliders;
    public Player player;
    public float delay;
    public int damage;
    public int areaSize;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //draws warning circle        
        GameObject warning = Instantiate(testWarningCircle, transform.position, transform.rotation);
        warning.transform.localScale = new Vector3(areaSize * 2, areaSize * 2, 0);
        Destroy(warning, delay); // removes warning circle after damage occurs
        Destroy(gameObject, delay); // removes self after damage occurs
        StartCoroutine(DamagePlayer());
    }


    IEnumerator DamagePlayer()
    {
        yield return new WaitForSeconds(delay);


        hitColliders = Physics2D.OverlapCircleAll(transform.position, areaSize);

        foreach (Collider2D collider in hitColliders)
        {
            if (collider.CompareTag("Player"))
            {
                collider.gameObject.GetComponent<Player>().TakeDamage(damage);
            }
        }
    }
}
