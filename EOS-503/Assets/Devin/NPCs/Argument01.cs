using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Argument01 : NPC
{
    public UnityEvent OnJostle;
    public GameObject jostleObj;

    public override void StartConversation()
    {
        myTalk.txtToParse = myLines[0];
        myTalk.showPlayerPhoto = false;
        myTalk.callback = OnJostle;
        base.StartConversation();
    }

    public void Jostle()
    {
        myTalk.callback = null;
        StartCoroutine(DoJostle());
    }

    IEnumerator DoJostle()
    {
        jostleObj.SetActive(true);
        yield return new WaitForSeconds(3f);
        jostleObj.SetActive(false);
        myTalk.NewTalk("blame-start", "blame-end");
    }
}
