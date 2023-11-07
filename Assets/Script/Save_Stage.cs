using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save_Stage : MonoBehaviour
{
    public int stage;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.DontDestroyOnLoad(gameObject);
        stage = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
