using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Animations;

public class Argument01 : NPC
{
    private UnityEvent OnJostle;
    private UnityEvent OnFactionsEnter;
    private UnityEvent OnGabrielExit;
    private UnityEvent OnAtefehExit;
    private UnityEvent OnSolveyExit;
    private UnityEvent OnFactionsExit;
    private UnityEvent OnJanEnter;
    public Animator cutsceneAnim;

    private void Start()
    {
        OnJostle = new UnityEvent();
        OnFactionsEnter = new UnityEvent();
        OnGabrielExit = new UnityEvent();
        OnAtefehExit = new UnityEvent();
        OnSolveyExit = new UnityEvent();
        OnFactionsExit = new UnityEvent();
        OnJanEnter = new UnityEvent();
        OnJostle.AddListener(Jostle);
        OnFactionsEnter.AddListener(FactionsEnter);
        OnGabrielExit.AddListener(GabrielExit);
        OnAtefehExit.AddListener(AtefehExit);
        OnSolveyExit.AddListener(SolveyExit);
        OnFactionsExit.AddListener(FactionsExit);
        OnJanEnter.AddListener(JanEnter);
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
        myTalk.callback = OnJanEnter;
        StartCoroutine(DoFactionsExit());
    }

    public void JanEnter()
    {
        myTalk.callback = null;
        StartCoroutine(DoJanEnter());
    }

    IEnumerator EnterScene()
    {
        yield return new WaitForSeconds(2f);
        StartConversation();
    }

    IEnumerator DoJostle()
    {
        cutsceneAnim.Play("elevatorBrawl");
        yield return new WaitForSeconds(3f);
        myTalk.showPlayerPhoto = false;
        myTalk.NewTalk("blame-start", "blame-end");
    }

    IEnumerator DoFactionsEnter()
    {
        cutsceneAnim.Play("factionsArrive");
        yield return new WaitForSeconds(2f);
        myTalk.showPlayerPhoto = false;
        myTalk.NewTalk("gabriel-tch-start", "gabriel-tch-end");
    }

    IEnumerator DoGabrielExit()
    {
        cutsceneAnim.Play("gabrielExit");
        yield return new WaitForSeconds(1.5f);
        myTalk.NewTalk("atefeh-intro-start", "atefeh-intro-end");
    }

    IEnumerator DoAtefehExit()
    {
        cutsceneAnim.Play("atefehExit");
        yield return new WaitForSeconds(1.5f);
        myTalk.NewTalk("solvey-intro-start", "solvey-intro-end");
    }

    IEnumerator DoSolveyExit()
    {
        cutsceneAnim.Play("solveyExit");
        yield return new WaitForSeconds(1.5f);
        myTalk.showPlayerPhoto = false;
        myTalk.NewTalk("grumble-start", "grumble-end");
    }

    IEnumerator DoFactionsExit()
    {
        cutsceneAnim.Play("factionsDepart");
        yield return new WaitForSeconds(3f);
        myTalk.NewTalk("min-su-intro-start", "min-su-intro-end");
    }

    IEnumerator DoJanEnter()
    {
        cutsceneAnim.Play("janEnter");
        yield return new WaitForSeconds(1.5f);
        myTalk.NewTalk("jan-enter-start", "jan-enter-end");
    }
}
