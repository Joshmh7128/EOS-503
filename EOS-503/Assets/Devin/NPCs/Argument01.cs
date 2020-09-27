using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Argument01 : NPC
{
    private UnityEvent OnJostle;
    private UnityEvent OnFactionsEnter;
    private UnityEvent OnGabrielExit;
    public GameObject jostleObj;
    public GameObject factionsObj;
    public GameObject gabrielObj;

    private void Start()
    {
        OnJostle = new UnityEvent();
        OnFactionsEnter = new UnityEvent();
        OnGabrielExit = new UnityEvent();
        OnJostle.AddListener(Jostle);
        OnFactionsEnter.AddListener(FactionsEnter);
        OnGabrielExit.AddListener(GabrielExit);
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
        myTalk.callback = OnGabrielExit;
        StartCoroutine(DoFactionsEnter());
    }

    public void GabrielExit()
    {
        myTalk.callback = null;
        StartCoroutine(DoGabrielExit());
    }

    IEnumerator DoJostle()
    {
        jostleObj.SetActive(true);
        yield return new WaitForSeconds(2f);
        jostleObj.SetActive(false);
        myTalk.showPlayerPhoto = false;
        myTalk.NewTalk("blame-start", "blame-end");
    }

    IEnumerator DoFactionsEnter()
    {
        factionsObj.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        factionsObj.SetActive(false);
        myTalk.showPlayerPhoto = false;
        myTalk.NewTalk("gabriel-tch-start", "gabriel-tch-end");
    }

    IEnumerator DoGabrielExit()
    {
        gabrielObj.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        gabrielObj.SetActive(false);
        myTalk.NewTalk("atefeh-intro-start", "atefeh-intro-end");
    }
}
