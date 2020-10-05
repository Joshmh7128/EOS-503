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
                }
                else
                {
                    myTalk.NewTalk("lose-start", "lose-end");
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
                }
                break;
            case "01x":
                if (num == 0)
                {
                    myTalk.NewTalk("win-start", "win-end");
                }
                else
                {
                    myTalk.NewTalk("lose-start", "lose-end");
                }
                break;
        }
    }
}
