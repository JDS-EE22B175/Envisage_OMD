using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NarrationScript : MonoBehaviour
{
    [SerializeField] GameObject[] imageArray;
    [SerializeField] TextMeshProUGUI narrationText;
    [SerializeField] string[] text;

    public float[] timePerImage;
    float timeElapsedForThisImage = 0f;
    int currentImage = 0;
    // Start is called before the first frame update
    void Start()
    {
        imageArray[0].SetActive(true);
        narrationText.text = text[0];
    }

    void CloseAllImages()
    {
        for (int i = 0; i < imageArray.Length; i++)
        {
            imageArray[i].SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            NextImage();
        }

        timeElapsedForThisImage += Time.deltaTime;

        if (timeElapsedForThisImage >= timePerImage[currentImage])
        {
            NextImage();
        }
    }

    void NextImage()
    {
        currentImage++;
        timeElapsedForThisImage = 0f;
        CloseAllImages();
        if (currentImage != imageArray.Length)
        {
            imageArray[currentImage].SetActive(true);
            narrationText.text = text[currentImage];
        }

        else
        {
            SceneTransitions.SceneChange("Auditorium");
        }
    }
}
