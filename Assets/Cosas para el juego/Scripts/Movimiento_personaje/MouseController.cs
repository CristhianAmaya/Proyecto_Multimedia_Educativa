using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public float mouseSpeed = 300f;
    public Transform cam;
    float mouseX;
    float mouseY;
    float yReal = 0.0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSpeed * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSpeed * Time.deltaTime;
        yReal -= mouseY;
        
        yReal = Mathf.Clamp(yReal, -90f, 90f);
        cam.localRotation = Quaternion.Euler(yReal, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}
