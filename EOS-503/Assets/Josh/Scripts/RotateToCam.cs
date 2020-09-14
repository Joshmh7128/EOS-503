using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToCam : MonoBehaviour
{
    // player camera transform
    [SerializeField] Transform playerCamTrans;
    public CameraLerpScript cameraLerpScript;

    // Update is called once per frame
    void FixedUpdate()
    {
        // make it look at the camera only on the y axis
        if (cameraLerpScript.isFollow == false)
        {
            transform.forward = new Vector3(Camera.main.transform.forward.x, transform.forward.y, Camera.main.transform.forward.z);
        }
        else
        {
            transform.forward = Vector3.forward;
        }
    }
}