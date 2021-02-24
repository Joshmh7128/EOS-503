using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorGenScript : MonoBehaviour
{
    // trip
    bool singletonTrip;
    // Start is called before the first frame update
    void Start()
    {
        if (singletonTrip == false)
        {
            // for each of the children, make sure they are not active
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }

            // randomly choose a room from your children
            transform.GetChild(Random.Range(0, transform.childCount)).gameObject.SetActive(true);

            singletonTrip = true;
        }
    }
}
