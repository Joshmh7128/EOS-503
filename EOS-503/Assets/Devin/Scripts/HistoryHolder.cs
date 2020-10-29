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
    public Button backButton;
    public Button nextButton;

    private void Awake()
    {
        myTalk.myHistory = this;
    }
}
