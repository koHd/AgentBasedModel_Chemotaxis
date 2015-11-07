using UnityEngine;
using System.Collections;

public class Agent : MonoBehaviour {

    protected float speed, maxSpeed, maxDistance;
    protected Vector3 direction;
    protected Rigidbody rb;
    protected State previousState;
    protected State currentState;
    protected State globalState;

    void Start () {}
	void Update () {}

    public void setCurrentState(State newState)
    {
        this.currentState = newState;
    }

    public State getCurrentState()
    {
        return currentState;
    }
}
