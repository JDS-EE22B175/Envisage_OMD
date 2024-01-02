using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public float interactRange = 1.5f;
    public bool isinteracting = false;
    public static IInteractable interactable;
    public bool hasPendant = false;
    public float interactBufferTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            interactable = GetInteractable();
            if(interactable != null && !isinteracting)
            {
                interactable.Interact(transform);
                isinteracting = true;
            }
        }

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


        IInteractable closestInteractable = null;
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
