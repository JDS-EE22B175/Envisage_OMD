using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class TimeLoop : MonoBehaviour
{
    public static float loopDuration = 90f;
    int startTime = 6;
    int endTime = 9;
    public static float timeLeft = loopDuration;
    public static float secondsElapsed = 0f;
    public static float hourDuration;
    public static int currentHour;
    public static string text;
    [SerializeField] GameObject virtualCamera;
    [SerializeField] GameObject video;
    public float secondsView;

    public AudioSource bgm;
    [SerializeField] PlayerMovement playerMovement;
    public float videoTime = 14f;
    public static float totalTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TimeLoopCoroutine());
        currentHour = startTime;
        hourDuration = loopDuration / (endTime - startTime);
    }

    // Update is called once per frame
    void Update()
    {
        secondsView = secondsElapsed;
        secondsElapsed += Time.deltaTime;
        currentHour = startTime + (int)(secondsElapsed / hourDuration);
        text = currentHour.ToString() + " : " + Mathf.RoundToInt(secondsElapsed % hourDuration).ToString("D2");
        timeLeft = loopDuration - secondsElapsed;
        totalTime += Time.deltaTime;
    }

    IEnumerator TimeLoopCoroutine()
    {
        yield return new WaitForSeconds(loopDuration);

        bgm.enabled = false;

        SceneTransitions.FadeIn();
        yield return new WaitForSeconds(1f);


        GameObject currentVideo = Instantiate(video);
        currentVideo.SetActive(true);

        if (TimeMachine.puzzlesCompleted == PuzzleScreen.totalPuzzleCount || totalTime >= 300f)
        {
            StartCoroutine(SceneTransitions.SceneChange("EndScene") );
        }

        yield return new WaitForSeconds(videoTime);

        currentVideo.SetActive(false);
        Destroy(currentVideo);

        SceneManager.LoadScene("Auditorium");
        bgm.enabled = true;
        PlayerInteract.hasPendant = false;
        TimeMachine.puzzlesCompleted = 0;

        playerMovement.GetComponent<Animator>().Play("Push Up To Idle");

        
        secondsElapsed = 0f;
        Destroy(virtualCamera);
        Destroy(gameObject);

    }
}
