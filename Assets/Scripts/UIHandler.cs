using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private GameObject containerObject;
    [SerializeField] private PlayerInteract playerInteract;
    [SerializeField] private TextMeshProUGUI interactText;

    private void Update()
    {
        if (playerInteract.GetInteractable() != null) 
        {
            Show(playerInteract.GetInteractable());
        }
        else Hide();
    }
    private void Show(IInteractable interactable)
    {
        containerObject.SetActive(true);
        interactText.text = interactable.GetInteractText();
    }

    private void Hide()
    {
        containerObject.SetActive(false);
    }
}
