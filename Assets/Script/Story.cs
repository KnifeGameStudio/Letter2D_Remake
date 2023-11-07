using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story : MonoBehaviour
{
    public bool OnRide;
    public Sprite do_it;
    public Sprite story;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OnRide)
        {
            Vector3 parentPosition = gameObject.transform.parent.position;
            gameObject.GetComponent<SpriteRenderer>().sprite = do_it;
            BoxCollider2D[] myColliders = gameObject.GetComponents<BoxCollider2D>();
            foreach (BoxCollider2D bc in myColliders) bc.enabled = false;
            gameObject.transform.position = parentPosition;
        }
        else if (!OnRide)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = story;
            BoxCollider2D[] myColliders = gameObject.GetComponents<BoxCollider2D>();
            foreach (BoxCollider2D bc in myColliders) bc.enabled = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
