using UnityEngine;
using System.Collections.Generic;


public class SceneController : MonoBehaviour
{
    private GameObject agar;
    private GameObject[] ecoli;
    private List<GameObject> chemicalVialRack = new List<GameObject>();
    private int numEcoli, numChemicals;
    private float startTIme;

    [SerializeField]
    private GameObject agarPrefab, ecoliPrefab, chemicalPrefab;

    void Start()
    {
        agar = Instantiate(agarPrefab) as GameObject;
        numEcoli = 1000;
        addEcoliToAgar(numEcoli);
        //chemicalVialRack.Add(prepareChemical(new Vector3(1000, 0, 0), 500, Chemical.BacteriaReaction.Attractant));
        chemicalVialRack.Add(prepareChemical(new Vector3(0, 0, 0), 100000000, 2000, Chemical.BacteriaReaction.Attractant));
        addChemicalsToAgar(chemicalVialRack);
    }

    public void addEcoliToAgar(int numEcoli)
    {
        ecoli = new GameObject[numEcoli];
        Vector3 position = new Vector3(0, 0, 0);
        for (int i = 0; i < numEcoli; i++)
        {
            if (i <= 250) position = new Vector3(-1200, 0, 0);
            else if (i <= 500) position = new Vector3(-1800, 0, 0);
            else if (i <= 750) position = new Vector3(-1600, 0, -400);
            else position = new Vector3(-1600, 0, 400);
            ecoli[i] = Instantiate(ecoliPrefab) as GameObject;
            ecoli[i].transform.position = position;
            ecoli[i].transform.Rotate(Vector3.forward, Random.Range(1, 360) * Time.deltaTime);
        }
    }

    public GameObject prepareChemical(Vector3 location, float concentration, float width, Chemical.BacteriaReaction ecoliReaction)
    {
        GameObject chemical = Instantiate(chemicalPrefab) as GameObject;
        chemical.GetComponent<Chemical>().setOrigin(agar, location);
        chemical.GetComponent<Chemical>().setConcentration(concentration);
        chemical.GetComponent<Chemical>().setWidth(width);
        chemical.GetComponent<Chemical>().setEcoliReaction(ecoliReaction);
        chemical.GetComponent<Chemical>().setSource(Chemical.Source.External);
        return chemical;
    }

    public void addChemicalsToAgar(List<GameObject> chemicals)
    {
        chemicals.ForEach(delegate (GameObject chemical)
        {
            agar.GetComponent<Agar>().addChemical(chemical);
        });
    }

}
