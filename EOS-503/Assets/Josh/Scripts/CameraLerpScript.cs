using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLerpScript : MonoBehaviour
{
    // get our literal transform
    [SerializeField] private Transform literalCamTransform;
    private Vector3 camPosition;
    private Quaternion camRotation;

    // Update is called once per frame
    void FixedUpdate()
    {
        // lerp values
        camPosition = Vector3.Lerp(transform.position, literalCamTransform.position, 0.25f);
        camRotation = Quaternion.Lerp(transform.rotation, literalCamTransform.rotation, 0.25f);
        // move to the values
        transform.position = camPosition;
        transform.rotation = camRotation;
    }
}
