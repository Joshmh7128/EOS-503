using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public string myName;
    public RPGTalk myTalk;
    public TextAsset myLines;

    public virtual void StartConversation()
    {
        myTalk.speaker = myName;
        myTalk.txtToParse = myLines;
        myTalk.OnMadeChoice += OnMadeChoice; //!!!remember to clear this when ending a conversation!!
    }

    public virtual void EndConversation()
    {
        myTalk.OnMadeChoice -= OnMadeChoice;
    }

    public virtual void OnMadeChoice(string id, int num)
    {
        
    }
}
