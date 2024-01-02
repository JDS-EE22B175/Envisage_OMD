using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PendantInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject player;
    public float pickUpTime = 3f;
    private PlayerInteract playerInteract;
    [SerializeField] Image pendantUI;
    // Start is called before the first frame update
    void Start()
    {
        playerInteract = player.GetComponent<PlayerInteract>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Interact(Transform interactorTransform)
    {
        playerInteract.hasPendant = true;
        gameObject.GetComponent<AudioSource>().Play();
        StartCoroutine(PickUp());
        
    }

    IEnumerator PickUp()
    {
        pendantUI.color = new Color(255, 255, 255, 255);
        yield return new WaitForSeconds(pickUpTime);
        PlayerInteract.isinteracting = false;
        PlayerInteract.closestInteractable = null;
        Destroy(gameObject);
    }
    public string GetInteractText()
    {
        return "Pick Up The " + gameObject.name;
    }
    public Transform GetTransform()
    {
        return transform;
    }
}
