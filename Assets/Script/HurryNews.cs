using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurryNews : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float DestroyDistance;
    private Rigidbody2D rb2D;
    private Vector3 startPos;
    private PlayerHealth playerHealth;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.velocity = transform.right * -speed;
        startPos = transform.position;
        playerHealth= GameObject.Find("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        float Distance = (transform.position - startPos).sqrMagnitude;
        if (Distance > DestroyDistance)
        {
            Destroy(gameObject);
        }
    }
    
    
}
