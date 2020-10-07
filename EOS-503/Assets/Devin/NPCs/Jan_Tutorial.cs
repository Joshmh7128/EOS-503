using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jan_Tutorial : NPC
{
    public GameObject tutorialPopup;
    private Text tutorialText;
    private Button tutorialButton;
    private string chosenChoice;

    private void Start()
    {
        tutorialText = tutorialPopup.transform.Find("Body").GetComponent<Text>();
        tutorialButton = tutorialPopup.transform.Find("Close").GetComponent<Button>();
        tutorialButton.onClick.AddListener(CloseTutorial);

        myName = "Jan Hurwicz";
    }

    public void OpenTutorial(string tutText)
    {
        tutorialText.text = tutText;
        tutorialPopup.SetActive(true);
        myTalk.passWithMouse = false;
    }

    public void CloseTutorial()
    {
        tutorialPopup.SetActive(false);
        myTalk.passWithMouse = true;
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
            OpenTutorial("As you can see, there are a few different ways to respond to the person you’re talking to. Hovering over each of the three options will allow you to see the full text of your response. Feel free to review the conversation history to determine your conversation partner’s theoretical worldview. \n \nLet’s see if Jan can be enticed by a Behavioral response like the idea of a customer rewards system.");
            chosenChoice = "Create Customer Reward Systems";
            StartCoroutine(HighlightChoice());
        }
        else if (myTalk.rpgtalkElements[myTalk.cutscenePosition - 1].dialogText == "My mind is like a steel trap, but even with all of my memories to rely on, I am still stuck. I have been around long enough to not trust in a savior to solve my troubles. What say you to that, esteemed DATA Agent? Hm?")
        {
            //second choice tutorial popup
            OpenTutorial("When your response does not match your conversation partner’s preferred theoretical worldview, your conversation partner will speak and behave more dismissively. The first time this happens, you will have the opportunity to change their mind with a more compelling response. However for most residents, if your second response fails to impress them, they will end the conversation and you will be given a chance to restart the conversation with additional information about the resident’s theoretical worldview and the learning theories embedded in each response option. \n\nThis changes when talking with governors and community leaders, as they are more forgiving of ideas that do not match their world view. During these conversations you will often be provided at least one more chance to try and solve their problem. However if you fail to solve their problem, you will not be able to try again, and must bear the consequences. But, back to the conversation at hand. \n\nJan indicated that he has a “mind like a steel trap” and “memories to rely on”—perhaps he would be more open to an Information Processing Theory response focused on people and events from his past.");
            chosenChoice = "Turn Memories into Leads";
            StartCoroutine(HighlightChoice());
        }
        else if (myTalk.rpgtalkElements[myTalk.cutscenePosition - 1].dialogText == "Oh ho, a bold assertion!")
        {
            //correct choice tutorial popup
            OpenTutorial("When a conversation partner approves of your response, they will often seek further clarification and guidance, giving you an opportunity to respond to new questions, concerns, and quippy remarks. You need to continue providing help and guidance until you either succeed or fail in helping the resident. \n\nMost residents will work with you after successfully communicating with them twice, however governors and community leaders may need a little more convincing. Similarly as mentioned before, residents are quick to end conversations they find unproductive, while governors and community leaders are more tolerant of your miscommunication. From here on it will be up to you to identify the worldview of the resident, and align your response to their view!");
        }
        else if (myTalk.rpgtalkElements[myTalk.cutscenePosition - 1].dialogText == "This... is not a terrible idea, and fits with my memories. Maybe I am being too harsh in my judgment...? Hmmmm.")
        {
            //win state tutorial popup
            OpenTutorial("Good job convincing Jan! One last thing you should know about your interactions with residents! If you succeed in convincing them to work with you, then you will gain Influence with the residents faction. \n\nYou'll be free to select whichever responses you like, but the quality of your response matters for the Influence gained. The more receptive your conversation partner is to your argument, the stronger your bond will become and the more Influence you'll have with their faction in the future. Your Influence will be utilized primarily in the second part of the game, though there may be a few opportunities to use this system in the first part of the game. From here you should know everything necessary to complete your work!");
        }
        else if (myTalk.rpgtalkElements[myTalk.cutscenePosition - 1].dialogText == "Hmph, this is all you can think of to help me?")
        {
            //lose state tutorial popup
            OpenTutorial("Oh well, you did your best! One last thing you should know about your interactions with residents! If you succeed in convincing them to work with you, then you will gain Influence with the resident's faction. \n\nYou'll be free to select whichever responses you like, but the quality of your response matters for the Influence gained. The more receptive your conversation partner is to your argument, the stronger your bond will become and the more Influence you'll have with their faction in the future. Your Influence will be utilized primarily in the second part of the game, though there may be a few opportunities to use this system in the first part of the game. From here you should know everything necessary to complete your work!");
        }
        else if (myTalk.rpgtalkElements[myTalk.cutscenePosition - 1].dialogText == "[Let's run through that one more time...]")
        {
            myTalk.buttonDisabled = -1;
        }
    }

    IEnumerator HighlightChoice()
    {
        yield return new WaitForEndOfFrame();
        Button[] myButtons = myTalk.choicesParent.GetComponentsInChildren<Button>();
        foreach (Button b in myButtons)
        {
            if (b.gameObject.transform.Find("Preview").GetComponent<Text>().text != chosenChoice)
            {
                b.interactable = false;
            }
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
