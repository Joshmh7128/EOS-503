using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // control variables
    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] private float playerSpeed = 5;
    [SerializeField] private Transform playerCamTrans; // the transform of the actual camera
    public CameraLerpScript cameraLerpScript; // so we can access it and give it camera positions when needed
    public bool isRealPlayer;

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

        // activate camera
        playerCamTrans.gameObject.SetActive(true);

    }

    // Fixed Update is called 60 times per second
    void FixedUpdate()
    {
        if (isRealPlayer == false)
        {
            PlayerController otherPlayerController = GameObject.Find("Player Controller Package").GetComponent<PlayerController>();

            if (otherPlayerController.isRealPlayer == true)
            {
                Destroy(gameObject);
            }
        }   

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
