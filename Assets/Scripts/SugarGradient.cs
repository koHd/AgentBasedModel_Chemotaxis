using UnityEngine;
using System.Collections;

public class SugarGradient : MonoBehaviour
{
    Vector3 sugarOrigin;

    // Use this for initialization
    void Start ()
    {
        sugarOrigin = transform.position;
    }

    public float getSugarConcentration(Vector3 position)
    {
        return transform.localScale.magnitude / Vector3.Distance(sugarOrigin, position);
    }
}
