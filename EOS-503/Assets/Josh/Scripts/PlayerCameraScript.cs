using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraScript : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    public bool isRealCamera;

    // Update is called once per frame
    void Update()
    {
        // look at the player
        transform.LookAt(playerTransform);
    }
}