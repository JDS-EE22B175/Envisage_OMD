using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class slideshow1 : MonoBehaviour
{

    public Texture[] imageArray;
    private int currentImage;

    float deltaTime = 0.0f;

    public float timer1 = 5.0f;
    public float timer1Remaining = 5.0f;
    public bool timer1IsRunning = true;
    public string timer1Text;

    // added ergonomic functionality,
    // escape key to exit,
    // p key or right mouse to pause the timer1
    // left mouse or spacebar to skip to next slide

    void OnGUI()
    {

        int w = Screen.width, h = Screen.height;

        Rect imageRect = new Rect(0, 0, Screen.width, Screen.height);

        //dont need to make button transparent but would be cool to know how to.
        //Rect buttonRect = new Rect(0, Screen.height - Screen.height / 10, Screen.width, Screen.height / 10);

        //GUI.Label(imageRect, imageArray[currentImage]);
        //Draw texture seems more elegant
        GUI.DrawTexture(imageRect, imageArray[currentImage]);

        //if(GUI.Button(buttonRect, "Next"))
        //currentImage++;

        if (currentImage >= imageArray.Length)
            currentImage = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentImage = 0;
        bool timer1IsRunning = true;
        timer1Remaining = timer1;
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = false;
        Screen.lockCursor = true;

        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;

        if (Input.GetKey(KeyCode.Escape))
        {
#if UNITY_EDITOR
            if (EditorApplication.isPlaying)
            {
                EditorApplication.isPlaying = false;
            }

#else
                Application.Quit();
#endif
        }

        if (Input.GetMouseButtonDown(0))
        {
            UnityEngine.Debug.Log("Pressed primary button.");
            currentImage++;

            if (currentImage >= imageArray.Length)
                currentImage = 0;
        }


        if (Input.GetKey(KeyCode.Space))
        {
            UnityEngine.Debug.Log("Pressed space bar.");
            currentImage++;

            if (currentImage >= imageArray.Length)
                currentImage = 0;
        }

        if (Input.GetMouseButtonDown(1))
        {
            UnityEngine.Debug.Log("Pressed secondary button.");
            timer1IsRunning = !timer1IsRunning;
        }

        if (Input.GetKey(KeyCode.P))
        {
            //ispaused = !ispaused;
            timer1IsRunning = !timer1IsRunning;
        }

        if (timer1IsRunning)

        {
            if (timer1Remaining > 0)
            {
                timer1Remaining -= Time.deltaTime;

            }

            else
            {
                UnityEngine.Debug.Log("Time has run out!");

                currentImage++;

                if (currentImage >= imageArray.Length)
                    currentImage = 0;

                timer1Remaining = timer1;
            }
        }

    }
}
