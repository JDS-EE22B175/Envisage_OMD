using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivityY = 300f;
    public float mouseSensitivityX = 200f;

    public int imageWidth = 2048;
    public bool saveAsJPEG = false;

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

        if (Input.GetKeyDown(KeyCode.P))
        {
            byte[] bytes = I360Render.Capture(imageWidth, saveAsJPEG);
            if (bytes != null)
            {
                string path = Path.Combine(Application.persistentDataPath, "360render" + (saveAsJPEG ? ".jpeg" : ".png"));
                File.WriteAllBytes(path, bytes);
                Debug.Log("360 render saved to " + path);
            }
        }
    }
}
