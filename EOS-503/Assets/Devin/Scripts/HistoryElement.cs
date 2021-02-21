using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HistoryElement : MonoBehaviour
{
    public string spoke;
    public string said;

    public HistoryElement(string spoke, string said)
    {
        this.spoke = spoke;
        this.said = said;
    }
}
