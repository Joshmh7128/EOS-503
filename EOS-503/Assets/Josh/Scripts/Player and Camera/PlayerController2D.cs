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
    [SerializeField] protected Sprite[] playerSprites;
    [SerializeField] protected SpriteRenderer playerSpriteRenderer;
    public NPC partnerNPC;

	int spriteToUse = 0; // Zack was here :P
	bool lookingUp = false;

    // the awake function is called before anything else
    private void Awake()
    {
        // make sure we don't lose the player
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        #region // old real player detection
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
        #endregion
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

    // update runs like there's not tomorrow
    private void Update()
    {
        // did we press e while we can talk to someone?
        if (Input.GetKeyDown(KeyCode.E) && (partnerNPC != null) && !partnerNPC.myTalk.textUIObj.activeInHierarchy)
        {
            // start our conversation from the partnerNPC
            partnerNPC.StartConversation();
            partnerNPC.myPlayer = this;
            canMove = false;
            playerRigidbody.velocity = Vector3.zero;
            partnerNPC.transform.Find("Prompt").gameObject.SetActive(false);
        }
    }

    // checking for talkable NPCs
    private void OnTriggerEnter2D(Collider2D col)
    {
        // do they have a talkable tag?
        if (col.CompareTag("Talkable"))
        {
            col.transform.Find("Prompt").gameObject.SetActive(true);
            // set "partnerNPC" to the person we're able to talk to, set to null if we're not talking to anyone
            partnerNPC = col.gameObject.GetComponent<NPC>();
        }
    }

    // check for leaving a talkable's NPC trigger range
    private void OnTriggerExit2D(Collider2D col)
    {
        // do they have a talkable tag?
        if (col.CompareTag("Talkable"))
        {
            col.transform.Find("Prompt").gameObject.SetActive(false);
            // set "partnerNPC" to the person we're able to talk to, set to null if we're not talking to anyone
            partnerNPC = null;
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

		if (playerRigidbody.velocity.y > 0)
		{
			lookingUp = true;
		}
		else if (playerRigidbody.velocity.y < 0 || playerRigidbody.velocity.x != 0)
		{
			lookingUp = false;
		}

		if (playerRigidbody.velocity.x < 0)
		{
			if (lookingUp)
			{
				spriteToUse = 3;
			}
			else
			{
				spriteToUse = 1;
			}
		}
		else if (playerRigidbody.velocity.x > 0)
		{
			if (lookingUp)
			{
				spriteToUse = 2;
			}
			else
			{
				spriteToUse = 0;
			}
		}

		playerSpriteRenderer.sprite = playerSprites[spriteToUse];
    }
}
