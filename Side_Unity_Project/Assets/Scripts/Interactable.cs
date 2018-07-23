using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Interactable : MonoBehaviour {

    [HideInInspector]
    public NavMeshAgent playerAgent;
    private bool hasInteracted;
    bool isEnemy;

    public virtual void MoveToInteraction(NavMeshAgent playerAgent)
    {

        isEnemy = gameObject.tag == "Enemy";
        hasInteracted = false;
        this.playerAgent = playerAgent;
        playerAgent.stoppingDistance = 3.5f;
        playerAgent.destination = this.transform.position;
    }

    private void Update()
    {
        
        // Check if the interaction already occured, if there is a player and if he finished finding a path.
        if (!hasInteracted && playerAgent != null && !playerAgent.pathPending)
        {

            // Check if the distance between the player and the interactable is less than the stoppingDistance.
            if (playerAgent.remainingDistance <= playerAgent.stoppingDistance)
            {
                if (!isEnemy)
                    Interact();
                //EnsureLookDirection();
                hasInteracted = true;
            }
        }
    }

    public virtual void Interact()
    {
        Debug.Log("Interacting with base class.");
    }

    /*void EnsureLookDirection()
    {
        playerAgent.updateRotation = false;
        Vector3 lookDirection = new Vector3(transform.position.x, playerAgent.transform.position.y, transform.position.z);
        playerAgent.transform.LookAt(lookDirection);
        playerAgent.updatePosition = true;
    }*/
}
