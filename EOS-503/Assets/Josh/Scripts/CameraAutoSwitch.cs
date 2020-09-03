using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAutoSwitch : MonoBehaviour
{
    [SerializeField] CameraLerpScript cameraLerpScript;
    [SerializeField] Transform localCameraPosition;
    [SerializeField] bool isFollowSwitch;
    // Start is called before the first frame update
    void Start()
    {
        // get our lerp script off of our camera and save it for later use
        cameraLerpScript = Camera.main.gameObject.GetComponent<CameraLerpScript>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            // if the player walks into our trigger, set their camera position to our room
            cameraLerpScript.currentRoomCamTransform = localCameraPosition;

            if (isFollowSwitch == true)
            {
                cameraLerpScript.isFollow = true;
            }
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            // if the player walks into our trigger, set their camera position to our room
            cameraLerpScript.currentRoomCamTransform = localCameraPosition;

            if (isFollowSwitch == true)
            {
                cameraLerpScript.isFollow = false;
            }
        }
    }
}
