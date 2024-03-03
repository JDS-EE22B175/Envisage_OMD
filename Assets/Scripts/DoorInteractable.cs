using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteractable : MonoBehaviour, IInteractable
{

    [SerializeField] string sceneToLoad;
    [SerializeField] GameObject player;
    GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        canvas = GameObject.FindGameObjectWithTag("Canvas");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Interact(Transform interactorTransform)
    {
        StartCoroutine(SceneTransitions.SceneChange(sceneToLoad));
        DontDestroyOnLoad(player);
        DontDestroyOnLoad(canvas);
        PlayerInteract.isinteracting = false;
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
