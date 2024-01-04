using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : MonoBehaviour, IInteractable
{
    Animator animator;
    int interactHash;

    [SerializeField] GameObject dialogueBox;
    [SerializeField] List<string> dialogues;
    [SerializeField] List<string> adlyCaughtDialogues;
    [SerializeField] float rotationOffset = 0f;
    public float textSpeed = DialogueManager.defaultTextSpeed;

    [SerializeField] AudioSource finalChatAudio = null;

    [SerializeField] GameObject adlyButtons;
    public bool choseCorrect = false;
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
        if(gameObject.name == "Dr.Kevin de Adly" && TimeMachine.puzzlesCompleted == 3)
        {
            PlayerInteract.talkedToDeAdly = true;
            dialogues.Clear();
            dialogues = adlyCaughtDialogues;
            animator.SetTrigger("Caught");
            finalChatAudio.enabled = true;
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

        if(PlayerInteract.talkedToDeAdly)
        {
            StartCoroutine(SceneTransitions.SceneChange("EndScene"));
        }
    }

    public string GetInteractText()
    {
        return "Talk with " + gameObject.name;
    }

    public Transform GetTransform()
    {
        return transform;
    }

    IEnumerator finalTalk()
    {
        adlyButtons.SetActive(true);
        yield return new WaitForSeconds(10f);
        adlyButtons.SetActive(false);
    }

    public void adlyChoice()
    {
        choseCorrect = false;
        adlyButtons.SetActive(false);
    }

    public void lethalChoice()
    {
        choseCorrect = true;
        adlyButtons.SetActive(false);
    }
}
