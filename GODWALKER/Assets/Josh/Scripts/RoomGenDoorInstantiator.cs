using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenDoorInstantiator : MonoBehaviour
{
    [SerializeField] Transform doorSpawnPoint; // where the door?
    [SerializeField] GameObject doorPrefab; // what the door?
    [SerializeField] GenerationManager generationManager; // our generation manager
    [SerializeField] bool tripped; // tripped yet?

    // when this is enabled
    void FixedUpdate()
    {
        // singleton run
        if (tripped == false)
        {
            // if we don't have a generation manager, find one
            if (generationManager == null)
            {
                generationManager = FindObjectOfType<GenerationManager>();
            }

            // if our room amount is less than the max, spawn a new door
            if (generationManager.activeRooms < generationManager.maxRoomSpawn)
            {
                // make the door
                Instantiate(doorPrefab, doorSpawnPoint.position, transform.rotation, null);
                // incriment, swine.
                generationManager.activeRooms++;
            }

            // trip the singleton
            tripped = true;
        }
        // else, make the exit to the leve
    }
}
