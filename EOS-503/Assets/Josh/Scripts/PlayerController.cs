﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // control variables
    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] private float playerSpeed = 5;
    [SerializeField] private Transform playerCamTrans; // the transform of the actual camera
    public CameraLerpScript cameraLerpScript; // so we can access it and give it camera positions when needed

    // Fixed Update is called 60 times per second
    void FixedUpdate()
    {
        // movement check
        PlayerMove();
    }

    // player movement
    void PlayerMove()
    {
        // get horizontal and vertical movement
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");
        // get our movement directional values
        float finalHoriMovement = horizontalMovement *= playerSpeed;
        float finalVertMovement = verticalMovement *= playerSpeed;
        // move the player's vector3
        Vector3 move = transform.forward * finalVertMovement + transform.right * finalHoriMovement;
        float xMove = finalHoriMovement;
        float zMove = finalVertMovement;
        // set the velocity
        playerRigidbody.velocity = new Vector3(-xMove, playerRigidbody.velocity.y, -zMove);
    }
}