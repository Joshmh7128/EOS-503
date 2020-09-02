using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToCam : MonoBehaviour
{
    // player camera transform
    [SerializeField] Transform playerCamTrans;

    // Update is called once per frame
    void FixedUpdate()
    {
        // make it look at the camera only on the y axis
        transform.forward = new Vector3(Camera.main.transform.forward.x, transform.forward.y, Camera.main.transform.forward.z);
    }
}
