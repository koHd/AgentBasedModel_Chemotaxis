using UnityEngine;
using System.Collections.Generic;


public class SceneController : MonoBehaviour
{
    private GameObject agar;
    private GameObject[] ecoli;
    private List<GameObject> chemicalVialRack = new List<GameObject>();
    private int numEcoli, numChemicals;

    [SerializeField]
    private GameObject agarPrefab, ecoliPrefab, chemicalPrefab;

    void Start()
    {
        agar = Instantiate(agarPrefab) as GameObject;
        numEcoli = 500;
        addEcoliToAgar(numEcoli);
        //chemicalVialRack.Add(prepareChemical(new Vector3(1000, 0, 0), 500, Chemical.BacteriaReaction.Attractant));
        chemicalVialRack.Add(prepareChemical(new Vector3(800, 0, 0), 1000000, 2000, Chemical.BacteriaReaction.Attractant));
        addChemicalsToAgar(chemicalVialRack);
    }

    public void addEcoliToAgar(int numEcoli)
    {
        ecoli = new GameObject[numEcoli];
        for (int i = 0; i < ecoli.Length; i++)
        {
            ecoli[i] = Instantiate(ecoliPrefab) as GameObject;
            ecoli[i].transform.position = new Vector3(Random.Range(-1600, -800), 0, Random.Range(-600, 600));
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
