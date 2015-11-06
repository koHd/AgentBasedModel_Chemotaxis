using UnityEngine;
using System.Collections;

public class Sleep : State {

    public Sleep() { }

    public void Execute(DumbAgent agent)
    {
        agent.sleep();
    }
	
}
