using UnityEngine;
using System.Collections;

public class MoveRandom : State {

    public MoveRandom() { }

    public void Execute(DumbAgent agent)
    {
        if (agent.getRigidbody().IsSleeping())
            return;
        float maxDistance = agent.getMaxDistance();
        agent.setSpeed(Random.Range(0.0f, agent.getMaxSpeed()));
        agent.setDirection(new Vector3(
            Random.Range(-maxDistance, maxDistance),
            Random.Range(-maxDistance, maxDistance),
            Random.Range(-maxDistance, maxDistance)));
        agent.moveRandom();
    }
}
