using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charvi_NE : NPC
{
    private void Start()
    {
        myName = "Charvi Shome";
    }

    public override void StartConversation()
    {
        myTalk.txtToParse = myLines[0];
        base.StartConversation();
    }
}
