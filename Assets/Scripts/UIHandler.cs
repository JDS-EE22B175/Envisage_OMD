using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private GameObject containerObject;
    [SerializeField] private TextMeshProUGUI interactText;
    [SerializeField] Slider timeSlider;
    [SerializeField] TextMeshProUGUI time;

    private void Update()
    {
        if (PlayerInteract.closestInteractable != null) 
        {
            Show(PlayerInteract.closestInteractable);
        }
        else Hide();

        if(PlayerInteract.isinteracting == true)
        {
            Hide();
        }

        time.text = TimeLoop.text;
        timeSlider.value = TimeLoop.timeLeft / TimeLoop.loopDuration;
    }
    private void Show(IInteractable interactable)
    {
        if (PlayerInteract.isinteracting == false)
        {
            containerObject.SetActive(true);
            interactText.text = interactable.GetInteractText();
        }
    }

    private void Hide()
    {
        containerObject.SetActive(false);
    }

}
