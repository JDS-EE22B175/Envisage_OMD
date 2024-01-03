using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : MonoBehaviour, IInteractable
{
    Animator animator;
    int interactHash;
    [SerializeField] GameObject dialogueBox;
    [SerializeField] List<string> dialogues;
    [SerializeField] float rotationOffset = 0f;
    public float textSpeed = DialogueManager.defaultTextSpeed;
    float waitTime = 1f;
    private void Start()
    {
        animator = GetComponent<Animator>();
        interactHash = Animator.StringToHash("Talking");
        PlayerInteract.isinteracting = false;
        waitTime = 1f * dialogues.Count;
    }
    public void Interact(Transform interactorTransform)
    {
        if(gameObject.name == "Olivia - The Lab Assistant")
        {
            PlayerInteract.talkedToOlivia = true;
        }
        dialogueBox.SetActive(true);
        StartCoroutine(dialogueBox.GetComponent<DialogueManager>().ShowDialogueText(dialogues, textSpeed));
        if (animator != null)
        {
            animator.SetBool(interactHash, true);
            StartCoroutine(talkWait());
        }
    }

    IEnumerator talkWait()
    {
        transform.Rotate(Vector3.up * rotationOffset);
        yield return new WaitForSeconds(waitTime);
        transform.Rotate(Vector3.down * rotationOffset);
        animator.SetBool(interactHash, false);
    }

    public string GetInteractText()
    {
        return "Talk with " + gameObject.name;
    }

    public Transform GetTransform()
    {
        return transform;
    }
}
