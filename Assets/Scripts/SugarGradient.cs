﻿using UnityEngine;
using System.Collections;

public class SugarGradient : MonoBehaviour
{
    Vector3 sugarOrigin;

    // Use this for initialization
    void Start ()
    {
        sugarOrigin = transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public float getSugarConcentration(Vector3 position)
    {
        return 100 / Vector3.Distance(sugarOrigin, position);
    }
}