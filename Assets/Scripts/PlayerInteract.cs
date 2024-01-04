using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public float interactRange = 1.5f;
    public static bool isinteracting = false;
    public bool isInteractingView = false;
    static IInteractable interactable = null;
    public static IInteractable closestInteractable = null;
    public static bool hasPendant = false;
    //public float interactBufferTime = 1f;
    //public bool canInteract = true;
    //float timeSinceInteractionStarted = 0f;

    public static bool pausedGame = false;

    public static bool talkedToDeAdly = false;

    [SerializeField] AudioSource interactSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isInteractingView = isinteracting;

        GetInteractable();

        if (Input.GetKeyDown(KeyCode.E))
        {
            interactable = GetInteractable();
            if(interactable != null && !isinteracting) //&& canInteract
            {
                interactable.Interact(transform);
                interactSound.Play();
                isinteracting = true;
                //canInteract = false;
            }
        }

        /*
        if(!canInteract)
        {
            timeSinceInteractionStarted += Time.deltaTime;
        }

        if(timeSinceInteractionStarted >= interactBufferTime)
        {
            timeSinceInteractionStarted = 0f;
            canInteract = true;
        }
        */

    }

    public IInteractable GetInteractable()
    {
        List<IInteractable> interactableList = new List<IInteractable>();

        Collider[] colliders = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out IInteractable interactable))
            {
                interactableList.Add(interactable);
            }
        }


        closestInteractable = null;
        foreach(IInteractable interactable in interactableList)
        {
            if (closestInteractable == null)
                closestInteractable = interactable;
            else
            {
                if ((transform.position - interactable.GetTransform().position).sqrMagnitude 
                    < (transform.position - closestInteractable.GetTransform().position).sqrMagnitude)
                {
                    closestInteractable = interactable;
                }
            }
 
        }

        if(isinteracting)
        {
            return null;
        }

        return closestInteractable;
    }
}
