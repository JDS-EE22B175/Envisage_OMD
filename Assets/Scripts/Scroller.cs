using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour
{
    [SerializeField] RawImage image;
    [SerializeField] float rotateSpeed;

    // Update is called once per frame
    void Update()
    {
        image.uvRect = new Rect(image.uvRect.position + new Vector2(rotateSpeed, 0) * Time.deltaTime, image.uvRect.size);
    }
}
