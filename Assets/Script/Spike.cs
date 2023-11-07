using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    // Start is called before the first frame update
    public int damage;
    private PlayerHealth playerHealth;
    void Start()
    {
        playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            if (playerHealth != null)
            {
                //this damage is the damage from enemy to the player
                playerHealth.DamagePlayer(damage);
            }
        }
    }
}
