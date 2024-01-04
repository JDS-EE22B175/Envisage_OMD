using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class TimeLoop : MonoBehaviour
{
    public static float loopDuration = 90f;
    [SerializeField] Slider timeSlider;
    int startTime = 6;
    int endTime = 9;
    public static float timeLeft = loopDuration;
    public static float secondsElapsed = 0f;
    public static float hourDuration;
    public static int currentHour;
    public static string text;
    [SerializeField] GameObject virtualCamera;
    [SerializeField] GameObject video;

    [SerializeField] PlayerMovement playerMovement;
    public float videoTime = 14f;

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

        SceneTransitions.FadeIn();
        yield return new WaitForSeconds(2f);

        if (TimeMachine.puzzlesCompleted != 3)
        {
            video.SetActive(true);
            yield return new WaitForSeconds(videoTime);
            video.SetActive(false);
            SceneManager.LoadScene("Auditorium");

            playerMovement.GetComponent<Animator>().Play("Push Up To Idle");

            secondsElapsed = 0f;
            Destroy(virtualCamera);
            Destroy(gameObject);
        }

        else
        {
            SceneManager.LoadScene("EndScene");
        }
    }
}
