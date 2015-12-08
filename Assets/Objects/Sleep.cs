using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    public class Sleep : State
    {

        public Sleep() { }

        public override void Enter(Agent agent)
        {
            Debug.Log("Entering Sleep State.");
        }

        override public void Execute(Agent agent)
        {
            agent.sleep();
        }

        public override void Exit(Agent agent)
        {
            Debug.Log("Exiting Sleep State.");
        }
    }
}
