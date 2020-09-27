using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Argument01 : NPC
{
    private UnityEvent OnJostle;
    private UnityEvent OnFactionsEnter;
    private UnityEvent OnGabrielExit;
    private UnityEvent OnAtefehExit;
    public GameObject jostleObj;
    public GameObject factionsObj;
    public GameObject gabrielExitObj;
    public GameObject atefehExitObj;

    private void Start()
    {
        OnJostle = new UnityEvent();
        OnFactionsEnter = new UnityEvent();
        OnGabrielExit = new UnityEvent();
        OnAtefehExit = new UnityEvent();
        OnJostle.AddListener(Jostle);
        OnFactionsEnter.AddListener(FactionsEnter);
        OnGabrielExit.AddListener(GabrielExit);
        OnAtefehExit.AddListener(AtefehExit);
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
        myTalk.callback = OnAtefehExit;
        StartCoroutine(DoGabrielExit());
    }

    public void AtefehExit()
    {
        myTalk.callback = null;
        StartCoroutine(DoAtefehExit());
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
        gabrielExitObj.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        gabrielExitObj.SetActive(false);
        myTalk.NewTalk("atefeh-intro-start", "atefeh-intro-end");
    }

    IEnumerator DoAtefehExit()
    {
        atefehExitObj.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        atefehExitObj.SetActive(false);
        myTalk.NewTalk("solvey-intro-start", "solvey-intro-end");
    }
}
