using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tornado4.Player
{
    public class PlayerFPSLook : MonoBehaviour
    {
        public float mouseSensitivity = 100f;
        public Transform playerBody;
        public float xRotation = 0f;
    
        void Start()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        // Update is called once per frame
        void Update()
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            playerBody.Rotate(Vector3.up * mouseX);
        
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
            xRotation = xRotation - mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        }
    }
}

