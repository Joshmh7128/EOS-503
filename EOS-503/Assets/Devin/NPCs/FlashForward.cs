using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashForward : NPC
{
    private void Start()
    {
        myName = "???";
    }

    public override void StartConversation()
    {
        myTalk.txtToParse = myLines[0];
        base.StartConversation();
    }
}
