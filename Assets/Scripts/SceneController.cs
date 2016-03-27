using UnityEngine;
using System.Collections.Generic;


public class SceneController : MonoBehaviour
{
    float startTime, timeElapsed;
    [SerializeField]
    private GameObject ecoliPrefab, checmicalPrefab;
    private GameObject[] ecoli, chemicals;
    private int numEcoli, numChemicals;

    void Start()
    {
        startTime = Time.time;
        numEcoli = 100;
        numChemicals = 1;
        createEcoli(numEcoli);
        createChemicals(numChemicals);
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
            ecoli[i].transform.position = new Vector3(Random.Range(-10.0f, 10.0f), 0.5f, Random.Range(-1000.0f, 1000.0f));
        }
    }

    public void createChemicals(int numChemicals)
    {
        chemicals = new GameObject[numChemicals];
        for (int i = 0; i < chemicals.Length; i++)
        {
            chemicals[i] = Instantiate(checmicalPrefab) as GameObject;
            chemicals[i].transform.position = new Vector3(Random.Range(-10.0f, 10.0f), 0.0f, Random.Range(-10.0f, 10.0f));
            float radius = Random.Range(1000.0f, 1500.0f);
            chemicals[i].transform.localScale += new Vector3(radius, 0.0f, radius);
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
}
