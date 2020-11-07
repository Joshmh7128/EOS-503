﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashForward : NPC
{
    private void Start()
    {
        myName = "???";
    }

    public override void StartConversation()
    {
        myTalk.txtToParse = myLines[0];
        myTalk.OnEndAnimating += OnEndAnimating;
        base.StartConversation();
    }

    public void OnEndAnimating()
    {
        if (myTalk.rpgtalkElements[myTalk.cutscenePosition - 1].dialogText == "Thank you. That will end our inquiry.")
        {
            myTalk.PlayerPhoto.enabled = false;
            myTalk.showPlayerPhoto = false;
        }
    }
}
