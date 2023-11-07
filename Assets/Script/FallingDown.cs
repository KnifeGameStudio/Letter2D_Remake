using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingDown : MonoBehaviour
{
    // Start is called before the first frame update
    private int angle = 1;
    private bool falling = true;
    void Start()
    {
        gameObject.GetComponent<PlayerCTRL>().GravityModifier = false;
        gameObject.GetComponent<PlayerCTRL>().CanJump = false;
        gameObject.GetComponent<PlayerCTRL>().CanMove = false;
        Debug.Log("VAR");
        transform.eulerAngles = Vector3.forward * angle;
        //StartCoroutine(iwait());
    }

    // Update is called once per frame
    void Update()
    {
        if (falling)
        {
            angle += 1;
            transform.eulerAngles = Vector3.forward * angle;
            StartCoroutine(iwait());
        }
    }
    
    IEnumerator iwait()
    {
        yield return new WaitForSeconds(3.7f);

        gameObject.GetComponent<PlayerCTRL>().GravityModifier = true;
        gameObject.GetComponent<PlayerCTRL>().CanJump = true;
        gameObject.GetComponent<PlayerCTRL>().CanMove = true;
        falling = false;
        transform.eulerAngles = new Vector3(0, 0, 0);
    }
}
