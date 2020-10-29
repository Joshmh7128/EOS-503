using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HistoryElement : MonoBehaviour
{
    private string spoke;
    private string said;

    public HistoryElement(string spoke, string said)
    {
        this.spoke = spoke;
        this.said = said;
    }
}
