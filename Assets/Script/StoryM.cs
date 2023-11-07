using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class StoryM : Lines
{
    // Start is called before the first frame update
    public NPCConversation CHomework;
    private bool CHomeworkFlag = true;
    public NPCConversation CBook;
    private bool CBookFlag = true;
    public NPCConversation CPrize;
    private bool CPrizeFlag = true;
    public NPCConversation CTV;
    private bool CTVFlag = true;
    public NPCConversation CParents;
    private bool CParentsFlag = true;
    
    public ParticleSystem ps;
    void Start()
    {
        //ps.Play();
    }

    // Update is called once per frame
    void Update()
    {
        //ps.Play();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        var name = other.name;
        if (name == "TV" && CTVFlag)
        {
            ConversationManager.Instance.StartConversation(CTV);
            CTVFlag = false;
        }
        if (name == "Parents" && CParentsFlag)
        {
            ConversationManager.Instance.StartConversation(CParents);
            CParentsFlag = false;
        }
        
        
        
        if (other.CompareTag("story"))
        {
            //Debug.Log("hi");
            
            if (name == "storyquestion" && CHomeworkFlag)
            {
                ConversationManager.Instance.StartConversation(CHomework);
                CHomeworkFlag = false;
            }
            if (name == "storybook" && CBookFlag)
            {
                ConversationManager.Instance.StartConversation(CBook);
                CBookFlag = false;
            }
            if (name == "storyprize" && CPrizeFlag)
            {
                ConversationManager.Instance.StartConversation(CPrize);
                CPrizeFlag = false;
            }
            

            
            if (Input.GetAxisRaw("Ride") == 1)
            //if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("hi2");
                ps.gameObject.SetActive(true);
                ps.Play();

                
                if (name == "storyfamily")
                {
                    text1.text = line1;
                }
                if (name == "storyquestion")
                {
                    text2.text = line2;
                }
                if (name == "storybook")
                {
                    text3.text = line3;
                }
                if (name == "storyprize")
                {
                    text4.text = line4;
                }
            }
        }
        else
        {
            ps.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        ps.gameObject.SetActive(false);
    }
}
