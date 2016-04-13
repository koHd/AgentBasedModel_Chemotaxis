using UnityEngine;
using UnityEngine.UI;
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
    [SerializeField]
    private Text timeSinceGenesis, ecoliAlive, inAttractantCount;

    void Start()
    {
        agar = Instantiate(agarPrefab) as GameObject;
        numEcoli = 500;
        addEcoliToAgar(numEcoli);
        chemicalVialRack.Add(prepareChemical(new Vector3(0, 0, 0), 100000000, 2000, Chemical.BacteriaReaction.Attractant));
        addChemicalsToAgar(chemicalVialRack);
        updateGUIText();
    }

    void Update()
    {
        updateGUIText();
    }

    public void addEcoliToAgar(int numEcoli)
    {
        ecoli = new GameObject[numEcoli];
        Vector3 position = new Vector3(-1200, 0, 0);
        for (int i = 0; i < numEcoli; i++)
        {
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

    private void updateGUIText()
    {
        timeSinceGenesis.text = "Time Since Genesis: " + Time.time;
        ecoliAlive.text = "E. coli Alive: " + Ecoli.numEcoli;
        inAttractantCount.text = "E. coli Found Attractant: " + Ecoli.numInAttractant;
    }

}
