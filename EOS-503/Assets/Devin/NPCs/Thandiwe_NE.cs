using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thandiwe_NE : NPC
{
    private void Start()
    {
        myName = "Thandiwe Buhle";
    }

    public override void StartConversation()
    {
        myTalk.txtToParse = myLines[0];
        base.StartConversation();
    }
}
