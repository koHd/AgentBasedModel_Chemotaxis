using UnityEngine;

namespace Assets.Scripts
{
    public class DumbAgent : LocomotiveAgent
    {

        public override void Start()
        {
            rb = GetComponent<Rigidbody>();
            maxSpeed = 5.0f;
            maxDistance = 5.0f;
            energy = 1000;
            currentState = new MoveRandom();
        }

        public override void FixedUpdate()
        {
            if (currentState != null)
                currentState.Execute(this);
        }

        // percept - sense other thing from environment
        public virtual void OnTriggerEnter(Collider other)
        {
            // actuator - consume
            if (other.gameObject.CompareTag("PickUp"))
            {
                other.gameObject.SetActive(false);
                consumeEnergy(100);
            }
        }

    }
}
