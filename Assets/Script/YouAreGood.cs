using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouAreGood : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public int heal;
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("You Are Good");
        if ((other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Big") || other.CompareTag("BigOld"))
            && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            { 
                playerHealth.HealPlayer(heal);
                //other.GetComponent<SpriteRenderer>().color = Color.green;;
            }
        }
    }
}
