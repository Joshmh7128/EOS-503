using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lisa_NE : NPC
{
    private void Start()
    {
        myName = "Lisa Ristova";
    }

    public override void StartConversation()
    {
        myTalk.txtToParse = myLines[0];
        base.StartConversation();
    }
}
