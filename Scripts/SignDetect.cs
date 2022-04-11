using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignDetect : MonoBehaviour
{
    public GameObject dialogBox;
	public Text dialogText;
	public string dialog;
	public bool playerInRange;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){
	
    }

	private void OnTriggerEnter2D(Collider2D other) {
    if (other.CompareTag("Player")) {
        playerInRange = true;
        dialogBox.SetActive(true);    // +
        dialogText.text = dialog;     // +
    }
}
	private void OnTriggerExit2D(Collider2D other) {
    if (other.CompareTag("Player")) {
        playerInRange = false;
        dialogBox.SetActive(false);    // +
        dialogText.text = dialog;     // +
    }
}
}

