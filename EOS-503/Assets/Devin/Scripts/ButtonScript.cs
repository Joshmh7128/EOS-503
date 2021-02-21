using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    private Animator anim;
    public Sprite[] buttonSprites;

    public HistoryHolder myHistory;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
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
