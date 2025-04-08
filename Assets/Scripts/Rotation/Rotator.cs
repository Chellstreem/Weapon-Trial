using UnityEngine;
using System.Collections;

public class Rotator : IRotator
{
    private readonly ICoroutineRunner runner;
    private Coroutine rotationCoroutine;

    public Rotator(ICoroutineRunner runner)
    {
        this.runner = runner;
    }    
    
    public void Rotate(Transform objTransform, Vector3 targetRotation, float speed)
    {
        
        if (rotationCoroutine != null) runner.StopCor(rotationCoroutine);        
        rotationCoroutine = runner.StartCor(RotateToCoroutine(objTransform, targetRotation, speed));
    }

    private IEnumerator RotateToCoroutine(Transform objTransform, Vector3 targetEulerAngles, float speed)
    {
        Quaternion targetRotation = Quaternion.Euler(targetEulerAngles);
       
        while (Quaternion.Angle(objTransform.rotation, targetRotation) > 0.1f)
        {            
            objTransform.rotation = Quaternion.RotateTowards(
                objTransform.rotation,
                targetRotation,
                speed * Time.deltaTime);

            yield return null;
        }
        
        objTransform.rotation = targetRotation;
        rotationCoroutine = null;
    }
}