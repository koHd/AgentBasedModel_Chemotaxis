using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    public class Agent : MonoBehaviour
    {

        protected Rigidbody rb;
        protected State previousState;
        protected State currentState;
        protected State globalState;

        public virtual void Start() { }
        public virtual void Update() { }
        public virtual void FixedUpdate() { }

        public virtual void sleep()
        {
            rb.Sleep();
        }

        public void setCurrentState(State newState)
        {
            this.currentState = newState;
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