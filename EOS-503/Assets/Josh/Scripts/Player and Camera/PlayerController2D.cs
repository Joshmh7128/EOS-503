﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    // control variables
    [SerializeField] private Rigidbody2D playerRigidbody;
    [SerializeField] private float playerSpeed = 5;
    [SerializeField] private Transform playerCamTrans; // the transform of the actual camera
    public CameraLerpScript cameraLerpScript; // so we can access it and give it camera positions when needed
    public bool isRealPlayer;
    public bool canMove;
    [SerializeField] protected Sprite[] playerSprites;
    [SerializeField] protected SpriteRenderer playerSpriteRenderer;

    // the awake function is called before anything else
    private void Awake()
    {
        // make sure we don't lose the player
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        // check to see if player is the real player, if not, destroy it
        /*if (isRealPlayer == false)
        {
            PlayerController otherPlayerController = GameObject.Find("Player Controller Package").GetComponent<PlayerController>();

            if (otherPlayerController == null)
            {
                Debug.Log("No Other Player Controller Detected");
            }
            else if (otherPlayerController.isRealPlayer == true)
            {
                Destroy(gameObject);
            }
        }*/
    }

    // Fixed Update is called 60 times per second
    void FixedUpdate()
    {
        // movement check
        if (canMove == true)
        {
            PlayerMove();
        }
    }

    // player movement
    void PlayerMove()
    {
        // get horizontal and vertical movement
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        // set the velocity
        playerRigidbody.velocity = new Vector3(horizontalMovement * playerSpeed, verticalMovement * playerSpeed);

        // set the player's sprite accordingly
        /// 
        /// Sprites are:
        /// 0 - Facing Forward Right
        /// 1 - Facing Forward Left
        /// 2 - Facing Back Right
        /// 3 - Facing Back Left
        /// 

        // up 
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Space Pressed");
        }

        // up 
        if (Input.GetKey(KeyCode.W))
        {
            playerSpriteRenderer.sprite = playerSprites[2];
        }
        // down
        if (Input.GetKey(KeyCode.S))
        {
            playerSpriteRenderer.sprite = playerSprites[0];
        }
        // right
        if (Input.GetKey(KeyCode.D))
        {
            playerSpriteRenderer.sprite = playerSprites[0];
        }
        // left
        if (Input.GetKey(KeyCode.A))
        {
            playerSpriteRenderer.sprite = playerSprites[1];
        }
        // up right
        if (Input.GetKey(KeyCode.W) && Input.GetKey((KeyCode.D)))
        {
            playerSpriteRenderer.sprite = playerSprites[2];
        }

        // up left
        if (Input.GetKey(KeyCode.W) && Input.GetKey((KeyCode.A)))
        {
            playerSpriteRenderer.sprite = playerSprites[3];
        }

        // down right
        if (Input.GetKey(KeyCode.S) && Input.GetKey((KeyCode.D)))
        {
            playerSpriteRenderer.sprite = playerSprites[0];
        }

        // down left
        if (Input.GetKey(KeyCode.S) && Input.GetKey((KeyCode.A)))
        {
            playerSpriteRenderer.sprite = playerSprites[1];
        }
    }
}
