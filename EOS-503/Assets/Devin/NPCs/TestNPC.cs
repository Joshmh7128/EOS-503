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
                    myTalk.NewTalk("fail-a_Start", "fail-a_End");
                    myTalk.PlayerPhoto.sprite = myTalk.sprites[2].sprite;
                }
                else if (num == 1)
                {
                    myTalk.NewTalk("fail-b_Start", "fail-b_End");
                    myTalk.PlayerPhoto.sprite = myTalk.sprites[2].sprite;
                }
                else if (num == 2)
                {
                    myTalk.NewTalk("success_Start", "success_End");
                    myTalk.PlayerPhoto.sprite = myTalk.sprites[1].sprite;
                }
                break;
            case "success":
                if (num == 0)
                {
                    myTalk.NewTalk("success-success_Start", "success-success_End");
                    myTalk.PlayerPhoto.sprite = myTalk.sprites[1].sprite;
                }
                else if (num == 1)
                {
                    myTalk.NewTalk("success-fail-a_Start", "success-fail-a_End");
                    myTalk.PlayerPhoto.sprite = myTalk.sprites[2].sprite;
                }
                else if (num == 2)
                {
                    myTalk.NewTalk("success-fail-b_Start", "success-fail-b_End");
                    myTalk.PlayerPhoto.sprite = myTalk.sprites[2].sprite;
                }
                break;
            case "fail":
                if (num == 0)
                {
                    myTalk.NewTalk("fail-success_Start", "fail-success_End");
                    myTalk.PlayerPhoto.sprite = myTalk.sprites[1].sprite;
                }
                else if (num == 1)
                {
                    myTalk.NewTalk("fail-fail_Start", "fail-fail_End");
                    myTalk.PlayerPhoto.sprite = myTalk.sprites[2].sprite;
                }
                else if (num == 2)
                {
                    myTalk.NewTalk("fail-fail_Start", "fail-fail_End");
                    myTalk.PlayerPhoto.sprite = myTalk.sprites[2].sprite;
                }
                break;
            case "success-fail":
                if (num == 0)
                {
                    myTalk.NewTalk("success-success_Start", "success-success_End");
                    myTalk.PlayerPhoto.sprite = myTalk.sprites[1].sprite;
                }
                else if (num == 1)
                {
                    myTalk.NewTalk("fail-fail_Start", "fail-fail_End");
                    myTalk.PlayerPhoto.sprite = myTalk.sprites[2].sprite;
                }
                else if (num == 2)
                {
                    myTalk.NewTalk("fail-fail_Start", "fail-fail_End");
                    myTalk.PlayerPhoto.sprite = myTalk.sprites[2].sprite;
                }
                break;
        }
    }
}
