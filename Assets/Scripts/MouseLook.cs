using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivityY = 300f;
    public float mouseSensitivityX = 200f;

    public Transform playerBody;
    float xRotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivityX * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivityY * Time.deltaTime;

        playerBody.Rotate(Vector3.up * mouseX, Space.Self);
        xRotation -= mouseY;
        
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        xRotation = Mathf.Clamp(xRotation, - 15f, 15f);
    }
}
