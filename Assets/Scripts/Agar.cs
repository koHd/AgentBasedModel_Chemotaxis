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
            chemicals[i].transform.position = new Vector3(Random.Range(-1000.0f, 1000.0f), 0.0f, Random.Range(-1000.0f, 1000.0f));
            float radius = Random.Range(500.0f, 1000.0f);
            chemicals[i].transform.localScale += new Vector3(radius, 0.0f, radius);
            chemicals[i].GetComponent<Chemical>().setConcentration(1.0f);
            float cointToss = Random.Range(0.0f, 1.0f);
            if (cointToss >= 0.5f)
            {
                chemicals[i].GetComponent<Chemical>().setEcoliReaction(Chemical.BacteriaReaction.Attractant);
            }
            else
            {
                chemicals[i].GetComponent<Chemical>().setEcoliReaction(Chemical.BacteriaReaction.Repellent);
            }
        }
    }

    public GameObject getHighestConcentratedChemicalAtLocation(Vector3 location)
    {
        if (chemicals != null)
        {
            float highestConcentratedChemicalSoFar = 0;
            int indexOfHighestConcreatedChemicalSoFar = 0;
            for (int i = 0; i < chemicals.Length; i++)
            {
                float curConcentration = chemicals[i].GetComponent<Chemical>().getConcentration(location);
                if (curConcentration > highestConcentratedChemicalSoFar)
                {
                    highestConcentratedChemicalSoFar = curConcentration;
                    indexOfHighestConcreatedChemicalSoFar = i;
                }
            }
            return chemicals[indexOfHighestConcreatedChemicalSoFar];
        }
        return null;
    }
}
