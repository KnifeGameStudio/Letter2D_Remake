﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterButton : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject letter;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void click()
    {
        letter.SetActive(!letter.activeSelf);
    }
}
