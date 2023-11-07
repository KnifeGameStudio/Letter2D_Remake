using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip Hit1;
    public static AudioClip onHit1;
    public static AudioSource audioSrc;
    public static AudioClip Box_Break;
    public static AudioClip Door;
    public static AudioClip Lock;
    public static AudioClip Write;
    public static AudioClip Bigger;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        onHit1 = Resources.Load<AudioClip>("Attack_Sound1");
        Hit1 = Resources.Load<AudioClip>("Attack_Sound2");
        Box_Break = Resources.Load<AudioClip>("Box_Break");
        Door = Resources.Load<AudioClip>("Door");
        Bigger = Resources.Load<AudioClip>("Bigger");
        Lock = Resources.Load<AudioClip>("Lock");
        Write = Resources.Load<AudioClip>("Write");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlayAttackSound1()
    {
        audioSrc.PlayOneShot(Hit1);
    }
    public static void PlayAttackedSound1()
    {
        audioSrc.PlayOneShot(onHit1);
    }

    public static void PlayBoxBreakSound()
    {
        audioSrc.PlayOneShot(Box_Break);
    }

    public static void PlayDoorSound()
    {
        audioSrc.PlayOneShot(Door);
    }

    public static void PlayLockSound()
    {
        audioSrc.PlayOneShot(Lock);
    }

    public static void PlayBiggerSound()
    {
        audioSrc.PlayOneShot(Bigger);
    }

    public static void PlayWriteSound()
    {
        audioSrc.PlayOneShot(Write);
    }
}
