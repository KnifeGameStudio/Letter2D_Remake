using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
public class MoveOld : MonoBehaviour
{
    public bool OnRide = false;
    public GameObject Big1;
    public GameObject Old1;
    public GameObject BigOld1;
    public bool TeacherMons = true;
    // Start is called before the first frame update
    void Start()
    {
        Big1 = GameObject.Find("Big1");
        Old1 = GameObject.Find("Old1");
        BigOld1 = GameObject.Find("BigOld1");
    }

    // Update is called once per frame
    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
    void Update()
    {
        if (OnRide)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            
            Big1.GetComponent<SpriteRenderer>().enabled = true;
            Old1.GetComponent<SpriteRenderer>().enabled = false;
            BigOld1.GetComponent<SpriteRenderer>().enabled = true;
            
            Big1.GetComponent<BoxCollider2D>().enabled = false;
            
            Vector3 parentPosition = gameObject.transform.parent.position;
            gameObject.transform.position = parentPosition;
            
            Big1.transform.position = new Vector2(BigOld1.transform.position.x - 3.7f, BigOld1.transform.position.y);
            
            if (GameObject.Find("TeacherMons") != null)
            {
                GameObject.Find("TeacherMons").GetComponent<Idiot_Hit>().canShoot1 = false;
            }
            
            else if (GameObject.Find("TeacherMons") == null)
            {
                TeacherMons = false;
                StartCoroutine(DestroySelf());
            }


        }
        
        else if (!OnRide)
        {

            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            
            BigOld1.GetComponent<SpriteRenderer>().enabled = false;
            Big1.GetComponent<SpriteRenderer>().enabled = true;
            Old1.GetComponent<SpriteRenderer>().enabled = true;
            
            BigOld1.GetComponent<BoxCollider2D>().enabled = false;
            Big1.GetComponent<BoxCollider2D>().enabled = true;

            if (gameObject.transform.parent == null)
            {
                gameObject.transform.position = new Vector2(gameObject.transform.position.x,GameObject.Find("Ground").transform.position.y+4.7f);
                Old1.transform.position = new Vector2(Big1.transform.position.x + 3.7f, Big1.transform.position.y);
            }
        }
    }
}
