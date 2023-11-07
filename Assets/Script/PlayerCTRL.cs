using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using Color = UnityEngine.Color;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

using DialogueEditor;
public class PlayerCTRL : MonoBehaviour
{
    [Header("Sprite Renderers")] 
    public String RidingOn;
    //public Sprite player_sprite;

    public Sprite invisible;

    //public Sprite 
    
    public bool Riding = false;
    
    public bool IsBig = false;
    public float biggerTime;
    
    public Text my_Text;

    [Header("Move")]
    public float WalkSpeed;
    public float AccelerationTime;
    public float DecelerationTime;
    public bool CanMove = true;
    
    [Header("Jump")]
    public float JumpingSpeed = 11;
    public float FallMultiplier;
    public float LowJumpMultiplier;
    public bool CanJump;

    [Header("IsGround")]
    public Vector2 PointOffset;
    public Vector2 Size;
    public LayerMask GroundLayerMask;
    public bool GravityModifier = true;
    
    [Header("Dash")] 
    private bool isDashing;
    private bool WasDashed;
    public float DragMaxForce;
    public float DragDuration;
    public float DashForce;
    public float DashWaitTime;
    public bool CanDash = false;
    private Vector2 dir; // Decide the direction of dash from player
    
    public Rigidbody2D Rig;
    private Animator Anim;
    private SpriteRenderer SR;

    public float velocityX;

    private bool IsJumping;
    private bool IsOnGround;

    public AudioClip AC;
    private int isplaying = 0;

    //private bool GravitySwitch = true;
    
    // Start is called before the first frame update
    private void Start()
    {
        Rig = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        SR = GetComponent<SpriteRenderer>();
    }

    private void AfterRide()
    {
        Rig.velocity = Vector2.zero;
        CanMove = false;
        CanJump = false;
    }
    
    IEnumerator AfterRideOnOld()
    {
        yield return new WaitForSeconds(2f);
        SoundManager.PlayBiggerSound();
        GameObject.Find("MoveOld").GetComponent<MoveOld>().OnRide = false;
        GameObject.Find("MoveOld").gameObject.transform.parent = null;
        Recover();
    }

    IEnumerator AfterRideOnStory()
    {
        yield return new WaitForSeconds(2f);
        SoundManager.PlayBiggerSound();
        GameObject.Find("Story1").gameObject.GetComponent<Story>().OnRide = false;
        GameObject.Find("Story1").transform.parent = null;
        Recover();
    }

    IEnumerator AfterRideOnTree()
    {
        yield return new WaitForSeconds(2f);
        SoundManager.PlayBiggerSound();
        GameObject.Find("Tree").gameObject.GetComponent<Tree>().OnRide = false;
        Recover();
    }
    
    
// Update is called once per frame
    void FixedUpdate()
    {
        //GameObject.Find("Stage_Count").GetComponent<Save_Stage>().stage = SceneManager.GetActiveScene().buildIndex;
        IsOnGround = OnGround();

        LeftRightMove();

        Jump();

        GravityAjdustment();

        Dash();
        
        if (!Riding && OnGround()){
            Bigger();

            Smaller();
        }
        if (Riding && OnGround())
        {
            //my_Text.text = "按F离开";
            //不断刷新看是否正在骑，如果没有则还原

            if (GameObject.Find("MoveOld") != null && GameObject.Find("MoveOld").GetComponent<MoveOld>().TeacherMons == false)
            {
                Recover();
            }
            
            if (Input.GetAxisRaw("OffRide") == 1 && isplaying == 1)
            {
                isplaying = 0;
                Rig.gravityScale = 1;
                Debug.Log("RidingOn" + RidingOn);
                AfterRide();
                
                if (RidingOn == "Old")
                {
                    StartCoroutine(AfterRideOnOld());
                }
                
                else if (RidingOn == "Tree")
                {
                    StartCoroutine(AfterRideOnTree());
                }
                
                else if (RidingOn == "Story")
                {
                    StartCoroutine(AfterRideOnStory());
                }
                /*else
                {
                    int n = GameObject.Find("RideOnThings").transform.childCount;
                    for (int i=0; i <n; i += 1)
                    {
                        GameObject.Find("RideOnThings").transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = false;
                        GameObject.Find(RidingOn).transform.position = gameObject.transform.position;
                    }
                }*/
            }
        }
    }

    void Recover()
    {
        gameObject.tag = "Player";
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        CanMove = true;
        CanJump = true;
        Riding = false;
        RidingOn = "";
    }
    
    IEnumerator Dash_IE()
    {
        // Close the Function of Player's Move
        CanMove = false;
        CanJump = false;

        //Close the Gravity Adjustment
        GravityModifier = false;

        //Close Gravity
        Rig.gravityScale = 0;
        
        //Add an Air Friction
        DOVirtual.Float(DragMaxForce, 0, DragDuration, RigidbodyDrag);

        //Wait several seconds
        yield return new WaitForSeconds(DashWaitTime);
        
        //Turn On all the things off
        CanMove = true;
        CanJump = true;
        GravityModifier = true;
        Rig.gravityScale = 1;
    }

    public void RigidbodyDrag(float x)
    {
        Rig.drag = x;
    }
    bool OnGround()
    {
        Collider2D Coll= Physics2D.OverlapBox((Vector2)transform.position + PointOffset,Size,0,GroundLayerMask);
        if (Coll != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    void LeftRightMove()
    {
        if (CanMove)
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                Rig.velocity =
                    new Vector2(
                        Mathf.SmoothDamp(Rig.velocity.x, WalkSpeed * Time.fixedDeltaTime * 60, ref velocityX,
                            AccelerationTime), Rig.velocity.y);
                SR.flipX = false;
                Anim.SetFloat("Walk", 1f);
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                Rig.velocity =
                    new Vector2(
                        Mathf.SmoothDamp(Rig.velocity.x, WalkSpeed * Time.fixedDeltaTime * 60 * -1, ref velocityX,
                            AccelerationTime), Rig.velocity.y);
                SR.flipX = true;
                Anim.SetFloat("Walk", 1f);
            }
            else if (Input.GetAxis("Horizontal") == 0)
            {
                Rig.velocity = new Vector2(Mathf.SmoothDamp(Rig.velocity.x, 0, ref velocityX, DecelerationTime),
                    Rig.velocity.y);
                Anim.SetFloat("Walk", 0);
            }
        }
    }
    void Jump()
    {
        if (CanJump)
        {
            if (Input.GetAxis("Jump") == 1 && IsJumping == false)
            {
                Rig.velocity = new Vector2(Rig.velocity.x, JumpingSpeed);
                IsJumping = true;
                Anim.SetBool("Jumping", true);
            }

            if (IsOnGround && Input.GetAxis("Jump") == 0)
            {
                IsJumping = false;
                Anim.SetBool("Jumping", false);
            }
        }
    }
    void GravityAjdustment()
    {
        if (GravityModifier)
        {
            if (Rig.velocity.y < 0) // When the Player is Falling
            {
                Rig.velocity +=
                    Vector2.up * Physics2D.gravity.y * (FallMultiplier - 1) *
                    Time.fixedDeltaTime; // (Fasten Going Down)
            }
            else if (Rig.velocity.y > 0 && Input.GetAxis("Jump") != 1
            ) //When the Player is Going Up, and he didn't press Jump Button
            {
                Rig.velocity += Vector2.up * Physics2D.gravity.y * (LowJumpMultiplier - 1) *
                                Time.fixedDeltaTime; // (Slow Down Going Up)
            }
        }
    }

    void Dash()
    {
        if (CanDash)
        {
            if (Input.GetAxisRaw("Dash") == 1 && !WasDashed)
            {
                WasDashed = true;
                dir = GetDir();
                //Clear the current momentum 
                Rig.velocity = Vector2.zero;

                //Add a Force to let Player Dash
                Rig.velocity += dir.normalized * DashForce;

                StartCoroutine(Dash_IE());
            }

            if (IsOnGround && Input.GetAxis("Dash") == 0)
            {
                WasDashed = false;
            }
        }
    }

    void Bigger()
    {
        int hello = 0;
        if (Input.GetAxis("Bigger") == 1 && hello == 0)
        {
            hello = 1;
            Rig.velocity = Vector2.zero;
            CanJump = false;
            CanMove = false;
            Debug.Log("BBBBBBB");
            Anim.SetFloat("Bigger", 6);
            Invoke("BecomeBigger", biggerTime);
            gameObject.tag = "Big";
        }
    }
    
    void BecomeBigger()
    {
        gameObject.transform.localScale = new Vector2(2, 2);

        Anim.SetFloat("Bigger", 0);
        PointOffset = new Vector2(0f, -2.5f);
        Anim.SetBool("IsBig", true);
        /*AudioSource.PlayClipAtPoint(AC,transform.localPosition);*/
        SoundManager.PlayBiggerSound();
        IsBig = true;
        JumpingSpeed = 8;
        CanJump = true;
        CanMove = true;
    }
    
    void Smaller()
    {
        if (Input.GetAxisRaw("OffRide") == 1  && IsBig)
        //if (Input.GetKeyDown(KeyCode.F) && IsBig)
        {
            Rig.velocity = Vector2.zero;
            CanJump = false;
            CanMove = false;
            Debug.Log("SSSSSSSS");
            Anim.SetFloat("Smaller", 6);
            Invoke("BecomeSmall", biggerTime);
            JumpingSpeed = 11;
            gameObject.tag = "Player";
        }
    }

    void BecomeSmall()
    {
        gameObject.transform.localScale = new Vector2(1, 1);
        Anim.SetFloat("Smaller", 0);
        PointOffset = new Vector2(0f, -1.37f);
        Anim.SetBool("IsBig", false);
        IsBig = false;
        CanJump = true;
        CanMove = true;
    }
    
    public Vector2 GetDir()
    {
        Vector2 tempDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (tempDir.x == 0 && tempDir.y == 0)
        {
            if (!SR.flipX)
            {
                tempDir.x = 1;
            }
            else
            {
                tempDir.x = -1;
            }
        }
        return tempDir;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube((Vector2)transform.position + PointOffset,Size);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Help_Peer")
        {
            my_Text.text = "他好像有什么话要说...按E查看";
        }
    }

    private void BeforeRide()
    {
        isplaying = 1;
        Rig.velocity = Vector2.zero;
        CanMove = false;
        CanJump = false;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (gameObject.CompareTag("Player") || gameObject.CompareTag("Big") || gameObject.CompareTag("Ear"))
        {
            if (other.name == "Tutorial0")
            {
                my_Text.text = "按B试试";
            }

            if (other.name == "Tutorial1")
            {
                my_Text.text = "试试按F";
            }

            if (other.name == "Tutorial2")
            {
                my_Text.text = "试试空格";
            }

            if (other.name == "Tutorial3")
            {
                my_Text.text = "长按空格能跳更高哦";
            }

            if (other.name == "Tutorial4")
            {
                my_Text.text = "前面有个作业怪";
            }

            if (other.name == "Tutorial5")
            {
                my_Text.text = "怎样才能把作业“做”掉呢";
            }

            if (other.name == "Tutorial6")
            {
                my_Text.text = "这个“故”字说不定有点用";
            }

            if (other.name == "Tutorial7")
            {
                my_Text.text = "好像不够高，要是能找到一个台阶就好了";
            }

            if (other.name == "Tutorial8")
            {
                my_Text.text = "那个椅子好像能被推动";
            }

            if (other.name == "Tutorial9")
            {
                my_Text.text = "这儿有棵树诶，试试靠近按E呢";
            }

            if (other.name == "Tutorial10")
            {
                my_Text.text = "好像有声音传过来。。。";
            }

            if (other.name == "Tutorial11")
            {
                my_Text.text = "让我竖起耳朵（按E）听一听";
                if (Input.GetAxis("Ride") == 1)
                {
                    GameObject.Find("Ear").GetComponent<SpriteRenderer>().enabled = true;
                    gameObject.tag = "Ear";
                    Destroy(GameObject.Find("Tutorial11"));
                }
            }

            if (other.name == "Help_Peer")
            {
                if (Input.GetAxis("Ride") == 1)
                {
                    my_Text.text = "'老师真的太偏心了，都只对'大佬'好！'";
                }
            }
            IEnumerator BeforeRideOnTree()
            {
                yield return new WaitForSeconds(2f);
                SoundManager.PlayBiggerSound();
                other.gameObject.GetComponent<Tree>().OnRide = true;
            }
            
            
            IEnumerator BeforeRideOnOld()
            {
                yield return new WaitForSeconds(2f);
                SoundManager.PlayBiggerSound();
                other.gameObject.GetComponent<MoveOld>().OnRide = true;
                CanMove = true;
                CanJump = true;
            }
            
            IEnumerator BeforeRideOnStory()
            {
                yield return new WaitForSeconds(2f);
                SoundManager.PlayBiggerSound();
                other.GetComponent<Story>().OnRide = true;
                CanMove = true;
                CanJump = true;
            }
            
            //Ride On Tree
            if (other.gameObject.CompareTag("Tree") && !Riding)
            {
                if (Input.GetAxis("Ride") == 1)
                {
                    my_Text.text = "你得到了“休”息，按F离开";
                    Rig.velocity = Vector2.zero;
                    Riding = true;
                    RidingOn = "Tree";
                    BeforeRide();
                    gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    StartCoroutine(BeforeRideOnTree());
                    Debug.Log("RidingOnTree");
                }
            }
            //Ride On Do
            else if (other.gameObject.CompareTag("Do") && !Riding)
            {
                //my_Text.text = "Press E to Ride";
                if (Input.GetAxisRaw("Ride") == 1)
                {
                    Riding = true;
                    my_Text.text = "按F离开";
                    Debug.Log("RidingOnStory");
                    other.gameObject.transform.parent = gameObject.transform;
                    RidingOn = "Story";
                    gameObject.tag = "Do";
                    BeforeRide();
                    gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    StartCoroutine(BeforeRideOnStory());
                }
            }
            //Try to Enter InternetBar
            else if (other.gameObject.CompareTag("InternetBar") && gameObject.CompareTag("Player") && !Riding)
            {
                my_Text.text = "按E进入";
                if (Input.GetAxisRaw("Ride") == 1)
                {
                    Riding = true;
                    Debug.Log(Riding);
                    StartCoroutine(iwait());
                }
            }

            else if (other.gameObject.CompareTag("story") && !Riding)
            {
                my_Text.text = "按E查看";

            }
            
  
            //Ride On Old
            else if (other.gameObject.CompareTag("Old") && !Riding)
            {
                if (Input.GetAxisRaw("Ride") == 1)
                {
                    Riding = true;
                    my_Text.text = "按F离开";
                    Debug.Log("EEEEEEEEEEEEEEE");
                    gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    other.gameObject.transform.parent = gameObject.transform;
                    RidingOn = "Old";
                    gameObject.tag = "BigOld";
                    BeforeRide();
                    StartCoroutine(BeforeRideOnOld());
                }
            }
            else if (other.gameObject.CompareTag("Hurry") && gameObject.CompareTag("Ear") && !Riding)
            {
                if (Input.GetAxisRaw("Ride") == 1)
                {
                    Riding = true;
                    my_Text.text = "按F离开";
                    Debug.Log("EEEEEEEEEEEEEEE");
                    other.gameObject.transform.parent = gameObject.transform;
                    RidingOn = "Hurry";
                    gameObject.tag = "Invisible";
                    gameObject.GetComponent<SpriteRenderer>().sprite = invisible;
                    gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    GameObject.Find("Invisible").GetComponent<SpriteRenderer>().enabled = true;
                    other.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    other.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    GameObject.Find("Ear").GetComponent<SpriteRenderer>().enabled = false;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
        {
            my_Text.text = "";
        }
    
    IEnumerator iwait()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject.Find("Mother").GetComponentInChildren<Parents>().InternetBar = true;
        GameObject.Find("Father").GetComponentInChildren<Parents>().InternetBar = true;
    }
    
}
