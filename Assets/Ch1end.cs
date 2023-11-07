using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ch1end : MonoBehaviour
{
    public bool ITB;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        ITB = GameObject.Find("MotherMove").GetComponent<Parents>().InternetBar;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && ITB)
        {
            SceneManager.LoadScene("Ch1ending");
        }
    }
}
