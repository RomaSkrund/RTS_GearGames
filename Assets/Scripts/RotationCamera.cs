using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DefaultNamespace;

public class RotationCamera : MonoBehaviour
{
    private bool _pressedRightButton = false;
    private bool _pressedLeftButton = false;
    public void onDownRight()
    {
        _pressedRightButton = true;
    }

    public void onUpRight()
    {
        _pressedRightButton = false;
    }
    
    public void onDownLeft()
    {
        _pressedLeftButton = true;
    }

    public void onUpLeft()
    {
        _pressedLeftButton = false;
    }

    private void Update()
    {
        if (_pressedRightButton)
        {
            InputModel.IsRightRotationPressed = true;
        }

        if (_pressedLeftButton)
        {
            InputModel.IsLeftRotationPressed =  true;
        }
    }
}
