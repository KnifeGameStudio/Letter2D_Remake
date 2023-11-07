using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parents : MonoBehaviour
{
    // Start is called before the first frame update
    
    public float speed;
    public Transform leftDownPos;
    public Transform Original;
    public bool InternetBar;
    public bool InvisibleEnter = false;
    private BoxCollider2D Col;
    //public Transform rightUpPos;

    private bool x;
    void Start()
    {
        Col = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    
    
    void Update()
    {
        if (InternetBar && !InvisibleEnter)
        {
            takePlayerBack();
            int n = gameObject.transform.childCount;
            for (int i=0; i <n; i += 1)
            {
                gameObject.transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = true;
            }
            Col.enabled = true;
        }

        else if (InvisibleEnter)
        {
            //takePlayerBack();
            int n = gameObject.transform.childCount;
            for (int i=0; i <n; i += 1)
            {
                gameObject.transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = true;
            }
            Col.enabled = true;
            x = true;
        }
        else if (!InternetBar && !InvisibleEnter)
        {
            int n = gameObject.transform.childCount;
            for (int i=0; i <n; i += 1)
            {
                gameObject.transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = false;
            }
            Col.enabled = false;
            x = true;
        }
    }

    void takePlayerBack()
    {
        transform.position = Vector2.MoveTowards(transform.position, 
            leftDownPos.position, speed * Time.deltaTime);
        if(true){StartCoroutine(iwait());
            x = true;
        }
        

    }
    
    IEnumerator iwait()
    {
        yield return new WaitForSeconds(6f);
        GameObject.Find("Player").GetComponent<PlayerCTRL>().Riding = false;
        Debug.Log(GameObject.Find("Player").GetComponent<PlayerCTRL>().Riding);
        InternetBar = false;
        transform.position = Vector2.MoveTowards(transform.position, 
            Original.position, speed * 6 * Time.deltaTime);
        x = true;

    }
    
}
