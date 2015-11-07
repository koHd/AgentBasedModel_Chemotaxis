﻿using UnityEngine;
using System.Collections;

public class DumbAgent : Agent {

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        maxSpeed = 5.0f;
        maxDistance = 5.0f;
    }

    void FixedUpdate()
    {
        MoveRandom moveRandom = new MoveRandom();
        moveRandom.Execute(this);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            Sleep sleep = new Sleep();
            sleep.Execute(this);
        }
    }

    public void setSpeed(float speed)
    {
        this.speed = speed;
    }

    public void setDirection(Vector3 movement)
    {
        this.direction = movement;
    }

    public float getMaxSpeed()
    {
        return maxSpeed;
    }

    public float getMaxDistance()
    {
        return maxDistance;
    }

    public Rigidbody getRigidbody()
    {
        return rb;
    }

    public void move()
    {
        rb.AddForce(this.direction * this.speed);
    }

    public void sleep()
    {
        rb.Sleep();
    }
}
