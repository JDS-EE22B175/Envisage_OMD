using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioInteractable : MonoBehaviour, IInteractable
{
    AudioSource audioSource;
    [SerializeField] float audioLength;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayerInteract.isinteracting = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Interact(Transform interactorTransform)
    {
        audioSource.enabled = true;

        PlayerMovement.canMove = false;
        PlayerInteract.isinteracting = true;
        StartCoroutine(ListenToAudio(interactorTransform));


    }

    IEnumerator ListenToAudio(Transform interactorTransform)
    {
        yield return new WaitForSeconds(audioLength);
        audioSource.enabled = false;

        PlayerMovement.canMove = true;
        PlayerInteract.isinteracting = false;
    }
    public string GetInteractText()
    {
        return "Listen To The " + gameObject.name;
    }
    public Transform GetTransform()
    {
        return transform;
    }
}
