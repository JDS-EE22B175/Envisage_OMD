using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : MonoBehaviour, IInteractable
{
    Animator animator;
    int interactHash;
    [SerializeField] GameObject dialogueBox;
    [SerializeField] List<string> dialogues;
    private void Start()
    {
        animator = GetComponent<Animator>();
        interactHash = Animator.StringToHash("Talking");
    }
    public void Interact(Transform interactorTransform)
    {
        dialogueBox.SetActive(true);
        StartCoroutine(dialogueBox.GetComponent<DialogueManager>().ShowDialogueText(dialogues));
        if (animator != null)
        {
            animator.SetBool(interactHash, true);
            StartCoroutine(talkWait());
        }
    }

    IEnumerator talkWait()
    {
        yield return new WaitForSeconds(0.5f);
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
