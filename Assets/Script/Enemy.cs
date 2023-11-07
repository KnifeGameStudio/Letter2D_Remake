using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int damage;
    public int health;
    
    //private SpriteRenderer sr;
    private Color originalColor;
    private PlayerHealth playerHealth;

    //public float FlashTime;
    
    // Start is called before the first frame update
    public void Start()
    {
        //sr = GetComponent<SpriteRenderer>();
        //originalColor = sr.color;
        playerHealth= GameObject.Find("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    public void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        //FlashColor(FlashTime);
    }
    
    /*void FlashColor(float time)
    {
        //sr.color = Color.red;
        Invoke("ResetColor", time);
    }
    void ResetColor()
    {
        //sr.color = originalColor;
    }*/
}
