using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shiraishi_NE : NPC
{
    private void Start()
    {
        myName = "Shiraishi Yumi";
    }

    public override void StartConversation()
    {
        myTalk.txtToParse = myLines[0];
        base.StartConversation();
    }
}
