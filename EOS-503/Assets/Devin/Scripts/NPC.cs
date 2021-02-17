using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public string myName;
    public RPGTalk myTalk;
    public TextAsset[] myLines;

    public virtual void StartConversation()
    {
        myTalk.speaker = myName;
        myTalk.currentNPC = this;
        myTalk.NewTalk("hello-start", "hello-end");
    }

    public virtual void OnMadeChoice(string id, int num)
    {
        switch (id)
        {
            case "xxx":
                if (num == 0)
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
                    myTalk.buttonDisabled = -1;
                    if (num == 1)
                    {
                        myTalk.NewTalk("100-a-start", "100-a-end");
                    }
                    else if (num == 2)
                    {
                        myTalk.NewTalk("100-b-start", "100-b-end");
                    }
                }
                break;
            case "0xx":
                if (num == 0)
                {
                    myTalk.NewTalk("01x-start", "01x-end");
                }
                else
                {
                    myTalk.buttonDisabled = -1;
                    if (num == 1)
                    {
                        myTalk.NewTalk("00x-a-start", "00x-a-end");
                    }
                    else if (num == 2)
                    {
                        myTalk.NewTalk("00x-b-start", "00x-b-end");
                    }
                }
                break;
            case "01x":
                if (num == 0)
                {
                    myTalk.NewTalk("win-start", "win-end");
                }
                else
                {
                    myTalk.buttonDisabled = -1;
                    if (num == 1)
                    {
                        myTalk.NewTalk("010-a-start", "010-a-end");
                    }
                    else if (num == 2)
                    {
                        myTalk.NewTalk("010-b-start", "010-b-end");
                    }
                }
                break;
        }
    }
}
