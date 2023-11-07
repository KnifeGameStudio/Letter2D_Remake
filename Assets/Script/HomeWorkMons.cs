using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeWorkMons : Enemy
{
    public float speed;
    public float startWaitTime;
    private float waitTime;

    public Transform movePos;
    public Transform leftDownPos;
    public Transform rightUpPos;
    private Vector2 randomPos;
    private PlayerHealth playerHealth;
    public SpriteRenderer SP;
    public int being_damaged;
    public Sprite HW1;
    public Sprite HW2;
    public Sprite HW3;
    public Sprite HW4;
    
    void Start()
    {
        SP = GetComponent<SpriteRenderer>();
        base.Start();
        waitTime = startWaitTime;
        movePos.position = GetRandomPos();
        playerHealth= GameObject.Find("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {

        if (health >= 7)
        {
            SP.sprite = HW1;
        }
        else if (health >= 5)
        {
            SP.sprite = HW2;
        }
        else if (health >= 3)
        {
            SP.sprite = HW3;
        }
        else if (health >= 1)
        {
            SP.sprite = HW4;
        }

        else if (health <= 0)
        {
            /*gameObject.transform.GetChild(0).GetChild(0).GetComponent<EnemyMonster>().enabled = true;
            gameObject.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().enabled = true;
            gameObject.transform.GetChild(0).parent = null;*/
            Destroy(gameObject);
        }
        
        if (Mathf.Abs(transform.position.x - movePos.position.x ) < 0.5f)
        {
            if (waitTime <= 0)
            {
                movePos.position = GetRandomPos();
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, movePos.position, speed * Time.deltaTime);
        }
    }
    
    Vector2 GetRandomPos()
    {
        randomPos = new Vector2(Random.Range(leftDownPos.position.x, rightUpPos.position.x),
            Random.Range(leftDownPos.position.y, rightUpPos.position.y)*0 + transform.position.y );
        return randomPos;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Do") && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            if (other.gameObject.CompareTag("Do"))
            {
                gameObject.GetComponent<HomeWorkMons>().TakeDamage(being_damaged);
                SoundManager.PlayWriteSound();
            }
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
