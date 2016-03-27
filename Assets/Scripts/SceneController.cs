using UnityEngine;
using System.Collections.Generic;


public class SceneController : MonoBehaviour
{
    private GameObject agar;
    private GameObject[] ecoli, chemicals;
    private int numEcoli, numChemicals;

    [SerializeField]
    private GameObject agarPrefab, ecoliPrefab, chemicalPrefab;

    void Start()
    {
        agar = Instantiate(agarPrefab) as GameObject;
        numEcoli = 10;
        addEcoliToAgar(numEcoli);
        numChemicals = 3;
        addChemicalToAgar(new Vector3(0, 0, 0), 500, Chemical.BacteriaReaction.Attractant);
    }

    public void addEcoliToAgar(int numEcoli)
    {
        ecoli = new GameObject[numEcoli];
        for (int i = 0; i < ecoli.Length; i++)
        {
            ecoli[i] = Instantiate(ecoliPrefab) as GameObject;
            ecoli[i].transform.position = new Vector3(Random.Range(-1000, 1000), Random.Range(5.0f, 50.0f), Random.Range(-1000, 1000));
        }
    }

    public void addChemicalToAgar(Vector3 location, float concentration, Chemical.BacteriaReaction ecoliReaction)
    {
        GameObject chemical = Instantiate(chemicalPrefab) as GameObject;
        chemical.GetComponent<Chemical>().setOrigin(location);
        chemical.GetComponent<Chemical>().setConcentration(concentration);
        chemical.GetComponent<Chemical>().setEcoliReaction(ecoliReaction);
        agar.GetComponent<Agar>().addChemical(chemical); 
    }

}
