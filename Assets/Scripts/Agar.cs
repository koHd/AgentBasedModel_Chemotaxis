using UnityEngine;
using System.Collections.Generic;

public class Agar : MonoBehaviour {

    private float radius;
    private Vector3 origin;
    private GameObject[] chemicals;
    private int numChemicals = 0;
    [SerializeField]
    private GameObject chemicalPrefab;

	void Start ()
    {
        origin = transform.position;
        radius = transform.localScale.x;
    }

    public void addChemicals(int numChemicalsToAdd)
    {
        chemicals = new GameObject[numChemicalsToAdd];
        for (int i = 0; i < chemicals.Length; i++)
        {
            chemicals[i] = Instantiate(chemicalPrefab) as GameObject;
            numChemicals++;
            chemicals[i].transform.position = new Vector3(0, 0, 0);
            float concentration = 100;
            chemicals[i].GetComponent<Chemical>().setConcentration(concentration);
            chemicals[i].transform.localScale += new Vector3(concentration, 100, concentration);
            float cointToss = Random.Range(0.0f, 1.0f);
            if (cointToss >= 0.0f)
            {
                chemicals[i].GetComponent<Chemical>().setEcoliReaction(Chemical.BacteriaReaction.Attractant);
            }
            else
            {
                chemicals[i].GetComponent<Chemical>().setEcoliReaction(Chemical.BacteriaReaction.Repellent);
            }
        }
    }

    public int sample(Vector3 location)
    {
        int totalSample = 0;
        if (chemicals != null)
        {
            int curSample = 0;
            int concentration = 0;
            for (int i = 0; i < chemicals.Length; i++)
            {
                curSample = 0;
                concentration = chemicals[i].GetComponent<Chemical>().getConcentration(location);
                curSample = (chemicals[i].GetComponent<Chemical>().getEcoliReaction() == Chemical.BacteriaReaction.Attractant) ? concentration : -concentration;
                totalSample += curSample;
            }
        }
        return totalSample;
    }
}
