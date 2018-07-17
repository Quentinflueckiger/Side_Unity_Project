using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public static DialogueManager Instance{ get; set; }

    [HideInInspector]
    public List<string> dialogueLines = new List<string>();
    [HideInInspector]
    public string npcName;

    public GameObject dialoguePanel;

    Button continueButton;
    Text dialogueText, dialogueNameText;
    int dialogueIndex;

    private void Awake()
    {
        // Sinlgeton
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        // Maybe to be changed so you can do it in the inspector instead of coding.
        continueButton = dialoguePanel.transform.Find("Continue").GetComponent<Button>();
        dialogueText = dialoguePanel.transform.Find("Text").GetComponent<Text>();
        dialogueNameText = dialoguePanel.transform.Find("Name").GetChild(0).GetComponent<Text>();

        continueButton.onClick.AddListener(delegate { ContinueDialogue(); });

        dialoguePanel.SetActive(false);
    }
    
    public void AddNewDialogue(string[] lines, string npcName)
    {

        dialogueIndex = 0;

        dialogueLines = new List<string>(lines.Length);
        dialogueLines.AddRange(lines);

        this.npcName = npcName;

        CreateDialogue();
    }

    public void ContinueDialogue()
    {

        if (dialogueIndex < dialogueLines.Count - 1)
        {

            dialogueIndex++;
            dialogueText.text = dialogueLines[dialogueIndex];
        }
        else
        {

            dialoguePanel.SetActive(false);
        }
    }

    public void CreateDialogue()
    {

        dialogueText.text = dialogueLines[dialogueIndex];
        dialogueNameText.text = npcName;
        dialoguePanel.SetActive(true);
    }
}
