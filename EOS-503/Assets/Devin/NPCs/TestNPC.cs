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
                    myTalk.NewTalk("faila_Start", "faila_End");
                }
                else if (num == 1)
                {
                    myTalk.NewTalk("failb_Start", "failb_End");
                }
                else if (num == 2)
                {
                    myTalk.NewTalk("success_Start", "success_End");
                }
                break;
            case "success":
                if (num == 0)
                {
                    myTalk.NewTalk("success-success_Start", "success-success_End");
                }
                else if (num == 1)
                {
                    myTalk.NewTalk("success-fail-a_Start", "success-fail-a_End");
                }
                else if (num == 2)
                {
                    myTalk.NewTalk("success-failf-b_Start", "success-failf-b_End");
                }
                break;
            case "fail":
                if (num == 0)
                {
                    myTalk.NewTalk("fail-success_Start", "fail-success_End");
                }
                else if (num == 1)
                {
                    myTalk.NewTalk("fail-fail_Start", "fail-fail_End");
                }
                else if (num == 2)
                {
                    myTalk.NewTalk("fail-fail_Start", "fail-fail_End");
                }
                break;
            case "success-fail":
                if (num == 0)
                {
                    myTalk.NewTalk("success-success_Start", "success-success_End");
                }
                else if (num == 1)
                {
                    myTalk.NewTalk("fail-fail_Start", "fail-fail_End");
                }
                else if (num == 2)
                {
                    myTalk.NewTalk("fail-fail_Start", "fail-fail_End");
                }
                break;
        }
    }
}
