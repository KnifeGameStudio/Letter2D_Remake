using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TeacherMonster : Enemy
{
    // Start is called before the first frame update
    public float speed;
    public float startWaitTime;
    private float waitTime;

    public Transform movePos;
    public Transform leftDownPos;
    public Transform rightUpPos;
    private Vector2 randomPos;


    //private PlayerHealth playerHealth;

    void Start()
    {
        base.Start();
        waitTime = startWaitTime;
        movePos.position = GetRandomPos();

        //playerHealth= GameObject.Find("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Idiot_Hit>().canShoot1)
        {
            if (Mathf.Abs(transform.position.x - movePos.position.x) < 0.1f)
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
                transform.position = Vector2.MoveTowards(transform.position,
                    movePos.position, speed * Time.deltaTime);
            }
        }
        
        else if (gameObject.GetComponent<Idiot_Hit>().canShoot2)
        {
            takePlayerBack();
        }
    }
    
    Vector2 GetRandomPos()
    {
        randomPos = new Vector2(Random.Range(leftDownPos.position.x, rightUpPos.position.x),
            Random.Range(leftDownPos.position.y, rightUpPos.position.y)*0 + transform.position.y );
        return randomPos;
    }
    
    void takePlayerBack()
    {
        StartCoroutine(iwait());
    }
    
    IEnumerator iwait()
    {
        yield return new WaitForSeconds(3f);
        Vector2 moveTo = new Vector2(transform.position.x + 50f, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, 
            moveTo , speed * Time.deltaTime);
        StartCoroutine(KillSelf());
    }

    IEnumerator KillSelf()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
