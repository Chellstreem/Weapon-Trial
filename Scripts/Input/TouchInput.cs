using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchInput : IInput
{
    private readonly Camera mainCamera;
    private readonly Controls controls;
    
    public event Action<Vector2> OnTouchStarted;
    public event Action<float> OnTouchReleased;

    private float touchStartTime;
    private float touchDuration;

    public TouchInput(Camera mainCamera)
    {
        this.mainCamera = mainCamera;

        controls = new Controls();

        controls.Enable();
        controls.Gameplay.TouchPosition.performed += InvokeOnTouchStarted;
        controls.Gameplay.Press.canceled += InvokeTouchReleased;
    }

    private void InvokeOnTouchStarted(InputAction.CallbackContext context)
    {
        touchStartTime = (float)context.time;
        Vector2 screenPosition = context.ReadValue<Vector2>();
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(screenPosition);
        worldPosition.z = 0f;        

        OnTouchStarted?.Invoke(worldPosition);        
    }

    private void InvokeTouchReleased(InputAction.CallbackContext context)
    {
        touchDuration = (float)context.time - touchStartTime;
        OnTouchReleased?.Invoke(touchDuration);              
    }    

    public void Enable() => controls.Enable();
   
    public void Disable() => controls.Disable();
}
