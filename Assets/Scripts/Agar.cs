using UnityEngine;
using System.Collections.Generic;

public class Agar : MonoBehaviour {

    private float radius;
    private Vector3 origin;
    private Stack<GameObject> chemicalsInAgar = new Stack<GameObject>();
    private int numChemicals = 0;

	void Start ()
    {
        origin = transform.position;
        radius = transform.localScale.x;
    }

    public void addChemical(GameObject chemical)
    {
        chemicalsInAgar.Push(chemical);
    }

    public float sample(Vector3 location)
    {
        float totalSample = 0;
        if (chemicalsInAgar != null)
        {
            GameObject[] chemicals = new GameObject[chemicalsInAgar.Count];
            chemicalsInAgar.CopyTo(chemicals, 0);
            float curSample = 0;
            float concentration = 0;
            for (int i = 0; i < chemicals.Length; i++)
            {
                curSample = 0;
                concentration = chemicals[i].GetComponent<Chemical>().getConcentrationAtPosition(location);
                curSample = (chemicals[i].GetComponent<Chemical>().getEcoliReaction() == Chemical.BacteriaReaction.Attractant) ? concentration : -concentration;
                totalSample += curSample;
            }
        }
        return totalSample;
    }
}
