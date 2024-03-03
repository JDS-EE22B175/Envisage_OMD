using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BouncingCode : MonoBehaviour
{
    [SerializeField] float startingPoint;
    [SerializeField] float oscillateVelocity;
    public float maxDisplacement;
    public float distanceMoved;
    float initialYPos;
    RectTransform rectTransform;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        initialYPos = rectTransform.position.y;
        distanceMoved = initialYPos + startingPoint % maxDisplacement;
    }

    // Update is called once per frame
    void Update()
    {
        distanceMoved += oscillateVelocity * Time.deltaTime;

        rectTransform.position = new Vector3(rectTransform.position.x, distanceMoved, rectTransform.position.z);
        if (Mathf.Abs(initialYPos - distanceMoved) > maxDisplacement) oscillateVelocity = -oscillateVelocity;
    }
}
