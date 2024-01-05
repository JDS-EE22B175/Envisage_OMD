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
    public Image pendantUI;

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
        timeSlider.value = 1 - TimeLoop.timeLeft / TimeLoop.loopDuration;
    }
    private void Show(IInteractable interactable)
    {
        if (PlayerInteract.isinteracting == false)
        {
            containerObject.SetActive(true);
            interactText.text = interactable.GetInteractText();
        }
        else
        {
            if(PlayerInteract.hasPendant)
            {
                pendantUI.color = new Color(255, 255, 255, 255);
            }
        }
    }

    private void Hide()
    {
        containerObject.SetActive(false);
    }

}
