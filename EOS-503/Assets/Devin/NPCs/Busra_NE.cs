using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Busra_NE : NPC
{
    private void Start()
    {
        myName = "Busra Unal";
    }

    public override void StartConversation()
    {
        myTalk.txtToParse = myLines[0];
        base.StartConversation();
    }
}
