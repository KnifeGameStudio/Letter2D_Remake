using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMonster : Enemy
{
    public float speed;
    public float startWaitTime;
    private float waitTime;
    public SpriteRenderer SP;
    public Transform movePos;
    public Transform leftDownPos;
    public Transform rightUpPos;
    public Sprite Mons0;
    public Animator anim;
    public float MonsDieTime;

    private PlayerHealth playerHealth;
    // Start is called before the first frame update
    public void Start()
    {
        SP = gameObject.GetComponent<SpriteRenderer>();
        anim = gameObject.GetComponent<Animator>();

        base.Start();
        waitTime = startWaitTime;
        movePos.position = GetRandomPos();
        playerHealth= GameObject.Find("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    public void Update()
    {
        base.Update();
        transform.position = Vector2.MoveTowards(transform.position, movePos.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, movePos.position) < 0.1f)
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
        anim.SetFloat("Monster_Health", 7.0f);
        if (health >= 7)
        {
            SP.sprite = Mons0;
        }
        else if (health >= 5)
        {
            anim.SetFloat("Monster_Health", 5.0f);

        }
        else if (health >= 3)
        {
            anim.SetFloat("Monster_Health", 3.0f);

        }
        else if (health >= 1)
        {
            anim.SetFloat("Monster_Health", 1.0f);

        }
        else if (health <= 0)
        {
            anim.SetFloat("Monster_Health", 0);
            Invoke("KillMons", MonsDieTime);
        }
        
    }

    void KillMons()
    {
        Destroy(gameObject);
    }

    Vector2 GetRandomPos()
    {
        Vector2 randomPos = new Vector2(Random.Range(leftDownPos.position.x, rightUpPos.position.x),
            Random.Range(leftDownPos.position.y, rightUpPos.position.y));
        return randomPos;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Big")|| other.gameObject.CompareTag("Do")) && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            if (playerHealth != null)
            {
                //this damage is the damage from enemy to the player
                playerHealth.DamagePlayer(damage);
            }
        }
    }

}
