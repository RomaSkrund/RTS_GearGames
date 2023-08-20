using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DefaultNamespace;

public class RotationCamera : MonoBehaviour
{
    private bool pressedRightButton = false;
    private bool pressedLeftButton = false;
    public void onDownRight()
    {
        pressedRightButton = true;
    }

    public void onUpRight()
    {
        pressedRightButton = false;
    }
    
    public void onDownLeft()
    {
        pressedLeftButton = true;
    }

    public void onUpLeft()
    {
        pressedLeftButton = false;
    }

    private void Update()
    {
        if (pressedRightButton)
        {
            InputModel.IsRightRotationPressed = true;
        }

        if (pressedLeftButton)
        {
            InputModel.IsLeftRotationPressed =  true;
        }
    }
}
