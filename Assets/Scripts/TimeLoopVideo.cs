using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TimeLoopVideo : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

}
