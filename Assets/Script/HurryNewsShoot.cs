using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurryNewsShoot : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject NewsPrefab;
    public float startWaitTime;
    private float waitTime;
    public float apperdown;
    public float appearleft;
    void Start()
    {
        waitTime = startWaitTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (waitTime <= 0)
        {
            shoot();
            waitTime = startWaitTime;
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
        
    }

    void shoot()
    {
        Vector2 appearPos = new Vector2(transform.position.x - appearleft, transform.position.y - apperdown);
        Instantiate(NewsPrefab, appearPos, transform.rotation);
    }
}
