using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jan_Tutorial : NPC
{
    public GameObject tutorialPopup;
    private Text tutorialText;
    private Button tutorialButton;

    private void Start()
    {
        tutorialText = tutorialPopup.transform.Find("Body").GetComponent<Text>();
        tutorialButton = tutorialPopup.transform.Find("Close").GetComponent<Button>();
        tutorialButton.onClick.AddListener(CloseTutorial);

        myName = "Jan Hurwicz";
        StartCoroutine(TestStart());
    }

    IEnumerator TestStart()
    {
        yield return new WaitForSeconds(0.1f);
        StartConversation();
    }

    public void OpenTutorial(string tutText)
    {
        tutorialText.text = tutText;
        tutorialPopup.SetActive(true);
        myTalk.enablePass = false;
    }

    public void CloseTutorial()
    {
        tutorialPopup.SetActive(false);
        myTalk.enablePass = true;
    }

    public override void StartConversation()
    {
        myTalk.txtToParse = myLines[0];
        myTalk.OnEndAnimating += OnEndAnimating; ///remember to clear on conversation end!
        base.StartConversation();
    }

    public void OnEndAnimating()
    {
        if(myTalk.rpgtalkElements[myTalk.cutscenePosition - 1].dialogText == "Perhaps no one thought to tell you, 'fixer', but about a year ago, trade between the cities turned sour. Being a clever businessman, I staved off the worst outcomes for myself, but I need new patrons to keep products moving or my business will fail.")
        {
            //NE intro tutorial popup
            OpenTutorial("When residents and their communities face problems in Commune 503, it's up to skilled DATA agents to lend their expertise! \n \nCarefully listen to what your conversation partner tells you and figure out their perspective from their word choice and behaviors—that way, you can suggest solutions befitting them. Because residents’ worldviews correspond to different theories of learning, your goal is to recognize when and how particular learning theories map to a particular residents’ understanding of the world around them.");
        }
        else if (myTalk.rpgtalkElements[myTalk.cutscenePosition - 1].dialogText == "And now you, from the High Council, you have come down to help? I have been around long enough to not trust in a savior to solve my troubles. What say you to that, esteemed DATA Agent? Hm?")
        {
            //first choice tutorial popup
        }
        else if (myTalk.rpgtalkElements[myTalk.cutscenePosition - 1].dialogText == "My mind is like a steel trap, but even with all of my memories to rely on, I am still stuck. I have been around long enough to not trust in a savior to solve my troubles. What say you to that, esteemed DATA Agent? Hm?")
        {
            //second choice tutorial popup
        }
        else if (myTalk.rpgtalkElements[myTalk.cutscenePosition - 1].dialogText == "This... is not a terrible idea, and fits with my memories. Maybe I am being too harsh in my judgment...? Hmmmm. ")
        {
            //win state tutorial popup
        }
        else if (myTalk.rpgtalkElements[myTalk.cutscenePosition - 1].dialogText == "Hmph, this is all you can think of to help me?")
        {
            //lose state tutorial popup
        }
        else if (myTalk.rpgtalkElements[myTalk.cutscenePosition - 1].dialogText == "[Let's run through that one more time...]")
        {
            myTalk.buttonDisabled = -1;
        }
    }

    public override void OnMadeChoice(string id, int num)
    {
        switch (id)
        {
            case "xxx":
                if (num == 0)
                {
                    myTalk.NewTalk("1xx-start", "1xx-end");
                }
                else if (num == 1)
                {
                    myTalk.NewTalk("0xx-a-start", "0xx-a-end");
                }
                else if (num == 2)
                {
                    myTalk.NewTalk("0xx-b-start", "0xx-b-end");
                }
                break;
            case "1xx":
                if (num == 0)
                {
                    myTalk.NewTalk("win-start", "win-end");
                }
                else if (num == 1)
                {
                    myTalk.NewTalk("10x-a-start", "10x-a-end");
                }
                else if (num == 2)
                {
                    myTalk.NewTalk("10x-b-start", "10x-b-end");
                }
                break;
            case "10x":
                if (num == 0)
                {
                    myTalk.NewTalk("win-start", "win-end");
                }
                else
                {
                    myTalk.NewTalk("lose-start", "lose-end");
                }
                break;
            case "0xx":
                if (num == 0)
                {
                    myTalk.NewTalk("01x-start", "01x-end");
                }
                else
                {
                    myTalk.NewTalk("lose-start", "lose-end");
                }
                break;
            case "01x":
                if (num == 0)
                {
                    myTalk.NewTalk("win-start", "win-end");
                }
                else
                {
                    myTalk.NewTalk("lose-start", "lose-end");
                }
                break;
        }
    }
}
