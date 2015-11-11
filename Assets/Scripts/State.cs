using UnityEngine;

namespace Assets.Scripts
{
    public class State
    {

        public virtual void Enter(Agent agent) { }
        public virtual void Execute(Agent agent) { }
        public virtual void Exit(Agent agent) { }

    }
}