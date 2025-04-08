using UnityEngine;
using Zenject;

namespace Weapons
{
    public class Cannon : Weapon
    {
        private IInput input;
        private readonly float speedMultiplier = 10f;

        [Inject]
        private void Construct(IInput input)
        {
            this.input = input;
        }

        private void Awake()
        {
            barrel = GetComponent<IBarrel>();

        }

        private void Start() => input.OnTouchReleased += OnTouchReleased;        

        private void OnTouchReleased(float speed)
        {
            float adjustedSpeed = speed * speedMultiplier;
            Shoot(barrel.CurrentRotation, adjustedSpeed);             
        }

        private void OnDestroy() => input.OnTouchReleased -= OnTouchReleased;
    }
}
