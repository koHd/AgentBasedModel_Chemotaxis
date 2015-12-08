using UnityEngine;
using System.Collections;

public class BacterialChemotaxis : MonoBehaviour
{
    private float speed;

	// Use this for initialization
	void Start ()
    {
        speed = GetComponent<Ecoli>().getSpeed();
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
        transform.position += Vector3.forward * speed * Time.deltaTime;
    }

    private void tumble()
    {
        Debug.Log("Tumbling...");
    }
}
