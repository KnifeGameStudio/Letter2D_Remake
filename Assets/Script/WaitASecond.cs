using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitASecond : MonoBehaviour
{
    public GameObject word;
    public float delay;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(iwait());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator iwait()
    {
        yield return new WaitForSeconds(delay);
        word.SetActive(true);
    }
}
