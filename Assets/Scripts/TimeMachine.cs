using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeMachine : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject TimeMachineUI;
    [SerializeField] PlayerInteract playerInteract;
    [SerializeField] GameObject interactionUIContainer;
    [SerializeField] GameObject inputFields;
    [SerializeField] GameObject puzzleButtons;
    [SerializeField] GameObject VirtualCamera;
    public static int puzzlesCompleted = 0;
    [SerializeField] GameObject pendant;


    public void Interact(Transform interactorTransform)
    {
        TimeMachineUI.SetActive(true);
        PlayerMovement.canMove = false;
        VirtualCamera.GetComponent<MouseLook>().enabled = false;
        playerInteract.enabled = false;
        interactionUIContainer.SetActive(false);
        inputFields.SetActive(false);
        puzzleButtons.SetActive(true);
        pendant.SetActive(false);
        Cursor.lockState = CursorLockMode.None;

    }
    public string GetInteractText()
    {
        return ("Interact with the " + gameObject.name);
    }
    public Transform GetTransform()
    {
        return transform;
    }

    public void CloseTimeMachineUI()
    {
        Cursor.lockState = CursorLockMode.Locked;
        TimeMachineUI.SetActive(false);
        PlayerMovement.canMove = true;
        VirtualCamera.GetComponent<MouseLook>().enabled = true;
        playerInteract.enabled = true;
        PlayerInteract.isinteracting = false;
        interactionUIContainer.SetActive(true);
        pendant.SetActive (true);
        
    }
    // Start is called before the first frame update
    void Start()
    {
        PlayerInteract.isinteracting = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
