using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HistoryHolder : MonoBehaviour
{
    public RPGTalk myTalk;
    public List<HistoryElement> histories;
    public Text spokeText;
    public Text saidText;
    public Text counter;
    private Button thisButton;
    private Text thisText;
    public Button prevButton;
    public Button nextButton;
    public int index = 0;
    public GameObject panel;

    private void Awake()
    {
        myTalk.myHistory = this;
        thisButton = this.GetComponent<Button>();
        thisText = this.gameObject.transform.Find("Text").GetComponent<Text>();
        thisButton.onClick.AddListener(Toggle);
        prevButton.onClick.AddListener(Previous);
        nextButton.onClick.AddListener(Next);
    }

    private void Update()
    {
        if(panel.gameObject.activeInHierarchy && histories.Count > 0)
        {
            spokeText.text = histories[index].spoke;
            saidText.text = histories[index].said;

            int indexNum = index + 1;
            counter.text = indexNum.ToString() + " / " + histories.Count.ToString();

            if(index == 0)
            {
                prevButton.interactable = false;
            }
            else
            {
                prevButton.interactable = true;
            }
            if(index >= histories.Count - 1)
            {
                nextButton.interactable = false;
            }
            else
            {
                nextButton.interactable = true;
            }
        }
    }

    private void OnDisable()
    {
        histories = new List<HistoryElement>();
        panel.SetActive(false);
        thisText.text = "Show Conversation Log";
        index = 0;
    }

    public void Toggle()
    {
        if(histories.Count == 0)
        {
            return;
        }
        index = histories.Count - 1;
        if(!panel.activeInHierarchy)
        {
            panel.SetActive(true);
            thisText.text = "Hide Conversation Log";
        }
        else
        {
            panel.SetActive(false);
            thisText.text = "Show Conversation Log";
        }
    }

    public void Previous()
    {
        if(index < 1)
        {
            return;
        }
        index--;
    }

    public void Next()
    {
        if (index == histories.Count - 1)
        {
            return;
        }
        index++;
    }
}
