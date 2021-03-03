using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCActiveNavigation : MonoBehaviour
{
    /// <summary>
    /// this script spawns NPCs at a rate, and has them follow a predetermined path throughout the environment
    /// </summary>

    [Header("Original Path Nodes, Define In-Editor")]
    // the nodes that we will be working with to make our NPCs move
    [SerializeField] List<Vector2> PathNodes; // our original position list, do not overwrite
    [Header("Randomized Path Nodes, Do Not Touch")]
    [SerializeField] List<Vector2> PathNodesR; // our randomized node list
    // which node are we on?
    [SerializeField] int currentNode;
    // can we continue?
    [SerializeField] bool canAdd;
    // what is our current destination to move to?
    [SerializeField] Vector2 targetPosition;
    [SerializeField] Vector2 startingPosition;
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
        // set our starting position
        startingPosition = transform.position;

        // instantiate the walking NPC
        activeNPC = Instantiate(pathwalkerNPC, transform);

        // copy our list to our randomized list
        int x = 0;

        /*foreach (Vector2 element in PathNodes)
        {
            // testing output
            // Debug.Log("Adding element " + x);
            // copy
            PathNodesR.Add(PathNodes[x]);
            // add to counter
            x++;
        }*/

        // make our first target position the first position in the coordinates list
        targetPosition = PathNodesR[0];
        // set our current node to 0
        currentNode = 0;
        // define our movement speed and truncate. it is imporant that we make sure this remains a float so that it can hit the targeted 2 dp rounded positions.
        movementSpeedlocal = (float)(Random.Range(movementSpeedlow, movementSpeedhigh)*100 ) /100f;
        
        // slightly randomize the nodes in our list to make the pathwalking appear more natural, and less calculated
            // foreach loop to randomize each node within the degree of radiusRandomness
            for (int i = 0; i < PathNodesR.Count; i++)
            {   
                // then input the randomized values, create our randomized variables and round to the 2nd decimal point
                PathNodesR[i] = new Vector2(PathNodesR[i].x + (float)System.Math.Round(Random.Range(-radiusRandomness, radiusRandomness), 2), PathNodesR[i].y + (float)System.Math.Round(Random.Range(-radiusRandomness, radiusRandomness), 2));
                // Debug.Log("Randomizing element " + i);
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
                if (currentNode >= PathNodes.Count)
                {
                    ResetPathwalker();
                }

                // assign new target
                targetPosition = PathNodesR[currentNode];
                canAdd = false;
            }
        }

        // when we reach the end of our path, reset the node counter and reinstatiate the NPC
        if (currentNode >= PathNodes.Count)
        {
            ResetPathwalker();
        }
    }

    // pathwalking 
    private void ResetPathwalker()
    {
        // instead of destroying NPC, reset their XY position to restart the path
        activeNPC.transform.position = startingPosition;
        // reset our counter
        currentNode = 0;

        // copy our list to our randomized list
        // local counter
        int x = 0;

        /*
        // foreach copy
        foreach (Vector2 element in PathNodes)
        {
            // testing output
            Debug.Log("Randomizing element " + x);
            // copy
            PathNodesR.Add(PathNodes[x]);
            // add to counter
            x++;
        }
        */ 
        // local counter
        int i = 0;

        /*
        // randomize our node list
        foreach (Vector2 position in PathNodesR)
        {
            PathNodesR[i] = new Vector2((float)position.x + (Random.Range(-radiusRandomness, radiusRandomness)), (float)position.y + (Random.Range(-radiusRandomness, radiusRandomness)));
            i++;
        };*/
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
