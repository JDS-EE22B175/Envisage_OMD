using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteractable : MonoBehaviour, IInteractable
{

    [SerializeField] string sceneToLoad;
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Interact(Transform interactorTransform)
    {
        PlayerInteract.isinteracting = false;
        Debug.Log("Loop Done");
        SceneManager.LoadScene(sceneToLoad);
        DontDestroyOnLoad(player);

    }
    public string GetInteractText()
    {
        return "Go To The " + sceneToLoad;
    }
    public Transform GetTransform()
    {
        return transform;
    }
}
