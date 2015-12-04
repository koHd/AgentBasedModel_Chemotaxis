using UnityEngine;
using System.Collections;

public class DetectSugar : MonoBehaviour
{
    bool inSugar = false;
    Vector3 sugarOrigin;

	// Use this for initialization
	void Start ()
    {
        Debug.Log("Lookin' for sugar...");
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (inSugar)
            Debug.Log("Sugar concentration: " + 100/Vector3.Distance(sugarOrigin, transform.position));
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<SugarGradient>())
        {
            inSugar = true;
            sugarOrigin = other.transform.position;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (inSugar)
            inSugar = false;
    }
}
