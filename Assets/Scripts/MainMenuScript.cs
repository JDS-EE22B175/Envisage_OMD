using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    AudioSource audioSource1;
    [SerializeField] AudioSource audioSource2;
    [SerializeField] Animator overlayAnimation;
    [SerializeField] GameObject optionsOverlay;
    // Start is called before the first frame update
    void Start()
    {
        audioSource1 = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButton()
    {
        StartCoroutine(PlaySceneChange());
        audioSource2.Play();
    }

    public void ExitApp()
    {
        Application.Quit();
    }

    public void PointerEnter(GameObject gameObj)
    {
        gameObj.transform.localScale = new Vector2(2.2f, 2.2f);
        audioSource1.Play();
    }

    public void PointerExit(GameObject gameObj)
    {
        gameObj.transform.localScale = Vector2.one * 2;
    }

    IEnumerator PlaySceneChange()
    {
        overlayAnimation.enabled = true;
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("NarrationScene");
    }

    public void OptionsButton()
    {
        audioSource2.Play();
        optionsOverlay.SetActive(true);
    }

    public void closeSettings()
    {
        optionsOverlay.SetActive(false);
    }
}
