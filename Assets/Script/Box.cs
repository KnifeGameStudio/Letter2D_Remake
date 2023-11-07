using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Box : MonoBehaviour
{
    public Text my_Text;
    public float break_Time;

    private Animator anim;
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
        if (other.gameObject.CompareTag("Big") && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            anim.SetTrigger("Break");
            SoundManager.PlayBoxBreakSound();
            Invoke("BreakBox", break_Time);
            my_Text.text = "你撞碎了箱子";
        }
    }

    void BreakBox()
    {
        Destroy(gameObject);
    }
}
