using UnityEngine;
using Zenject;

namespace RotatableObjects
{
    public abstract class RotatableObject : MonoBehaviour, IBarrel
    {
        private IRotator rotator;
        [SerializeField] protected float maxRotationZ;
        [SerializeField] protected float minRotationZ; 
        [SerializeField] protected float rotationSpeed;

        public Vector3 CurrentRotation { get; private set; }

        [Inject]
        private void Construct(IRotator rotator)
        {
            this.rotator = rotator;
        }        
        
        public virtual void RotateTowards(Vector2 targetPoint)
        {
            Vector2 direction = (targetPoint - (Vector2)transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            angle = Mathf.Clamp(angle, minRotationZ, maxRotationZ);

            Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle);
            Vector3 targetEulerAngles = targetRotation.eulerAngles;

            rotator.Rotate(transform, targetEulerAngles, rotationSpeed); 
            CurrentRotation = direction;
        }
    }
}
