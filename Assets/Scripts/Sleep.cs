using UnityEngine;
using System.Collections;

public class Sleep : State {

    public Sleep() { }

    new public void Execute(PlayerController agent)
    {
        agent.sleep();
    }
	
}
