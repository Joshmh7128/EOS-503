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
                if (num == 0)
                {
                    myTalk.NewTalk("continued-start", "continued-end");
                }
                else if (num == 1)
                {
                    //route to character creation
                }
                break;
        }
    }
}
