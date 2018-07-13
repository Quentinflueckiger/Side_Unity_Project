using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorldInteraction : MonoBehaviour {

    NavMeshAgent playerAgent;

    private void Start()
    {

        playerAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {

        // Check if Left mouse button is pressed and the mouse is not on an UI element.
        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            GetInteraction();
        }
    }

    void GetInteraction()
    {

        Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit interactionInfo;

        // Check for collision from mouse position to infinity.
        if (Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity))
        {

            GameObject interactedObject = interactionInfo.collider.gameObject;

            // Check if the object found is an interactable.
            if(interactedObject.tag == "Interactable Object")
            {
                // To be changed, this will not be a click to move game.
                interactedObject.GetComponent<Interactable>().MoveToInteraction(playerAgent);
            }
            else
            {

                playerAgent.stoppingDistance = 0f;
                // To be changed, this will not be a click to move game.
                playerAgent.destination = interactionInfo.point;
            }
        }
    }
}
