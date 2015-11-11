using UnityEngine;

namespace Assets.Scripts
{
    public class Agent : MonoBehaviour
    {

        protected Rigidbody rb;
        protected State currentState;

        public virtual void Start() { }
        public virtual void Update() { }
        public virtual void FixedUpdate() { }

        public virtual void sleep()
        {
            rb.Sleep();
        }

        public void changeState(State newState)
        {
            currentState.Exit(this);

            currentState = newState;

            currentState.Enter(this);
        }

        public State getCurrentState()
        {
            return currentState;
        }

        public Rigidbody getRigidbody()
        {
            return rb;
        }

    }
}