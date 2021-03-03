using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ButtonScript : MonoBehaviour
{
    private Animator anim;
    public Sprite[] buttonSprites;
    public List<UnityEvent> myEvents;
    private Button myButton;
    public bool held = false;
    public float startTime;
    private float holdTime = 3f;

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
            Debug.Log("Holding button");
            if (Time.time - startTime > holdTime)
            {
                Debug.Log("Button Invoked");
                foreach (UnityEvent thisEvent in myEvents)
                {
                    thisEvent.Invoke();
                }
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
