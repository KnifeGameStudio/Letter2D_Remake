using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peer_Dead : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Roll"))
        {
            //GameObject roll = other.gameObject;
            anim.SetTrigger("Peer_Dead");
            //StartCoroutine(iwait(roll));
        }
    }

    IEnumerator iwait()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
        //Destroy(roll);
    }
}
