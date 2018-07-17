using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignPost : ActionItem {

    // To be changed, JSON file and architecture
    public string[] dialogue;

    public override void Interact()
    {

        DialogueManager.Instance.AddNewDialogue(dialogue, "Sign post");
        Debug.Log("Interacting with sign post.");
    }
}
