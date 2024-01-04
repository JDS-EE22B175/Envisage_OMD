using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueInteractable : MonoBehaviour, IInteractable
{

    [SerializeField] GameObject dialogueBox;
    [SerializeField] List<string> dialogues;
    public float textSpeed = DialogueManager.defaultTextSpeed;
    float waitTime = 1f;
    private void Start()
    {
        PlayerInteract.isinteracting = false;
        waitTime = 1f * dialogues.Count;
    }
    public void Interact(Transform interactorTransform)
    {
        dialogueBox.SetActive(true);
        StartCoroutine(dialogueBox.GetComponent<DialogueManager>().ShowDialogueText(dialogues, textSpeed));
 
    }

    IEnumerator talkWait()
    {
       yield return new WaitForSeconds(waitTime);
    }

    public string GetInteractText()
    {
        return "Look At " + gameObject.name;
    }

    public Transform GetTransform()
    {
        return transform;
    }
}
