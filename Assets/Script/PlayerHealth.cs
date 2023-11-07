using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int health;

    private SpriteRenderer Player_SR;
    private Color originalColor;
    public float FlashTime;

    private Animator anim;
    public float dieTime;
    //public Sprite ghost;
    
    void Start()
    {
        Player_SR = GetComponent<SpriteRenderer>();
        originalColor = Player_SR.color;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.HealthCurrent = health;
    }

    public void DamagePlayer(int damage)
    {
        SoundManager.PlayAttackedSound1();
        health -= damage;
        if (health < 0)
        {
            health = 0;
        }
        FlashColor(FlashTime);
        HealthBar.HealthCurrent = health;
        if (health <= 0)
        {
            anim.SetTrigger( "Die");
            Invoke("KillPlayer", dieTime);
        }
    }

    /*void BecomeGhost()
    {
        Player_SR.sprite = ghost;
        Invoke("KillPlayer", dieTime);
    }*/
    public void HealPlayer(int heal)
    {
        if (health < 10)
        {
            health += heal;
        }

        if (health >= 10)
        {
            health = 10;
        }
    }
    void KillPlayer()
    {
        
        //Destroy(gameObject);
        SceneManager.LoadScene("Main_Menu");
    }

    void FlashColor(float time)
    {
        Player_SR.color = Color.red;
        Invoke("ResetColor", time);
    }
    void ResetColor()
    {
        Player_SR.color = originalColor;
    }

}
