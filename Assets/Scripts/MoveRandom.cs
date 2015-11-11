using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    public class MoveRandom : State
    {

        public MoveRandom() { }

        public override void Enter(Agent agent)
        {
            Debug.Log("Entering MoveRandom State. ");
        }

        override public void Execute(Agent agent)
        {
            LocomotiveAgent locoAgent = (LocomotiveAgent) agent;

            float maxDistance = locoAgent.getMaxDistance();
            locoAgent.setSpeed(Random.Range(0.0f, locoAgent.getMaxSpeed()));
            locoAgent.setDirection(new Vector3(
                Random.Range(-maxDistance, maxDistance),
                Random.Range(-maxDistance, maxDistance),
                Random.Range(-maxDistance, maxDistance)));
            locoAgent.moveRandom();
            locoAgent.useEnergy(1);

            if (locoAgent.getEngery() <= 0)
            {
                Debug.Log("Oh no, I've died of hunger! ");
                locoAgent.changeState(new Sleep());
            }
        }

        public override void Exit(Agent agent)
        {
            Debug.Log("Exiting MoveRandom State.");
        }
    }
}