using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using Cinemachine;

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

    void Start()
    {
        PlayerInteract.isinteracting = false;
        GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerInteract = player.GetComponent<PlayerInteract>();
        VirtualCamera = player.GetComponentInChildren<CinemachineVirtualCamera>().gameObject;
        Debug.Log(canvas);
        Transform[] canvasChildren = canvas.GetComponentsInChildren<Transform>();
        foreach (Transform child in canvasChildren)
        {
            if (child.CompareTag("UIContainer"))
            {
                // Found the child object!
                interactionUIContainer = child.gameObject;
            }
        }
        Debug.Log(interactionUIContainer);

    }
    public void Interact(Transform interactorTransform)
    {
        TimeMachineUI.SetActive(true);
        PlayerMovement.canMove = false;
        
        playerInteract.enabled = false;
        Debug.Log(interactionUIContainer);
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
    

    // Update is called once per frame
    void Update()
    {

    }
}
