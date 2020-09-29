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
    private UnityEvent OnSolveyExit;
    private UnityEvent OnFactionsExit;
    public GameObject jostleObj;
    public GameObject factionsEnterObj;
    public GameObject gabrielExitObj;
    public GameObject atefehExitObj;
    public GameObject solveyExitObj;
    public GameObject factionsExitObj;

    private void Start()
    {
        OnJostle = new UnityEvent();
        OnFactionsEnter = new UnityEvent();
        OnGabrielExit = new UnityEvent();
        OnAtefehExit = new UnityEvent();
        OnSolveyExit = new UnityEvent();
        OnFactionsExit = new UnityEvent();
        OnJostle.AddListener(Jostle);
        OnFactionsEnter.AddListener(FactionsEnter);
        OnGabrielExit.AddListener(GabrielExit);
        OnAtefehExit.AddListener(AtefehExit);
        OnSolveyExit.AddListener(SolveyExit);
        OnFactionsExit.AddListener(FactionsExit);
        StartCoroutine(EnterScene());
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
        myTalk.callback = OnSolveyExit;
        StartCoroutine(DoAtefehExit());
    }

    public void SolveyExit()
    {
        myTalk.callback = OnFactionsExit;
        StartCoroutine(DoSolveyExit());
    }

    public void FactionsExit()
    {
        myTalk.callback = null;
        StartCoroutine(DoFactionsExit());
    }

    IEnumerator EnterScene()
    {
        yield return new WaitForSeconds(2f);
        StartConversation();
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
        factionsEnterObj.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        factionsEnterObj.SetActive(false);
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

    IEnumerator DoSolveyExit()
    {
        solveyExitObj.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        solveyExitObj.SetActive(false);
        myTalk.showPlayerPhoto = false;
        myTalk.NewTalk("grumble-start", "grumble-end");
    }

    IEnumerator DoFactionsExit()
    {
        factionsExitObj.SetActive(true);
        yield return new WaitForSeconds(2f);
        factionsExitObj.SetActive(false);
        myTalk.NewTalk("min-su-intro-start", "min-su-intro-end");
    }
}
