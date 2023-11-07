using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearts_Likes : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    public SpriteRenderer Sp;
    void Start()
    {
        anim = GetComponent<Animator>();
        Sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BigOld"))
        {
            Sp.enabled = true;
            anim.SetTrigger("IsBigOld");
            StartCoroutine(iwait());
        }
    }
    
    IEnumerator iwait()
    {
        yield return new WaitForSeconds(1f);
        GameObject.Find("TeacherMons").GetComponent<Idiot_Hit>().canShoot2 = true;

    }
}
