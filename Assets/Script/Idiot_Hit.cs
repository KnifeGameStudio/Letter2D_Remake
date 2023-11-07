using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idiot_Hit : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject IdiotPrefab;
    public GameObject GoodPrefab;
    public float startWaitTime;
    private float waitTime;
    public float apperdown;
    public bool canShoot1;
    public bool canShoot2;
    void Start()
    {
        waitTime = startWaitTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (waitTime <= 0)
        {
            if (canShoot1)
            {
                shoot1();
                waitTime = startWaitTime;
            }
            else if (canShoot2)
            {
                shoot2();
                waitTime = startWaitTime;
            }
        }
        else
            {
                waitTime -= Time.deltaTime;
            }
    }

    void shoot1()
    {
        Vector2 appearPos = new Vector2(transform.position.x, transform.position.y - apperdown);
        Instantiate(IdiotPrefab, appearPos, transform.rotation);
    }

    void shoot2()
    {
        Vector2 appearPos = new Vector2(transform.position.x, transform.position.y - apperdown);
        Instantiate(GoodPrefab, appearPos, transform.rotation);
    }

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BigOld"))
        {
            Debug.Log("你真棒");
            if (waitTime <= 0)
            {
                shoot2();
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        else
        {
            Debug.Log("呆子");
            if (waitTime <= 0)
            {
                shoot1();
                waitTime = startWaitTime;
            }
            else
            {

                waitTime -= Time.deltaTime;
            }
        }*/
}
