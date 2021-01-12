using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedro_NE : NPC
{
    private void Start()
    {
        myName = "Pedro Reis Vidal";
    }

    public override void StartConversation()
    {
        myTalk.txtToParse = myLines[0];
        base.StartConversation();
    }
}
