using UnityEngine;
using System.Collections;

public class Agent : MonoBehaviour {

    protected float speed, maxSpeed, maxDistance;
    protected Vector3 direction;
    protected Rigidbody rb;
    protected State previousState;
    protected State currentState;
    protected State globalState;

    public virtual void Start () { }
    public virtual void Update () {}
    public virtual void FixedUpdate() {}

    public virtual void moveRandom()
    {
        rb.AddForce(direction * speed);
    }

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

    public void setSpeed(float speed)
    {
        this.speed = speed;
    }

    public float getSpeed()
    {
        return speed;
    }

    public void setDirection(Vector3 movement)
    {
        this.direction = movement;
    }

    public Vector3 getDirection()
    {
        return direction;
    }

    public void setMaxSpeed(float maxSpeed)
    {
        this.maxSpeed = maxSpeed;
    }

    public float getMaxSpeed()
    {
        return maxSpeed;
    }

    public void setMaxDistance(float maxDistance)
    {
        this.maxDistance = maxDistance;
    }

    public float getMaxDistance()
    {
        return maxDistance;
    }

    public Rigidbody getRigidbody()
    {
        return rb;
    }

}
