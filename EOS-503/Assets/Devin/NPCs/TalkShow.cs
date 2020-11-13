using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkShow : NPC
{
    private void Start()
    {
        myName = "???";
    }

    public override void StartConversation()
    {
        myTalk.txtToParse = myLines[0];
        myTalk.showPlayerPhoto = false;
        base.StartConversation();
    }

    public override void OnMadeChoice(string id, int num)
    {
        switch(id)
        {
            case "continue":

                break;
        }
    }
}
