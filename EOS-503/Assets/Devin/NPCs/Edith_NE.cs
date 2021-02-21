using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edith_NE : NPC
{
    private void Start()
    {
        myName = "Edith Rostad";
    }

    public override void StartConversation()
    {
        myTalk.txtToParse = myLines[0];
        base.StartConversation();
    }
}
