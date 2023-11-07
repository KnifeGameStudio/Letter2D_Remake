using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class ConversationM1 : MonoBehaviour
{
    public NPCConversation conv;
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
        yield return new WaitForSeconds(0.5f);
        ConversationManager.Instance.StartConversation(conv);
    }
}
