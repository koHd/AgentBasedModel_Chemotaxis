using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    public class Sleep : State
    {

        public Sleep() { }

        public void Execute(DumbAgent agent)
        {
            agent.sleep();
        }

    }
}
