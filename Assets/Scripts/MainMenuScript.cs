using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("Auditorium");
    }

    public void ExitApp()
    {
        Application.Quit();
    }

    public void PointerEnter(GameObject gameObj)
    {
        gameObj.transform.localScale = new Vector2(1.1f, 1.1f);
        audioSource.Play();
    }

    public void PointerExit(GameObject gameObj)
    {
        gameObj.transform.localScale = Vector2.one;
    }
}
