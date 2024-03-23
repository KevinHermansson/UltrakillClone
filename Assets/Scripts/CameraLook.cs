using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    public float smoothTime = 0.1f;

    float xRotation = 0f;
    float currentMouseX = 0f;
    float currentMouseY = 0f;
    float mouseXVelocity = 0f;
    float mouseYVelocity = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        currentMouseX = Mathf.SmoothDamp(currentMouseX, mouseX, ref mouseXVelocity, smoothTime);
        currentMouseY = Mathf.SmoothDamp(currentMouseY, mouseY, ref mouseYVelocity, smoothTime);

        xRotation -= currentMouseY * Time.deltaTime;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * currentMouseX * Time.deltaTime);
    }
}
