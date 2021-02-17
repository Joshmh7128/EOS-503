using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    // variables
    [SerializeField] Transform playerTransform; // get our player
    [SerializeField] string targetScene; // which scene are we going to?
    [SerializeField] Vector2 targetCoords; // what coordinates are we landing at?
    [SerializeField] bool playerContact; // are we touching the player right now?
    [SerializeField] CustomSceneManager customSceneManager; // our custom scene manager

    // find the custom scene manager
    private void Start()
    {
        // if we don't have a scene manager...
        if (customSceneManager == null)
        {   // ...find it, and use it
            customSceneManager = GameObject.Find("SceneManager").GetComponent<CustomSceneManager>();
        }

        // if we don't have a player character...
        if (playerTransform == null)
        {   // ...find it, and use it
            playerTransform = GameObject.Find("PlaceholderPC").GetComponent<Transform>();
        }
    }


    // Update is called once per frame
    void Update()
    {
        // can we change rooms?
        if (playerContact == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                // move player in same frame as scene load
                playerTransform.position = targetCoords;
                // request scene load, targetscene is string
                customSceneManager.LoadSingleScene(targetScene);
            }
        }
    }

    // use on trigger enter to see if we are touching the player
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player")) // player trigger hitbox is different from collider hitbox. if this has issues double check overlap.
        {
            playerContact = true;
        }
    }

    // if the player leaves, reset bool
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            playerContact = false;
        }
    }

}
