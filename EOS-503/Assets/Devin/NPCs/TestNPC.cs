using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestNPC : NPC
{
    private void Start()
    {
        myName = "TestNPC";
        myTalk.OnMadeChoice += OnMadeChoice;
    }

    public override void StartConversation()
    {
        myTalk.OnMadeChoice += OnMadeChoice; //!!!remember to clear this when ending a conversation!!!
        base.StartConversation();
    }

    public void OnMadeChoice(string id, int num)
    {
        switch(id)
        {
            case "init":
                if(num == 0)
                {
                    myTalk.NewTalk("0-1a_Start", "0-1a_End");
                }
                else if (num == 1)
                {
                    myTalk.NewTalk("0-1b_Start", "0-1b_End");
                }
                else if (num == 2)
                {
                    myTalk.NewTalk("1-0_Start", "1-0_End");
                }
                break;
            case "1-0":
                if (num == 0)
                {
                    myTalk.NewTalk("2-0_Start", "2-0_End");
                }
                else if (num == 1)
                {
                    myTalk.NewTalk("1-1f-a_Start", "1-1f-a_End");
                }
                else if (num == 2)
                {
                    myTalk.NewTalk("1-1f-b_Start", "1-1f-b_End");
                }
                break;
            case "0-1":
                if (num == 0)
                {
                    
                }
                else if (num == 1)
                {
                    myTalk.NewTalk("0-2_Start", "0-2_End");
                }
                else if (num == 2)
                {
                    myTalk.NewTalk("0-2_Start", "0-2_End");
                }
                break;
        }
    }
}
