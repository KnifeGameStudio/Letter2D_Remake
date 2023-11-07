using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class DoorToNextLevel : MonoBehaviour
{
    
    // Start is called before the first frame update
    public Text my_Text;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                //Debug.Log("hi2");
                var letter = GameObject.Find("Letter").GetComponent<SpriteRenderer>();
                var gu = GameObject.Find("Hard").GetComponent<SpriteRenderer>();
                var you = GameObject.Find("Have").GetComponent<SpriteRenderer>();
                var bg = GameObject.Find("DeskBG").GetComponent<SpriteRenderer>();
                var man = GameObject.Find("Player").GetComponent<SpriteRenderer>();
                man.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                GameObject.Find("Player").GetComponent<PlayerCTRL>().CanMove = false;
                GameObject.Find("Player").GetComponent<PlayerCTRL>().CanJump = false;
                StartCoroutine(fade(letter, 3, 0));
                StartCoroutine(fade(gu, 3, 0));
                StartCoroutine(fade(you, 3, 0));
                StartCoroutine(fade(bg, 3, 0));
                StartCoroutine(fade(man, 3, 0));
                StartCoroutine(ExampleCoroutine());
            }
            
            else
            {
                my_Text.text = "按E进入";
                if (Input.GetAxisRaw("Ride") == 1)
                {
                    Debug.Log("FUCK!!!!");
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                    SoundManager.PlayDoorSound();
                }
            }
        }
    }
    
    IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(10);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator fade(SpriteRenderer MyRenderer, float duration, float delay)
    {
        float counter = 0;
        //Get current color
        Color spriteColor = MyRenderer.color;
        yield return new WaitForSeconds(delay);
        counter = 0;
        spriteColor = MyRenderer.color;
        while (counter < duration)
        {
            counter += Time.deltaTime;
            //Fade from 1 to 0
            float alpha = Mathf.Lerp(1, 0, counter / duration);
            //Debug.Log(alpha);

            //Change alpha only
            MyRenderer.color = new Color(spriteColor.r, spriteColor.g, spriteColor.b, alpha);
            //Wait for a frame
            yield return null;
        }
    }
}
