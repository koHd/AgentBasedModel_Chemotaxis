using UnityEngine;
using System.Collections;

public class MoveForward : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        Debug.Log("Something good up ahead!");
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position += Vector3.forward * Time.deltaTime;
	}
}
