using UnityEngine;
using System.Collections.Generic;


public class SceneController : MonoBehaviour
{
    float startTime, timeElapsed;
    [SerializeField]
    private GameObject agarPrefab, ecoliPrefab, chemicalPrefab;
    private GameObject agar;
    private GameObject[] ecoli, chemicals;
    private int numEcoli, numChemicals;

    void Start()
    {
        startTime = Time.time;
        agar = Instantiate(agarPrefab) as GameObject;
        numEcoli = 1000;
        addEcoliToAgar(numEcoli);
        numChemicals = 3;
        GameObject chemical = Instantiate(chemicalPrefab) as GameObject;
        chemical.GetComponent<Chemical>().setOrigin(new Vector3(0, 0, 0));
        chemical.GetComponent<Chemical>().setConcentration(500);
        chemical.GetComponent<Chemical>().setEcoliReaction(Chemical.BacteriaReaction.Attractant);
        agar.GetComponent<Agar>().addChemical(chemical);        

    }

    void Update()
    {
        timeElapsed = timeElapsed - startTime;
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

}
