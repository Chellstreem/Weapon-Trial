using UnityEngine;

public interface IRotator
{
    public void Rotate(Transform objTransform, Vector3 targetRotation, float speed);
}
