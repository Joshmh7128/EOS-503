using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCActiveNavigation : MonoBehaviour
{
    /// <summary>
    /// this script spawns NPCs at a rate, and has them follow a predetermined path throughout the environment
    /// </summary>

    // the nodes that we will be working with to make our NPCs move
    [SerializeField] Vector2[] PathNodes;
    [SerializeField] Vector2[] PathNodesR; // random list
    // which node are we on?
    [SerializeField] int currentNode;
    // can we continue?
    [SerializeField] bool canAdd;
    // what is our current destination to move to?
    [SerializeField] Vector2 targetPosition;
    // the radius of randomness applied to each node to make the NPCs look more natural
    [SerializeField] float radiusRandomness;
    // what is the micro-radius for pathwalking the random nodes?
    [SerializeField] float degreeOfAcceptance;
    // movement speed
    [SerializeField] float movementSpeedlow;
    [SerializeField] float movementSpeedhigh;
    [SerializeField] float movementSpeedlocal;
    // the NPC prefab we'll be using for the path finding
    [SerializeField] GameObject pathwalkerNPC;
    // variable to  hold the NPC we spawn
    [SerializeField] GameObject activeNPC;

    // start runs when the object 
    private void Start()
    {
        // instantiate the walking NPC
        activeNPC = Instantiate(pathwalkerNPC, transform);
        // copy our list to our randomized list
        PathNodesR = PathNodes;
        // local counter
        int i = 0;
        // make our first target position the first position in the coordinates list
        targetPosition = PathNodesR[0];
        // set our current node to 0
        currentNode = 0;
        // define our movement speed and truncate. it is imporant that we make sure this remains a float so that it can hit the targeted 2 dp rounded positions.
        movementSpeedlocal = (float)(Random.Range(movementSpeedlow, movementSpeedhigh)*100 ) /100f;

        // randomize our node list
        foreach (Vector2 position in PathNodesR)
        {   
            // then input the randomized values, create our randomized variables and round to the 2nd decimal point
            PathNodesR[i] = new Vector2(position.x + (float)System.Math.Round(Random.Range(-radiusRandomness, radiusRandomness), 2), position.y + (float)System.Math.Round(Random.Range(-radiusRandomness, radiusRandomness), 2));
            i++;
        }
    }

    // update runs once per tick
    private void FixedUpdate()
    {
        // define our movement speed in game time
        float step = movementSpeedlocal * Time.deltaTime;

        // singleton to ensure we do not double count on frames when reaching destination
        canAdd = false;
        // every frame, move to our NPC to the target position
        if (activeNPC != null)
        {
            // movement
            activeNPC.transform.position = Vector2.MoveTowards(activeNPC.transform.position, targetPosition,  step);
        }
        // check to see if we have reached out target position, if so, add one to the node counter
        // create percentage node check range for movement progression
        float microRadiusRand;
        microRadiusRand = radiusRandomness * degreeOfAcceptance;
        // less than the maximum AND more than the mininum
        if ((activeNPC.transform.position.x < targetPosition.x + microRadiusRand)  && // less than max X at target pos?
            (activeNPC.transform.position.x > targetPosition.x + -microRadiusRand) && // more than min X?
            (activeNPC.transform.position.y < targetPosition.y + microRadiusRand) && // less than max Y?
            (activeNPC.transform.position.y > targetPosition.y + -microRadiusRand) // more than min Y?
            )
        {
            // check singleton
            canAdd = true;
            // add one to the counter
            if (canAdd == true)
            {
                currentNode += 1;
                // perform a check
                if (currentNode >= PathNodes.Length)
                {
                    ResetPathwalker();
                }

                // assign new target
                targetPosition = PathNodesR[currentNode];
                canAdd = false;
            }
        }

        // when we reach the end of our path, reset the node counter and reinstatiate the NPC
        if (currentNode >= PathNodes.Length)
        {
            ResetPathwalker();
        }
    }

    // pathwalking 
    private void ResetPathwalker()
    {
        // destroy our current NPC
        Destroy(activeNPC);
        // reset our counter
        currentNode = 0;
        // copy our list to our randomized list
        PathNodesR = PathNodes;
        // local counter
        int i = 0;
        // randomize our node list
        foreach (Vector2 position in PathNodesR)
        {
            PathNodesR[i] = new Vector2((float)position.x + (Random.Range(-radiusRandomness, radiusRandomness)), (float)position.y + (Random.Range(-radiusRandomness, radiusRandomness)));
            i++;
        }
        // spawn our new NPC
        activeNPC = Instantiate(pathwalkerNPC, transform);
    }

    // draw gizmos
    private void OnDrawGizmos()
    {
        // draw each position in the path
        foreach (Vector2 position in PathNodes)
        {
            Gizmos.DrawWireSphere(position, radiusRandomness*2);
        }
    }
}
