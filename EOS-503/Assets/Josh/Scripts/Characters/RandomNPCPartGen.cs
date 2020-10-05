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
    [SerializeField] SpriteRenderer HandsRenderer;    // renderer of our hands
    [SerializeField] Color SkinColor;           // color of our skin
    [SerializeField] Transform ShirtParent;     // shirt parent
    [SerializeField] Transform PantsParent;     // pants parent
    [SerializeField] Transform ShoesParent;     // shoes parent
    // all of our random selections
    [SerializeField] int hairFrontChoice;
    [SerializeField] int hairBackChoice;
    [SerializeField] int headChoice;
    [SerializeField] int shirtChoice;
    [SerializeField] int pantsChoice;
    [SerializeField] int shoesChoice;
    // lists of skin and hair colors
    [SerializeField] Color[] skinColors;
    [SerializeField] Color[] hairColors;

    private void Start()
    {
        // in the start, generate all of our choices based off of the amount of children each object has
        FullGen();
    }

    private void FullGen()
    {
        // pick hair front and activate
        hairFrontChoice = Random.Range(0, HairFrontParent.childCount);
        GameObject hairFrontChoiceObject = HairFrontParent.GetChild(hairFrontChoice).gameObject;
        hairFrontChoiceObject.SetActive(true);
        // hair back and activate
        hairBackChoice = Random.Range(0, HairBackParent.childCount);
        GameObject hairBackChoiceObject = HairBackParent.GetChild(hairBackChoice).gameObject;
        hairBackChoiceObject.SetActive(true);
        // hair color choice and application
        Color hairColor = hairColors[Random.Range(0, hairColors.Length)]; // choose color
        hairFrontChoiceObject.gameObject.GetComponent<SpriteRenderer>().color = hairColor; // set front
        hairBackChoiceObject.gameObject.GetComponent<SpriteRenderer>().color = hairColor; // set back
        // head
        headChoice = Random.Range(0, HeadParent.childCount);
        GameObject headChoiceObject = HeadParent.GetChild(headChoice).gameObject;
        headChoiceObject.SetActive(true);
        // head and hands skin color choice and application
        Color skinColor = skinColors[Random.Range(0, skinColors.Length)]; // choose color
        headChoiceObject.gameObject.GetComponent<SpriteRenderer>().color = skinColor; // set front
        HandsRenderer.color = skinColor; // set back
        // shirt
        shirtChoice = Random.Range(0, ShirtParent.childCount);
        GameObject shirtChoiceObject = ShirtParent.GetChild(shirtChoice).gameObject;
        shirtChoiceObject.SetActive(true);
        // pants
        pantsChoice = Random.Range(0, PantsParent.childCount);
        GameObject pantsChoiceObject = PantsParent.GetChild(pantsChoice).gameObject;
        pantsChoiceObject.SetActive(true);
        //shoes
        shoesChoice = Random.Range(0, ShoesParent.childCount);
        GameObject shoesChoiceObject = ShoesParent.GetChild(shoesChoice).gameObject;
        shoesChoiceObject.SetActive(true);
    }
}
