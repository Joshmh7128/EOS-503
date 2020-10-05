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
    private UnityEvent OnJanTutorial;
    private UnityEvent OnJanExit;
    private UnityEvent OnHamadiEnter;
    private UnityEvent OnHamadiExit;
    private UnityEvent OnMinSuExit;
    public Animator cutsceneAnim;
    public Jan_Tutorial myJan;
    public Hamadi_VS myHamadi;

    private void Start()
    {
        OnJostle = new UnityEvent();
        OnFactionsEnter = new UnityEvent();
        OnGabrielExit = new UnityEvent();
        OnAtefehExit = new UnityEvent();
        OnSolveyExit = new UnityEvent();
        OnFactionsExit = new UnityEvent();
        OnJanEnter = new UnityEvent();
        OnJanTutorial = new UnityEvent();
        OnJanExit = new UnityEvent();
        OnHamadiEnter = new UnityEvent();
        OnHamadiExit = new UnityEvent();
        OnMinSuExit = new UnityEvent();
        OnJostle.AddListener(Jostle);
        OnFactionsEnter.AddListener(FactionsEnter);
        OnGabrielExit.AddListener(GabrielExit);
        OnAtefehExit.AddListener(AtefehExit);
        OnSolveyExit.AddListener(SolveyExit);
        OnFactionsExit.AddListener(FactionsExit);
        OnJanEnter.AddListener(JanEnter);
        OnJanTutorial.AddListener(JanTutorial);
        OnJanExit.AddListener(JanExit);
        OnHamadiEnter.AddListener(HamadiEnter);
        OnHamadiExit.AddListener(HamadiExit);
        OnMinSuExit.AddListener(MinSuExit);
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
        myTalk.callback = OnJanTutorial;
        StartCoroutine(DoJanEnter());
    }

    public void JanTutorial()
    {
        myTalk.callback = OnJanExit;
        myJan.StartConversation();
    }

    public void JanExit()
    {
        myTalk.callback = OnHamadiEnter;
        myTalk.OnEndAnimating -= myJan.OnEndAnimating;
        StartCoroutine(DoJanExit());
    }

    public void HamadiEnter()
    {
        myTalk.callback = OnHamadiExit;
        StartCoroutine(DoHamadiEnter());
    }

    public void HamadiExit()
    {
        myTalk.callback = OnMinSuExit;
        StartCoroutine(DoHamadiExit());
    }

    public void MinSuExit()
    {
        myTalk.callback = null;
        StartCoroutine(DoMinSuExit());
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
        yield return new WaitForSeconds(2.5f);
        myTalk.NewTalk("min-su-intro-start", "min-su-intro-end");
    }

    IEnumerator DoJanEnter()
    {
        cutsceneAnim.Play("janEnter");
        yield return new WaitForSeconds(1.5f);
        myTalk.NewTalk("jan-enter-start", "jan-enter-end");
    }

    IEnumerator DoJanExit()
    {
        cutsceneAnim.Play("janExit");
        yield return new WaitForSeconds(1.5f);
        myTalk.txtToParse = myLines[0];
        myTalk.NewTalk("jan-exit-start", "jan-exit-end");
    }

    IEnumerator DoHamadiEnter()
    {
        cutsceneAnim.Play("hamadiEnter");
        yield return new WaitForSeconds(1.5f);
        myHamadi.StartConversation();
    }

    IEnumerator DoHamadiExit()
    {
        cutsceneAnim.Play("hamadiExit");
        yield return new WaitForSeconds(1.5f);
        myTalk.txtToParse = myLines[0];
        myTalk.NewTalk("hamadi-exit-start", "hamadi-exit-end");
    }

    IEnumerator DoMinSuExit()
    {
        cutsceneAnim.Play("minSuExit");
        yield return new WaitForSeconds(1.5f);
        cutsceneAnim.gameObject.SetActive(false);
        //return control to player
    }
}
