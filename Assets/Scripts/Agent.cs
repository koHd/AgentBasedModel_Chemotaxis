using UnityEngine;
using System.Collections;

public class Agent : MonoBehaviour {

    private float speed, maxSpeed, maxDistance;
    private Vector3 direction;
    private Rigidbody rb;
    private State previousState;
    private State currentState;
    private State globalState;

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
