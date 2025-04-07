using Zenject;

namespace RotatableObjects
{
    public class Cannon : RotatableObject
    {
        private IInput input;

        [Inject]
        public void Construct(IInput input)
        {
            this.input = input;
        }

        private void Start()
        {
           input.OnTouchStarted += RotateTowards;
        }
       
        private void OnDisable() => input.OnTouchStarted -= RotateTowards;
    }
}
