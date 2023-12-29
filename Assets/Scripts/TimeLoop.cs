using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class TimeLoop : MonoBehaviour
{
    public static float loopDuration = 120f;
    [SerializeField] Slider timeSlider;
    int startTime = 6;
    int endTime = 12;
    public static float timeLeft = loopDuration;
    public static float secondsElapsed = 0f;
    float hourDuration = 60f;
    int currentHour;
    [SerializeField] TextMeshProUGUI time;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TimeLoopCoroutine());
        currentHour = startTime;
        secondsElapsed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        secondsElapsed += Time.deltaTime;
        currentHour = startTime + (int)(secondsElapsed / hourDuration);
        time.text = currentHour.ToString() + " : " + Mathf.RoundToInt(secondsElapsed % hourDuration).ToString("D2");
        timeLeft = loopDuration - secondsElapsed;
        timeSlider.value = timeLeft/loopDuration;
    }

    IEnumerator TimeLoopCoroutine()
    {
        yield return new WaitForSeconds(loopDuration);
        SceneManager.LoadScene("Auditorium");
    }
}
