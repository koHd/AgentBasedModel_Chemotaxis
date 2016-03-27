using UnityEngine;
using System.Collections.Generic;


public class SceneController : MonoBehaviour
{
    private GameObject agar;
    private GameObject[] ecoli, chemicalVialRack;
    private int numEcoli, numChemicals;

    [SerializeField]
    private GameObject agarPrefab, ecoliPrefab, chemicalPrefab;

    void Start()
    {
        agar = Instantiate(agarPrefab) as GameObject;
        numEcoli = 500;
        addEcoliToAgar(numEcoli);
        numChemicals = 3;
        chemicalVialRack = new GameObject[numChemicals];
        chemicalVialRack[0] = prepareChemical(new Vector3(1000, 0, 0), 500, Chemical.BacteriaReaction.Attractant);
        chemicalVialRack[1] = prepareChemical(new Vector3(-1000, 0, 0), 500, Chemical.BacteriaReaction.Attractant);
        chemicalVialRack[2] = prepareChemical(new Vector3(0, 0, 0), 500, Chemical.BacteriaReaction.Repellent);
        addChemicalsToAgar(chemicalVialRack);
    }

    public void addEcoliToAgar(int numEcoli)
    {
        ecoli = new GameObject[numEcoli];
        for (int i = 0; i < ecoli.Length; i++)
        {
            ecoli[i] = Instantiate(ecoliPrefab) as GameObject;
            ecoli[i].transform.position = new Vector3(0, 0, 0);
        }
    }

    public GameObject prepareChemical(Vector3 location, float concentration, Chemical.BacteriaReaction ecoliReaction)
    {
        GameObject chemical = Instantiate(chemicalPrefab) as GameObject;
        chemical.GetComponent<Chemical>().setOrigin(location);
        chemical.GetComponent<Chemical>().setConcentration(concentration);
        chemical.GetComponent<Chemical>().setEcoliReaction(ecoliReaction);
        return chemical;
    }

    public void addChemicalsToAgar(GameObject[] chemicals)
    {
        for(int i = 0; i < chemicals.Length; i++)
        {
            agar.GetComponent<Agar>().addChemical(chemicals[i]);
        }
    }

}
