﻿using System.Collections;
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
        base.StartConversation();
        myTalk.NewTalk("xxx-start", "xxx-end");
    }

    public override void OnMadeChoice(string id, int num)
    {
        switch(id)
        {
            case "xxx":
                if(num == 0)
                {
                    myTalk.NewTalk("1xx-start", "1xx-end");
                }
                else if (num == 1)
                {
                    myTalk.NewTalk("0xx-a-start", "0xx-a-end");
                }
                else if (num == 2)
                {
                    myTalk.NewTalk("0xx-b-start", "0xx-b-end");
                }
                break;
            case "1xx":
                if (num == 0)
                {
                    myTalk.NewTalk("win-start", "win-end");
                }
                else if (num == 1)
                {
                    myTalk.NewTalk("10x-a-start", "10x-a-end");
                }
                else if (num == 2)
                {
                    myTalk.NewTalk("10x-b-start", "10x-b-end");
                }
                break;
            case "10x":
                if (num == 0)
                {
                    myTalk.NewTalk("win-start", "win-end");
                    EndConversation();
                }
                else
                {
                    myTalk.NewTalk("lose-start", "lose-end");
                    EndConversation();
                }
                break;
            case "0xx":
                if (num == 0)
                {
                    myTalk.NewTalk("01x-start", "01x-end");
                }
                else
                {
                    myTalk.NewTalk("lose-start", "lose-end");
                    EndConversation();
                }
                break;
            case "01x":
                if (num == 0)
                {
                    myTalk.NewTalk("win-start", "win-end");
                    EndConversation();
                }
                else
                {
                    myTalk.NewTalk("lose-start", "lose-end");
                    EndConversation();
                }
                break;
        }
    }
}
