using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private float rotateSpeed = 40.0f; 
    [SerializeField] private float moveSpeed = 25.0f; 
    [SerializeField] private float zoomSpeed = 15.0f;
    [SerializeField] private FixedJoystick joystick;
    
    
    private void Update()
    {
        //keyboard movement
        float horizontal = Input.GetAxis("Horizontal"); 
        float vertical = Input.GetAxis("Vertical"); 

        float rotateDirection = 0f; 
        if (InputModel.IsLeftRotationPressed)
        {
            rotateDirection = -1f; 
        }
        else if (InputModel.IsRightRotationPressed)
        {
            rotateDirection = 1f;
        }

        transform.Rotate(Vector3.up * rotateSpeed *
                         Time.deltaTime * rotateDirection, Space.World);
        
        transform.Translate(new Vector3(horizontal, 0, vertical) * 
            Time.deltaTime * moveSpeed, Space.Self);

        transform.position += transform.up * zoomSpeed *
            Input.GetAxis("Mouse ScrollWheel");

        transform.position = new Vector3(
            transform.position.x,
            Mathf.Clamp(transform.position.y, -25f, 25f),
            transform.position.z);
        
        //phone movement
        transform.Translate(new Vector3
            (joystick.Horizontal * moveSpeed,0,joystick.Vertical * moveSpeed) * Time.deltaTime);
    }
}
