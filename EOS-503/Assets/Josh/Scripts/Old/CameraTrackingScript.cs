using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrackingScript : MonoBehaviour
{
    /// this script makes sure cameras don't double up on themselves
    /// all other camera destruction is done through PlayerController.cs
    /// all camera activation is done through PlayerController.cs

    public bool isRealCamera; // is this the real camera?

    private void Start()
    {
        if (isRealCamera == false)
        {
            CameraTrackingScript otherCameraController = GameObject.Find("Camera Package").GetComponent<CameraTrackingScript>();

            if (otherCameraController.isRealCamera == true)
            {
                Destroy(gameObject);
            }
        }
    }

}
