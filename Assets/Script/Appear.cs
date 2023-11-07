using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Appear : MonoBehaviour
{
    //public SpriteRenderer spriteToFade;
    public float delay;

    void Start()
    {
        StartCoroutine(fadeIn(gameObject.GetComponent<Text>(), 2f, delay));
    }


    IEnumerator fadeIn(Text MyRenderer, float duration, float delay)
    {
        float counter = 0;
        //Get current color
        Color spriteColor = MyRenderer.color;

        yield return new WaitForSeconds(delay);

        while (counter < duration)
        {
            counter += Time.deltaTime;
            //Fade from 1 to 0
            float alpha = Mathf.Lerp(0, 1, counter / duration);
            //Debug.Log(alpha);

            //Change alpha only
            MyRenderer.color = new Color(spriteColor.r, spriteColor.g, spriteColor.b, alpha);
            //Wait for a frame
            yield return null;
        }

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

        if(delay == 13)
        {
            SceneManager.LoadScene("Menu");
        }

        if (delay == 18)
        {
            SceneManager.LoadScene("Scene3");
        }
    }
}