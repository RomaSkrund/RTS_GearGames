using UnityEngine;
using DefaultNamespace;

public class RotationCamera : MonoBehaviour
{
    private bool _pressedRightButton;
    private bool _pressedLeftButton;
    public void OnDownRight()
    {
        _pressedRightButton = true;
    }

    public void OnUpRight()
    {
        _pressedRightButton = false;
    }
    
    public void OnDownLeft()
    {
        _pressedLeftButton = true;
    }

    public void OnUpLeft()
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
            InputModel.IsLeftRotationPressed = true;
        }
    }
}
