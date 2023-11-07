using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercise : Enemy
{
    private PlayerHealth playerHealth;
    public int being_damaged;
    
    public SpriteRenderer SP;
    public Sprite TS1;
    public Sprite TS2;
    public Sprite TS3;
    public Sprite TS4;
    // Start is called before the first frame update
    void Start()
    {
        SP = GetComponent<SpriteRenderer>();
        playerHealth= GameObject.Find("Player").GetComponent<PlayerHealth>();
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (health >= 6)
        {
            SP.sprite = TS1;
        }
        else if (health >= 5)
        {
            SP.sprite = TS2;
        }
        else if (health >= 3)
        {
            SP.sprite = TS3;
        }
        else if (health >= 1)
        {
            SP.sprite = TS4;
        }
        
        if (health <= 0)
        {
            BoxCollider2D[] myColliders = GameObject.Find("Roll").GetComponents<BoxCollider2D>();
            GameObject.Find("Roll").GetComponent<Book>().enabled = true;
            foreach(BoxCollider2D bc in myColliders) bc.enabled = true;
            GameObject.Find("Roll").transform.parent = null;
            Destroy(gameObject);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Do") && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            if (other.gameObject.CompareTag("Do"))
            {
                gameObject.GetComponent<Exercise>().TakeDamage(being_damaged);
            }
            SoundManager.PlayWriteSound();
            
        }
        
        else if ((other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Big"))
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
