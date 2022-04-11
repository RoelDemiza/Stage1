using UnityEngine;

public class DialogueNPC : MonoBehaviour
{
    [SerializeField] private DialogueData dialogue;
    
    private bool playerInRange; 

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {

            DialogueManager.RequestDialogue(dialogue);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.isTrigger && other.CompareTag("Player"))
        {

            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.isTrigger && other.CompareTag("Player"))
        {

            playerInRange = false;
            DialogueManager.RequestDialogue(null);
        }
    }
}