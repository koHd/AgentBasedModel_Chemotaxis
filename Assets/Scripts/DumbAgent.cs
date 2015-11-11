using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    public class DumbAgent : LocomotiveAgent
    {

        public override void Start()
        {
            rb = GetComponent<Rigidbody>();
            maxSpeed = 5.0f;
            maxDistance = 5.0f;
        }

        public override void FixedUpdate()
        {
            MoveRandom moveRandom = new MoveRandom();
            moveRandom.Execute(this);
        }

        // percept - sense other thing from environment
        public virtual void OnTriggerEnter(Collider other)
        {
            // actuator - consume
            if (other.gameObject.CompareTag("PickUp"))
            {
                other.gameObject.SetActive(false);
                Sleep sleep = new Sleep();
                sleep.Execute(this);
            }
        }

    }
}
