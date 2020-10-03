using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNPCPartGen : MonoBehaviour
{
    // this script will generate hair back, hair front, head & skin color, hands & apply skin color, shirt, pants, and shoes
    [SerializeField] Transform HairFrontParent; // the hair front parent
    [SerializeField] Transform HairBackParent;  // hair back parent
    [SerializeField] Color HairColor;           // color of our hair
    [SerializeField] Transform HeadParent;      // our Head parent
    [SerializeField] Renderer HandsRenderer;    // renderer of our hands
    [SerializeField] Color SkinColor;           // color of our skin
    [SerializeField] Transform ShirtParent;     // shirt parent
    [SerializeField] Transform PantsParent;     // pants parent
    // all of our random selections
    [SerializeField] int hairFrontChoice;
    [SerializeField] int hairBackChoice;
    [SerializeField] int headChoice;
    [SerializeField] int shirtChoice;
    [SerializeField] int pantsChoice;
    // lists of skin and hair colors
    [SerializeField] Color[] colors;

    private void Start()
    {
        // in the start, generate all of our choices based off of the amount of children each object has

        // hair front
        hairFrontChoice = Random.Range(0, HairFrontParent.childCount);
        // hair back
        hairBackChoice = Random.Range(0, HairBackParent.childCount);
        // hair color application

        // head

        // shirt

        // pants
    }

    // select and choose our hair back style, if it is empty also select the empty front style
    void HairFrontGen()
    {

    }
}
