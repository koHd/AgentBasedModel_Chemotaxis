using UnityEngine;
using System.Collections.Generic;


public class SceneController : MonoBehaviour
{
    float startTime;
    float timeElapsed;
    [SerializeField]
    private GameObject ecoliPrefab, checmicalPrefab;
    private GameObject[] ecoli, chemicals;
    private int numEcoliInChemical;

    void Start()
    {
        numEcoliInChemical = 0;
        startTime = Time.time;
        ecoli = new GameObject[50];
        for (int i = 0; i < ecoli.Length; i++)
        {
            ecoli[i] = Instantiate(ecoliPrefab) as GameObject;
            ecoli[i].transform.position = new Vector3(Random.Range(-40.0f, 40.0f), 0.5f, Random.Range(-40.0f, 40.0f));
        }
        chemicals = new GameObject[5];
        for (int i = 0; i < chemicals.Length; i++)
        {
            chemicals[i] = Instantiate(checmicalPrefab) as GameObject;
            chemicals[i].transform.position = new Vector3(Random.Range(-100.0f, 100.0f), 0.0f, Random.Range(-100.0f, 100.0f));
            float radius = Random.Range(20.0f, 80.0f);
            chemicals[i].transform.localScale += new Vector3(radius, 0.0f, radius);
            float cointToss = Random.Range(0.0f, 1.0f);
            if (cointToss >= 0.5f)
            {
                chemicals[i].GetComponent<Chemical>().setChemotaxisType(true);
                Shader shader1 = Shader.Find("Attractant");
                chemicals[i].GetComponent<Renderer>().material.shader = shader1;
            }
            else
            {
                chemicals[i].GetComponent<Chemical>().setChemotaxisType(true);
            }
        }
    }

    void Update()
    {
        if (numEcoliInChemical != Ecoli.getNumInChemical())
        {
            numEcoliInChemical = Ecoli.getNumInChemical();
            Debug.Log("Number of E. coli in chemical: " + numEcoliInChemical);
        }
        timeElapsed = timeElapsed - startTime;
    }
}
