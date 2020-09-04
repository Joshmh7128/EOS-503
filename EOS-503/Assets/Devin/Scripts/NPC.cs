using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public string myName;
    public RPGTalk myTalk;
    public TextAsset myLines;

    public void StartConversation()
    {
        myTalk.speakerName = myName;
        myTalk.txtToParse = myLines;
        myTalk.NewTalk("helloStart", "helloEnd");
    }
}
