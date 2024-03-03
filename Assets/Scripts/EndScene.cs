using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class EndScene : MonoBehaviour
{
    [SerializeField] GameObject overlayBox;
    public float waitTime = 10f;
    [SerializeField] string[] commonDisplayText;
    [SerializeField] string[] winDisplayText;
    [SerializeField] string[] altDisplayText;

    string[] text;

    [SerializeField] TextMeshProUGUI narrationText;

    int currentImage = 0;
    float timeElapsedForThisImage = 0f;

    int dialogueCount;


    // Start is called before the first frame update
    void Start()
    {
        if(NPCInteractable.choseCorrect)
        {
            dialogueCount = commonDisplayText.Length + winDisplayText.Length;
            text = commonDisplayText.Concat(winDisplayText).ToArray();
        }
        else
        {
            dialogueCount = commonDisplayText.Length + altDisplayText.Length;
            text = commonDisplayText.Concat(altDisplayText).ToArray();
        }
        narrationText.text = text[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            NextImage();
        }

        timeElapsedForThisImage += Time.deltaTime;

        if (timeElapsedForThisImage >= waitTime)
        {
            NextImage();
        }
    }

    IEnumerator GameOver()
    {
        overlayBox.SetActive(false);
        narrationText.enabled = false;
        yield return new WaitForSeconds(7f);
        SceneManager.LoadScene("MainScreen");
    }

    void NextImage()
    {
        currentImage++;
        timeElapsedForThisImage = 0f;

        if (currentImage != dialogueCount)
        {
            narrationText.text = text[currentImage];
        }

        else
        {
            StartCoroutine(GameOver());
        }
    }
}
