using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Interactable : MonoBehaviour {

    [HideInInspector]
    public NavMeshAgent playerAgent;
    private bool hasInteracted;

    public virtual void MoveToInteraction(NavMeshAgent playerAgent)
    {

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

                Interact();
                hasInteracted = true;
            }
        }
    }

    public virtual void Interact()
    {
        Debug.Log("Interacting with base class.");
    }
}
