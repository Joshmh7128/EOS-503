using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    // Awake is called before everything
    void Awake()
    {
        DontDestroyOnLoad(this);

    }
}