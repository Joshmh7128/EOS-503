using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class BodyPart
{
    public string Name;

    public Image bodypart; // A reference to a specific body part

    public Text buttonText;

    public Sprite[] options; // Contains all sprites to switch to for customization

    [HideInInspector] public int optionInUse = 0; // We use this to keep track of which option is currently being used
}
