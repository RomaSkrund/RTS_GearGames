using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class StandaloneInputManager : MonoBehaviour
    {
        private void Update()
        {
            InputModel.IsRightRotationPressed = Input.GetKey(KeyCode.E);
            InputModel.IsLeftRotationPressed = Input.GetKey(KeyCode.Q);
        }
    }
}