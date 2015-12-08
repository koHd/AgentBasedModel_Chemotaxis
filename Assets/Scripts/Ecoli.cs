using UnityEngine;
using System.Collections;

public class Ecoli : MonoBehaviour
{
    private float speed;

	// Use this for initialization
	void Start ()
    {
        speed = transform.localScale.z * 10;
    }

    public float getSpeed()
    {
        return speed;
    }
}
