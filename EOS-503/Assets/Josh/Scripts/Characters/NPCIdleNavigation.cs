using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCIdleNavigation : MonoBehaviour
{
    // this script will allow NPCs to move around within a given radius
    [SerializeField] float navigationRadius;
    [SerializeField] Vector2 startingPosition;
    [SerializeField] Vector2 targetPosition;
    [SerializeField] float movementSpeed;
    [SerializeField] float movementSpeedMin;
    [SerializeField] float movementSpeedMax;
    [SerializeField] Transform CharacterSpriteContainer;
 
    private void Start()
    {
        // get starting position
        startingPosition = transform.position;
        // start our movement cycle
        StartCoroutine(MovementCycle());
    }

    private void FixedUpdate()
    {
        float step = movementSpeed * Time.deltaTime;

        // move sprite towards the target location
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, step);

        // change the sprite size based on it's direction
        // to the right
        if (targetPosition.x > transform.position.x)
        {
            CharacterSpriteContainer.localScale = new Vector2(1, 1);
        }

        // to the left
        if (targetPosition.x < transform.position.x)
        {
            CharacterSpriteContainer.localScale = new Vector2(-1, 1);
        }
    }

    // our movement coroutine
    IEnumerator MovementCycle()
    {
        movementSpeed = Random.Range(movementSpeedMin, movementSpeedMax);
        targetPosition = new Vector2(startingPosition.x + Random.Range(0,navigationRadius), startingPosition.y + Random.Range(0, navigationRadius));
        yield return new WaitForSeconds(Random.Range(1, 6));
        StartCoroutine(MovementCycle()); // auto restart
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, navigationRadius);
    }
}
