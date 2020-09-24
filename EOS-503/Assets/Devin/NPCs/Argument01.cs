using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Argument01 : NPC
{
    public override void StartConversation()
    {
        myTalk.txtToParse = myLines[0];
        myTalk.showPlayerPhoto = false;
        base.StartConversation();
    }
}
