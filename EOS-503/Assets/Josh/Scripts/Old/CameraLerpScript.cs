using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLerpScript : MonoBehaviour
{
    // get our literal transform
    [SerializeField] private Transform literalCamTransform; // our literal camera transform
    [SerializeField] private Transform followCamPos; // our following camera position
    public Transform currentRoomCamTransform; // the camera transform of our current room. Change when moving into new rooms

    private Vector3 camPosition; // camera position
    private Quaternion camRotation; // camera rotation

    public bool isFollow; // is the camera in follow mode?

    // Fixed Update is called 60 times per second
    void FixedUpdate()
    {
        // lerp values
        camPosition = Vector3.Lerp(transform.position, literalCamTransform.position, 0.1f);
        camRotation = Quaternion.Lerp(transform.rotation, literalCamTransform.rotation, 0.1f);
        // move to the values
        transform.position = camPosition;
        transform.rotation = camRotation;

        // update our camera's position based on the mode we're in currently
        UpdateCam(isFollow); 
    }

    private void Update()
    {
        // for testing purposes, when we press F, switch from our camera mode
        if (Input.GetKeyDown(KeyCode.F))
        {
            isFollow = !isFollow;
        }
    }

    // update our camera's position
    void UpdateCam(bool isFollow)
    {
        if (isFollow == true)
        {
            // if we are in follow mode, set the camera's positional parent to the follow camera position
            literalCamTransform.position = followCamPos.position;
        }

        if (isFollow == false)
        {
            // if we are in stationary mode, set the camera's positional parent to the room's current stationary position
            literalCamTransform.position = currentRoomCamTransform.position;
        }
    }
}