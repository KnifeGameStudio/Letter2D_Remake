using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idiot : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public int damage;
    public float DestroyDistance;

    private Rigidbody2D rb2D;
    private Vector3 startPos;
    private PlayerHealth playerHealth;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.velocity = transform.right * -speed;
        startPos = transform.position;
        playerHealth= GameObject.Find("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        float Distance = (transform.position - startPos).sqrMagnitude;
        if (Distance > DestroyDistance)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Big"))
            && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            if (playerHealth != null)
            {
                //this damage is the damage from enemy to the player
                playerHealth.DamagePlayer(damage);
            }
        }
    }
}
