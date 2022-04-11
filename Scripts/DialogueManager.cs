using System;
using System.Collections;
using UnityEngine;
using TMPro;


public class DialogueManager : MonoBehaviour
{
    private static event Action<DialogueData> OnDialogueRequested;
    public static void RequestDialogue(DialogueData dialogue) => OnDialogueRequested?.Invoke(dialogue); 

    [SerializeField] private GameObject DialogueBox;
    [SerializeField] private TextMeshProUGUI textBox;
    [SerializeField] private GameObject NPCBox;
    [SerializeField] private TextMeshProUGUI nameBox;
    [SerializeField] private float textSpeed = 0.05f;

 private DialogueData currentDialogue;   
    private int index;

    public bool active => DialogueBox.activeSelf;

    private void OnEnable() => OnDialogueRequested += PrepareDialogue; 
    private void OnDisable() => OnDialogueRequested -= PrepareDialogue;

private void PrepareDialogue(DialogueData dialogue)
    {
        if (dialogue != null) 
        {
            if (dialogue == currentDialogue) 
            {
                nameBox.text = currentDialogue.npcname;    
                OnInput(); 
            }
            else 
            {
                currentDialogue = dialogue; 
                nameBox.text = currentDialogue.npcname;
                index = -1; 

                DialogueBox.SetActive(true); 
                NPCBox.SetActive(true);

                NextLine(); 
            }
        }
        else
        {
            EndDialogue();
        }
    }
private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && currentDialogue != null)
        {
            OnInput();
        }
    }

    
    private void OnInput()
    {
        if (textBox.text == currentDialogue.lines[index]) 
        {
            NextLine(); 
        }
        else
        {
            StopAllCoroutines();
            textBox.text = currentDialogue.lines[index]; 
        }
    }

    private void NextLine()
    {
        /*Alternative: 
        if (index < currentDialogue.lines.Length -1)
        {
            index++;
            textBox.text = string.Empty;
            StartCoroutine(TypeLine());
        }*/
        index++; 

        if (index < currentDialogue.lines.Length)
        {
            textBox.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            EndDialogue();
        }
    }

    private void EndDialogue()
    {
        currentDialogue = null; 
        index = -1; 

        textBox.text = string.Empty; 
        nameBox.text = string.Empty;
        DialogueBox.SetActive(false); 
        NPCBox.SetActive(false);

        StopAllCoroutines(); 
    }

    private IEnumerator TypeLine()
    {
        foreach (char c in currentDialogue.lines[index].ToCharArray())
        {
            textBox.text += c; 
            yield return new WaitForSeconds(textSpeed);
        }
    }
}