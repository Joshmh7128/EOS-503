using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public string myName;
    public RPGTalk myTalk;
    public TextAsset[] myLines;

    public virtual void StartConversation()
    {
        myTalk.speaker = myName;
        myTalk.currentNPC = this;
        myTalk.NewTalk("hello-start", "hello-end");
    }

    public virtual void OnMadeChoice(string id, int num)
    {
        
    }
}
