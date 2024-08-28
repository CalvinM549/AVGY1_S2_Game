using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public new BoxCollider2D collider;
    

    // Start is called before the first frame update
    void Start()
    {
        collider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collider.enabled = true;    
    }
}
