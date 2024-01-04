using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    // Start is called before the first frame update
    public static SceneTransitions instance;
    static Animator transitionAnimator;
    void Awake()
    {
        

        transitionAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static IEnumerator SceneChange(string sceneToLoad)
    {
        transitionAnimator.SetTrigger("End");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(sceneToLoad);
        transitionAnimator.SetTrigger("Start");
    }


    public static void FadeIn()
    {
        transitionAnimator.SetTrigger("End");
    }


}
