using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera playerCamera;
    public float lookSpeed = 2f;
    public float lookXlimit = 45f;
    private float rotationX = 0;
    private float rotationY = 0; // Added for horizontal rotation tracking

    void Start()
    {
        if (playerCamera == null)
        {
            playerCamera = GetComponent<Camera>();
        }

        if (playerCamera == null)
        {
            Debug.LogError("CameraController: No camera component found!");
            return;
        }

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (playerCamera != null)
        {
            // Handle vertical camera rotation
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXlimit, lookXlimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0);

            // Update horizontal rotation without affecting the player's transform
            rotationY += Input.GetAxis("Mouse X") * lookSpeed;
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0);
        }
    }
}