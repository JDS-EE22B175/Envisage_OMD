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

    public float[] timePerImage;
    float timeElapsedForThisImage = 0f;
    int currentImage = 0;
    // Start is called before the first frame update
    void Start()
    {
        imageArray[0].SetActive(true);
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

        timeElapsedForThisImage += Time.deltaTime;

        if (timeElapsedForThisImage >= timePerImage[currentImage])
        {
            currentImage++;
            timeElapsedForThisImage = 0f;
            CloseAllImages();
            if(currentImage != imageArray.Length) 
                imageArray[currentImage].SetActive(true);
            else
            {
                SceneManager.LoadScene("Auditorium");
            }
        }
    }
}
