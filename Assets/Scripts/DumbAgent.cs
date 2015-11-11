using UnityEngine;
using System.Collections;

public class DumbAgent : Agent {

    protected float speed, maxSpeed, maxDistance;
    protected Vector3 direction;

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

    // this is an agent percept - sense other thing from environment
    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            Sleep sleep = new Sleep();
            sleep.Execute(this);
        }
    }

}
