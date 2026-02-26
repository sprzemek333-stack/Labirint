using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControrel : MonoBehaviour
{
    [SerializeField]
    private float mouseSensytivity = 100f;
    private Transform playerBody;
    private float xRotaction = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerBody = transform.parent;
    }
    void Update()
    {
        CameraRotation();
    }
    void CameraRotation()
    { 
        float mouseX = Input.GetAxis("Mouse X") * mouseSensytivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensytivity * Time.deltaTime;

        xRotaction -= mouseY;
        xRotaction = Mathf.Clamp(xRotaction, -90f, 80);

        transform.localRotation = Quaternion.Euler(xRotaction, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}