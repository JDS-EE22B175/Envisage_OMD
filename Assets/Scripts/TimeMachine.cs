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
    [SerializeField] GameObject player;
    [SerializeField] GameObject pauseButton;
    [SerializeField] GameObject backpack;
    public void Interact(Transform interactorTransform)
    {
        TimeMachineUI.SetActive(true);
        interactorTransform.gameObject.GetComponent<PlayerMovement>().canMove = false;
        VirtualCamera.GetComponent<MouseLook>().enabled = false;
        playerInteract.enabled = false;
        interactionUIContainer.SetActive(false);
        inputFields.SetActive(false);
        puzzleButtons.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        pauseButton.SetActive(false);
        backpack.SetActive(false);
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
        TimeMachineUI.SetActive(false);
        player.gameObject.GetComponent<PlayerMovement>().canMove = true;
        VirtualCamera.GetComponent<MouseLook>().enabled = true;
        playerInteract.enabled = true;
        playerInteract.isinteracting = false;
        interactionUIContainer.SetActive(true);
        pauseButton.SetActive(true);
        backpack.SetActive(true);

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
