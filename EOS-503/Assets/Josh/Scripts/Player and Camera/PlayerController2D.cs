using System.Collections;
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

    // the awake function is called before anything else
    private void Awake()
    {
        // make sure we don't lose the player
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        // check to see if player is the real player, if not, destroy it
        if (isRealPlayer == false)
        {
            PlayerController otherPlayerController = GameObject.Find("Player Controller Package").GetComponent<PlayerController>();

            if (otherPlayerController.isRealPlayer == true)
            {
                Destroy(gameObject);
            }
        }
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
    }
}
