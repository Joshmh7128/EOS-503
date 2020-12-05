using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stephen_NE : NPC
{
    private void Start()
    {
        myName = "Stephen Spencer";
    }

    public override void StartConversation()
    {
        myTalk.txtToParse = myLines[0];
        base.StartConversation();
    }
}
