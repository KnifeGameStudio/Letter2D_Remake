using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Door_As_Portal : MonoBehaviour
{
    public Text my_Text;
    // Start is called before the first frame update
    public Transform backDoor;

    private bool isDoor;
    private Transform playerTransform;
    void Start()
    {
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Ride") == 1)
        {
            EnterDoor();
        }
    }

    void EnterDoor()
    {
        if (isDoor)
        {
            StartCoroutine( iwait());
            GameObject.Find("Mother").GetComponentInChildren<Parents>().InvisibleEnter = true;
            GameObject.Find("Father").GetComponentInChildren<Parents>().InvisibleEnter = true;
        }
    } 
    
    IEnumerator iwait()
    {
        yield return new WaitForSeconds(0.5f);
        playerTransform.position = backDoor.position;
    }
        
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Invisible"))
        {
            isDoor = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Invisible"))
        {
            my_Text.text = "Press E to Enter";
            isDoor = false;
            /*GameObject.Find("Mother").GetComponentInChildren<Parents>().InvisibleEnter = false;
            GameObject.Find("Father").GetComponentInChildren<Parents>().InvisibleEnter = false;*/
        }
    }
}
