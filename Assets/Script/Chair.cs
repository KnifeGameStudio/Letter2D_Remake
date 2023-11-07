using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : MonoBehaviour
{
    public Rigidbody2D Rig;
    // Start is called before the first frame update
    void Start()
    {
        Rig = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Big"))
        {
            Rig.constraints = RigidbodyConstraints2D.None;
        }
        else if (other.CompareTag("Player"))
        {
            Rig.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}
