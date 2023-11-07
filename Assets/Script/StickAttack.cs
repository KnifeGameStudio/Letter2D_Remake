using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickAttack : MonoBehaviour
{
    //private bool isAttacking = false;
    private Animator Anim_1;
    public int damage;
    private PolygonCollider2D Col;
    public float startTime;
    public float Waittime;
    private SpriteRenderer SR;
    public bool CanAttack;
    
    // Start is called before the first frame update
    void Start()
    {
        Anim_1 = GetComponent<Animator>();
        Col = GetComponent<PolygonCollider2D>();
        SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CanAttack)
        {
            Attack();
        }
    }
    
    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
 
            //Debug.Log(Input.GetAxisRaw("Attack"));
            Anim_1.SetTrigger("Attack");
            Col.enabled = false;
            StartCoroutine(StartAttack());
        }
    }

    IEnumerator StartAttack()
    {
        SoundManager.PlayAttackSound1();
        SR.enabled = true;
        yield return new WaitForSeconds(startTime);
        Col.enabled = true;
        StartCoroutine(disableHitBox());
    }
    
    IEnumerator disableHitBox()
    {
        yield return new WaitForSeconds(Waittime);
        Col.enabled = false;
        SR.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}
