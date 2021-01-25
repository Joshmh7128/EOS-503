using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    // variables
    [SerializeField] GameObject playerObject; // get our player
    [SerializeField] string targetScene; // which scene are we going to?
    [SerializeField] Vector2 targetCoords; // what coordinates are we landing at?
    [SerializeField] bool playerContact; // are we touching the player right now?
    CustomSceneManager customSceneManager; // our custom scene manager

    // Update is called once per frame
    void Update()
    {
        // can we change rooms?
        if (playerContact == true)
        {
            if (Input.GetKey(KeyCode.E))
            {
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
