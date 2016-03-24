using UnityEngine;
using System.Collections.Generic;


public class SceneController : MonoBehaviour
{
    float startTime;
    float timeElapsed;
    [SerializeField]
    private GameObject ecoliPrefab, checmicalPrefab;
    private GameObject[] ecoli, chemicals;
    private int numEcoli, numChemicals, numEcoliInChemical;

    void Start()
    {
        startTime = Time.time;
        numEcoli = 20;
        numChemicals = 1;
        numEcoliInChemical = 0;
        createEcoli(numEcoli);
        createChemicals(numChemicals);
    }

    void Update()
    {
        if (numEcoliInChemical != Ecoli.getNumInAttractant())
        {
            numEcoliInChemical = Ecoli.getNumInAttractant();
            Debug.Log("Number of E. coli in attractant: " + numEcoliInChemical);
        }
        timeElapsed = timeElapsed - startTime;
    }

    public void createEcoli(int numEcoli)
    {
        ecoli = new GameObject[numEcoli];
        for (int i = 0; i < ecoli.Length; i++)
        {
            ecoli[i] = Instantiate(ecoliPrefab) as GameObject;
            ecoli[i].transform.position = new Vector3(Random.Range(-10.0f, 10.0f), 0.5f, Random.Range(-10.0f, 10.0f));
        }
    }

    public void createChemicals(int numChemicals)
    {
        chemicals = new GameObject[numChemicals];
        for (int i = 0; i < chemicals.Length; i++)
        {
            chemicals[i] = Instantiate(checmicalPrefab) as GameObject;
            chemicals[i].transform.position = new Vector3(Random.Range(-100.0f, 100.0f), 0.0f, Random.Range(-100.0f, 100.0f));
            float radius = Random.Range(50.0f, 200.0f);
            chemicals[i].transform.localScale += new Vector3(radius, 0.0f, radius);
            float cointToss = 1.0f;
            if (cointToss >= 0.5f)
            {
                chemicals[i].GetComponent<Chemical>().setChemotaxisType(true);
            }
            else
            {
                chemicals[i].GetComponent<Chemical>().setChemotaxisType(false);
            }
        }
    }
}
