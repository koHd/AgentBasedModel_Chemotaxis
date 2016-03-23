using UnityEngine;
using System.Collections.Generic;


public class SceneController : MonoBehaviour
{
    float startTime;
    float timeElapsed;
    [SerializeField]
    private GameObject ecoliPrefab, checmicalPrefab;
    private GameObject _chemical;
    private GameObject[] ecoli;
    private int numEcoliInChemical;

    void Start()
    {
        numEcoliInChemical = 0;
        startTime = Time.time;
        ecoli = new GameObject[50];
        for (int i = 0; i < ecoli.Length; i++)
        {
            ecoli[i] = Instantiate(ecoliPrefab) as GameObject;
            ecoli[i].transform.position = new Vector3(0, 0.5f, -40f);
        }
        _chemical = Instantiate(checmicalPrefab) as GameObject;
        _chemical.transform.localScale += new Vector3(50.0f, 0, 50.0f);
        _chemical.GetComponent<Chemical>().setChemotaxisType(true);
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
