using System;
using UnityEngine;

public interface IInput
{
    public event Action<Vector2> OnTouchStarted;
    public event Action<float> OnTouchReleased;
    public void Enable();
    public void Disable();
}
