using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class TimeLoop : MonoBehaviour
{
    public static float loopDuration = 60f;
    [SerializeField] Slider timeSlider;
    int startTime = 6;
    int endTime = 12;
    public static float timeLeft = loopDuration;
    public static float secondsElapsed = 0f;
    public static float hourDuration;
    public static int currentHour;
    public static string text;
    [SerializeField] GameObject virtualCamera;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TimeLoopCoroutine());
        currentHour = startTime;
        //secondsElapsed = 0f;
        hourDuration = loopDuration / (endTime - startTime);
    }

    // Update is called once per frame
    void Update()
    {
        secondsElapsed += Time.deltaTime;
        currentHour = startTime + (int)(secondsElapsed / hourDuration);
        text = currentHour.ToString() + " : " + Mathf.RoundToInt(secondsElapsed % hourDuration).ToString("D2");
        timeLeft = loopDuration - secondsElapsed;
    }

    IEnumerator TimeLoopCoroutine()
    {
        yield return new WaitForSeconds(loopDuration);
        
        SceneManager.LoadScene("Auditorium");
        Debug.Log("Loop Done");
        secondsElapsed = 0f;
        Destroy(virtualCamera);
        Destroy(gameObject);
    }
}
