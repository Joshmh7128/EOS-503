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
        base.StartConversation();
        myTalk.NewTalk("xxx-start", "xxx-end");
    }

    public override void OnMadeChoice(string id, int num)
    {
        switch(id)
        {
            case "xxx":
            break;
        }
    }
}
