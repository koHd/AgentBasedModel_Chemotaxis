using UnityEngine;
using System.Collections.Generic;

public class Agar : MonoBehaviour {

    private float radius;
    private Vector3 origin;
    private Chemical[] chemicals;

	void Start ()
    {
        origin = transform.position;
        radius = transform.localScale.x;
    }
	
	void Update ()
    {
	
	}

    public Chemical getHighestConcentratedChemicalAtLocation(Vector3 location)
    {
        float highestConcentratedChemicalSoFar = 0;
        int indexOfHighestConcreatedChemicalSoFar = 0;
        for (int i = 0; i < chemicals.Length; i++)
        {
            float curConcentration = chemicals[i].getConcentration(location);
            if (curConcentration > highestConcentratedChemicalSoFar)
            {
                highestConcentratedChemicalSoFar = curConcentration;
                indexOfHighestConcreatedChemicalSoFar = i;
            }
        }
        return chemicals[indexOfHighestConcreatedChemicalSoFar];
    }
}
