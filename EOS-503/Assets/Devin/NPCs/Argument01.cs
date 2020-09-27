using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Argument01 : NPC
{
    private UnityEvent OnJostle;
    private UnityEvent OnFactionsEnter;
    public GameObject jostleObj;
    public GameObject factionsObj;

    private void Start()
    {
        OnJostle = new UnityEvent();
        OnFactionsEnter = new UnityEvent();
        OnJostle.AddListener(Jostle);
        OnFactionsEnter.AddListener(FactionsEnter);
    }

    public override void StartConversation()
    {
        myTalk.txtToParse = myLines[0];
        myTalk.showPlayerPhoto = false;
        myTalk.callback = OnJostle;
        base.StartConversation();
    }

    public void Jostle()
    {
        myTalk.callback = OnFactionsEnter;
        StartCoroutine(DoJostle());
    }

    public void FactionsEnter()
    {
        myTalk.callback = null;
        StartCoroutine(DoFactionsEnter());
    }

    IEnumerator DoJostle()
    {
        jostleObj.SetActive(true);
        yield return new WaitForSeconds(3f);
        jostleObj.SetActive(false);
        myTalk.showPlayerPhoto = false;
        myTalk.NewTalk("blame-start", "blame-end");
    }

    IEnumerator DoFactionsEnter()
    {
        factionsObj.SetActive(true);
        yield return new WaitForSeconds(3f);
        factionsObj.SetActive(false);
        myTalk.showPlayerPhoto = false;
        myTalk.NewTalk("gabriel-tch-start", "gabriel-tch-end");
    }
}
