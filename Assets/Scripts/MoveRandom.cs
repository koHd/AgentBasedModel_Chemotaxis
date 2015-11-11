using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    public class MoveRandom : State
    {

        public MoveRandom() { }

        public void Execute(DumbAgent agent)
        {
            if (agent.getEngery() <= 0)
            {
                Debug.Log("Oh no, I've died of hunger! ");
                return;
            }
            float maxDistance = agent.getMaxDistance();
            agent.setSpeed(Random.Range(0.0f, agent.getMaxSpeed()));
            agent.setDirection(new Vector3(
                Random.Range(-maxDistance, maxDistance),
                Random.Range(-maxDistance, maxDistance),
                Random.Range(-maxDistance, maxDistance)));
            agent.moveRandom();
            agent.useEnergy(1);
        }
    }
}