using UnityEngine;
using System.Collections;

public class DumbAgent : Agent {

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

    public virtual void OnTriggerEnter(Collider other)
    {
        // this should be implemented as a state Collision 
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            Sleep sleep = new Sleep();
            sleep.Execute(this);
        }
    }

}
