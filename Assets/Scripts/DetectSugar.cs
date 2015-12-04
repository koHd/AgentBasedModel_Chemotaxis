using UnityEngine;
using System.Collections;

public class DetectSugar : MonoBehaviour
{
    bool inSugar = false;

	// Use this for initialization
	void Start ()
    {
        Debug.Log("Lookin' for sugar...");
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (inSugar)
            Debug.Log("Sugar at " + transform.position);
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<SugarGradient>())
            inSugar = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (inSugar)
            inSugar = false;
    }
}
