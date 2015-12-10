using UnityEngine;
using System.Collections;

public class DetectSugar : MonoBehaviour
{
    private Ecoli ecoli;

    void Start()
    {
        ecoli = GetComponent<Ecoli>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<SugarGradient>())
        {
            ecoli.sugarSensor(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (ecoli.isInSugar())
        {
            ecoli.sugarSensor(false);
        }
    }
}
