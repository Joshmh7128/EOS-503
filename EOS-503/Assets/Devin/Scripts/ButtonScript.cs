using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ButtonScript : MonoBehaviour
{
    private Animator anim;
    public Sprite[] buttonSprites;
    public Image myOutline;
    public List<UnityEvent> myEvents;
    private Button myButton;
    public bool held = false;
    public float startTime;
    private float holdTime = 1f;

    public HistoryHolder myHistory;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        myButton = this.GetComponent<Button>();
        UnityEvent newEvent = new UnityEvent();
        newEvent.AddListener(LogChoice);
        myEvents.Add(newEvent);
    }

    private void Update()
    {
        if(held && myButton.interactable)
        {
            myOutline.fillAmount = 1 * ((Time.time - startTime) / holdTime);
            if (Time.time - startTime > holdTime)
            {
                myOutline.fillAmount = 1;
                StartCoroutine(DoButton());
            }
        }
    }

    public void StartHold()
    {
        held = true;
        startTime = Time.time;
    }

    public void EndHold()
    {
        held = false;
        myOutline.fillAmount = 0;
    }

    IEnumerator DoButton()
    {
        yield return new WaitForSeconds(0.1f);
        foreach (UnityEvent thisEvent in myEvents)
        {
            thisEvent.Invoke();
        }
    }

    public void LogChoice()
    {
        HistoryElement myItem = new HistoryElement("Your response:", transform.Find("Text").GetComponent<Text>().text);
        myHistory.histories.Add(myItem);
    }

    public void Expand()
    {
        if(this.GetComponent<Button>().interactable)
        {
            anim.Play("buttonExpand");
        }
    }

    public void Contract()
    {
        if (this.GetComponent<Button>().interactable)
        {
            anim.Play("buttonCollapse");
        }
    }
}
