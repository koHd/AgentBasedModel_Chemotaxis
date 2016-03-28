using UnityEngine;
using System.Collections.Generic;

public class Agar : MonoBehaviour {

    private float radius;
    private Vector3 origin;
    private List<GameObject> chemicalsInAgar = new List<GameObject>();
    private int numChemicals = 0;

	void Start ()
    {
        origin = transform.position;
        radius = transform.localScale.x;
    }

    public void addChemical(GameObject chemical)
    {
        chemicalsInAgar.Add(chemical);
    }

    public void removeChemical(GameObject chemical)
    {
        if (chemicalsInAgar.Contains(chemical)) chemicalsInAgar.Remove(chemical);
    }

    public float sample(Vector3 location)
    {
        float totalSample = 0;
        if (chemicalsInAgar.Count > 0) 
        {
            float curSample = 0;
            float concentration = 0;
            chemicalsInAgar.ForEach(delegate (GameObject chemical)
            {
                curSample = 0;
                concentration = chemical.GetComponent<Chemical>().getConcentrationAtPosition(location);
                curSample = (chemical.GetComponent<Chemical>().getEcoliReaction() == Chemical.BacteriaReaction.Attractant) ? concentration : -concentration;
                totalSample += curSample;
            });
        }
        //Debug.Log("Net Chemical at location: " + location.ToString() + ": " + totalSample);
        return totalSample;
    }
}
