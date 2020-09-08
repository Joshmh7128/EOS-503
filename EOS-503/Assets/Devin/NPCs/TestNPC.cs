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
                    
                }
                else if (num == 1)
                {

                }
                else if (num == 2)
                {
                    myTalk.NewTalk("Success_1_Start", "Success_1_End");
                }
                break;
            case "success1":
                if (num == 0)
                {
                    myTalk.NewTalk("Success_2_Start", "Success_2_End");
                }
                else if (num == 1)
                {

                }
                else if (num == 2)
                {
                    
                }
                break;
        }
    }
}
