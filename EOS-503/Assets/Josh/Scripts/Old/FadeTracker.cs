using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeTracker : MonoBehaviour
{
    // tracks fade state
    public bool fadeState;

    private void FixedUpdate()
    {
        // safety unfade in case we double load the package
        if (fadeState == false)
        {
            gameObject.GetComponent<CanvasGroup>().alpha -= 0.05f;
        }
    }

}
