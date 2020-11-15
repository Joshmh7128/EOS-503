using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPicker : MonoBehaviour
{
    public CreatorManager manager;

    public int[] parts;

    public void GetHexValue(string hex)
    {
        Color color;
        ColorUtility.TryParseHtmlString("#" + hex, out color);
        SendColorToManager(color, parts);
    }

    private void SendColorToManager(Color color, int[] parts)
    {
        manager.ChangeColor(color, parts);
    }
}
