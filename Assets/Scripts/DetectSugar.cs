using UnityEngine;
using System.Collections;

public class DetectSugar : MonoBehaviour
{
    private bool inSugar = false;
    private SugarGradient sugarGradient;

	// Use this for initialization
	void Start ()
    {
        Debug.Log("Lookin' for sugar...");
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (inSugar)
            Debug.Log("Sugar concentration: " + sugarGradient.getSugarConcentration(transform.position));
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<SugarGradient>())
        {
            inSugar = true;
            sugarGradient = other.GetComponent<SugarGradient>();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (inSugar)
        {
            inSugar = false;
            sugarGradient = null;
        }
    }
}
