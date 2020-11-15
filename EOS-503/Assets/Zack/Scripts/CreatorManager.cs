using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatorManager : MonoBehaviour
{
    public BodyPart[] customizableParts;

    public PlayerImage player;

    // Start is called before the first frame update
    void Start()
    {
        foreach (BodyPart part in customizableParts)
        {
            part.buttonText.text = "Option 1";
            part.bodypart.sprite = part.options[0];
            part.optionInUse = 0;
        }
    }

    public void ChangePartLeft(int index)
    {
        BodyPart part = customizableParts[index];

        // First, we gotta make sure we don't get an index error
        int subIndex = part.optionInUse - 1;

        if (subIndex >= part.options.Length)
        {
            subIndex -= part.options.Length;
        }
        else if (subIndex < 0)
        {
            subIndex += part.options.Length;
        }

        // Now that our index is gucci, let's change some stuff!
        part.buttonText.text = "Option " + (subIndex + 1).ToString();
        part.bodypart.sprite = part.options[subIndex];
        part.optionInUse = subIndex;

    }

    public void ChangePartRight(int index)
    {
        BodyPart part = customizableParts[index];

        // First, we gotta make sure we don't get an index error
        int subIndex = part.optionInUse + 1;

        if (subIndex >= part.options.Length)
        {
            subIndex -= part.options.Length;
        }
        else if (subIndex < 0)
        {
            subIndex += part.options.Length;
        }

        // Now that our index is gucci, let's change some stuff!
        part.buttonText.text = "Option " + (subIndex + 1).ToString();
        part.bodypart.sprite = part.options[subIndex];
        part.optionInUse = subIndex;
    }

    public void ChangeColor(Color color, int[] indeces)
    {
        foreach (int index in indeces)
        {
            BodyPart part = customizableParts[index];

            part.bodypart.color = color;
        }
    }

    public void SaveChanges()
    {
        if (customizableParts.Length != player.images.Length)
        {
            Debug.LogError("Number of parts don't match! Fix ASAP!!!");
        }

        for (int i = 0; i < customizableParts.Length; i++)
        {
            player.images[i].sprite = customizableParts[i].bodypart.sprite;
            player.images[i].color = customizableParts[i].bodypart.color;
        }
    }

    public void DiscardChanges()
    {
        if (customizableParts.Length != player.images.Length)
        {
            Debug.LogError("Number of parts don't match! Fix ASAP!!!");
        }

        for (int i = 0; i < customizableParts.Length; i++)
        {
            customizableParts[i].bodypart.sprite = player.images[i].sprite;
            customizableParts[i].bodypart.color = player.images[i].color;
        }
    }
}
