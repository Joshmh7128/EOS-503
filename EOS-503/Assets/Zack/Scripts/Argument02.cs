using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Animations;

public class Argument02 : NPC
{
    private UnityEvent OnJostle;
    private UnityEvent OnMinSuExit;
    public Animator cutsceneAnim;
    public Jan_Tutorial myJan;
    public Hamadi_VS myHamadi;
    public GameObject myPlayer;
    public GameObject cutsceneCamera;
    public GameObject damage;

    private void Start()
    {
        OnJostle = new UnityEvent();
        OnMinSuExit = new UnityEvent();
        OnJostle.AddListener(Jostle);
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
        // myTalk.callback = OnFactionsEnter;
        myTalk.callback = OnMinSuExit;
        StartCoroutine(DoJostle());
    }

    public void MinSuExit()
    {
        myTalk.callback = null;
        StartCoroutine(DoMinSuExit());
    }

    IEnumerator EnterScene()
    {
        yield return new WaitForSeconds(0f);
        StartConversation();
    }

    IEnumerator DoJostle()
    {
        yield return new WaitForSeconds(0f);
        damage.SetActive(true);
        myTalk.showPlayerPhoto = false;
        myTalk.NewTalk("hamadi-exit-start", "hamadi-exit-end");
    }

    IEnumerator DoMinSuExit()
    {
        yield return new WaitForSeconds(0f);
        cutsceneCamera.GetComponent<Animator>().Play("cutsceneEnd");
        yield return new WaitForSeconds(0f);
        cutsceneAnim.gameObject.SetActive(false);
        cutsceneCamera.SetActive(false);
        myPlayer.SetActive(true);
        //return control to player
    }
}
