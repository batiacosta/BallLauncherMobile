using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallHandler : MonoBehaviour
{

    private Camera _mainCamera;
    
    void Start()
    {
        _mainCamera = Camera.main;
    }
    
    void Update()
    {
        if (!Touchscreen.current.primaryTouch.press.isPressed)
        {
            return;
        }
    }
}
