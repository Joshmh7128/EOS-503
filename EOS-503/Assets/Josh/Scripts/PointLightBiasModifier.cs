using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class PointLightBiasModifier : MonoBehaviour
{
    // this script sets light bias
    public float setBias = -0.66f; // change for global

    // Update is called once per frame
    void Update()
    {
        GetComponent<Light>().shadowBias = setBias;
    }
}
