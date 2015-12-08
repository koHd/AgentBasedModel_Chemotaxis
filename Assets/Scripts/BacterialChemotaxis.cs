using UnityEngine;
using System.Collections;

public class BacterialChemotaxis : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {

	}

	// Update is called once per frame
	void Update ()
    {
        if (GetComponent<DetectSugar>().isInSugar())
        {
            swim();
        } else
        {
            tumble();
        }
    }

    private void swim()
    {
        Debug.Log("Swimming...");
        transform.position += Vector3.forward * Time.deltaTime;
    }

    private void tumble()
    {
        Debug.Log("Tumbling...");
    }
}
