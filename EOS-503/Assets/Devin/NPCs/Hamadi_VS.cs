using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hamadi_VS : NPC
{
    private void Start()
    {
        myName = "Hamadi Mohammed Ahmed";
    }

    public override void StartConversation()
    {
        myTalk.txtToParse = myLines[0];
        base.StartConversation();
    }
}
