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
        numEcoli = 200;
        createEcoli(numEcoli);
        numChemicals = 1;
        agar.GetComponent<Agar>().addChemicals(numChemicals);        

    }

    void Update()
    {
        timeElapsed = timeElapsed - startTime;
    }

    public void createEcoli(int numEcoli)
    {
        ecoli = new GameObject[numEcoli];
        for (int i = 0; i < ecoli.Length; i++)
        {
            ecoli[i] = Instantiate(ecoliPrefab) as GameObject;
            ecoli[i].transform.position = new Vector3(Random.Range(-100, 100), Random.Range(5.0f, 50.0f), Random.Range(-100, 100));
        }
    }

}
