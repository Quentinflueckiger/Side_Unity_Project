using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable {

    // To be changed, JSON file and architecture
    public string[] dialogue;

    public string npcName;

    public override void Interact()
    {

        DialogueManager.Instance.AddNewDialogue(dialogue, npcName);
        Debug.Log("Interacting with NPC");
    }
}
