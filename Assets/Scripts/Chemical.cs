using UnityEngine;
using System.Collections;

public class Chemical : MonoBehaviour {

    private Vector3 origin;
    private float concentration;
    private bool attractant;

    // Use this for initialization
    void Start()
    {
        origin = transform.position;
    }

    public float getConcentration(Vector3 position)
    {
        return transform.localScale.magnitude / Vector3.Distance(origin, position);
    }
}
