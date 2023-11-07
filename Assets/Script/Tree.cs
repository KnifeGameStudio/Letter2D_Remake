using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public GameObject player;
    public Sprite rest;
    public Sprite tree;
    public bool OnRide = false;
    public int heal;
    private PlayerHealth playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
        player = GameObject.FindWithTag("Player");
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
            gameObject.GetComponent<SpriteRenderer>().sprite = tree;
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
        else if (OnRide == true)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = rest;
            gameObject.GetComponent<SpriteRenderer>().color = Color.green;
            player.GetComponent<SpriteRenderer>().enabled = false;
            player.GetComponent<PlayerCTRL>().CanMove = false;
            player.GetComponent<PlayerCTRL>().CanJump = false;
            playerHealth.HealPlayer(heal);
        }
    }
    
}
