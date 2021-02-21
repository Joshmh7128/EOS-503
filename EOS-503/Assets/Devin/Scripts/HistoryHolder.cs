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
    public Button thisButton;
    public Button prevButton;
    public Button nextButton;
    public int index = 0;
    public GameObject panel;

    private void Awake()
    {
        myTalk.myHistory = this;
        thisButton = this.GetComponent<Button>();
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
        thisButton.interactable = false;
        panel.SetActive(false);
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
        }
        else
        {
            StartCoroutine(ClosePanel());
        }
    }

    IEnumerator ClosePanel()
    {
        panel.GetComponent<Animator>().Play("historyClose");
        yield return new WaitForSeconds(0.25f);
        panel.SetActive(false);
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
