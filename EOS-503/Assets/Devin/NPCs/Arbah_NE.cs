using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arbah_NE : NPC
{
    private void Start()
    {
        myName = "Arbah Omuga";
    }

    public override void StartConversation()
    {
        myTalk.txtToParse = myLines[0];
        base.StartConversation();
    }
}
