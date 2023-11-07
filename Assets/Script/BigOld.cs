using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigOld : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite old;
    public Sprite bigOld;
    public bool OnRide = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //OnRide = GameObject.Find("Player").GetComponent<PlayerCTRL>().Riding;
        Change();
    }

    void Change()
    {
        if (OnRide == false)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = old;
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
        else if (OnRide == true)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = bigOld;
            gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        }
    }
}
