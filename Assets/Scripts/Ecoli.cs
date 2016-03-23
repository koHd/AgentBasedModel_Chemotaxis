using UnityEngine;
using System.Collections;

public class Ecoli : MonoBehaviour
{
    private float speed, runInterval, tumbleInterval, previousChemicalMeasure, currentChemicalMeasure;
    private bool inSugar, busy, goingUpGradient;
    private GameObject chemical;

    void Start ()
    {
        speed = transform.localScale.z * 10;
        goingUpGradient = false;
        runInterval = Random.Range(0.1f, 0.5f);
        tumbleInterval = Random.Range(0.5f, 1f);
        previousChemicalMeasure = 0f;
        currentChemicalMeasure = 0f;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Chemical>())
        {
            inSugar = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Chemical>())
        {
            previousChemicalMeasure = currentChemicalMeasure;
            float concentration = other.GetComponent<Chemical>().getConcentration(transform.position);
            currentChemicalMeasure = other.GetComponent<Chemical>().getChemotaxisType() ? concentration : -concentration;
        }
    }

    void FixedUpdate()
    {
        if (!busy)
            StartCoroutine(swim()); ;
    }

    void OnTriggerExit(Collider other)
    {
        if (inSugar)
        {
            inSugar = false;
            goingUpGradient = false;
            previousChemicalMeasure = 0f;
            currentChemicalMeasure = 0f;
        }
    }

    public IEnumerator swim()
    {
        //Debug.Log("Swimming");
        float startTime = Time.time;
        while (runInterval > 0)
        {
            busy = true;
            transform.Translate(0, speed * Time.deltaTime, 0);
            runInterval -= Time.deltaTime;
            yield return null;
        }
        busy = false;
        float totalTime = Time.time - startTime;
        Debug.Log("Finished swimming after burst of " + runInterval + " seconds.");
        setRunLength();
        if (!goingUpGradient)
            StartCoroutine(tumble());
    }

    public IEnumerator tumble()
    {
        //Debug.Log("Tumbling...");
        float startTime = Time.time;
        while (tumbleInterval > 0)
        {
            busy = true;
            transform.Rotate(Vector3.forward, 360 * Time.deltaTime);
            tumbleInterval -= Time.deltaTime;

            yield return null;
        }
        busy = false;
        float totalTime = Time.time - startTime;
        tumbleInterval = Random.Range(0.1f, 1.5f);
        Debug.Log("Finished tumbling after burst of " + tumbleInterval + " seconds.");
    }

    public float getSpeed()
    {
        return speed;
    }

    public bool isInSugar()
    {
        return inSugar;
    }

    public void setRunLength()
    {
        if (inSugar)
        {
            Debug.Log("Sugar concentration: " + currentChemicalMeasure);
            goingUpGradient = (currentChemicalMeasure > previousChemicalMeasure) ? true : false;
            runInterval = goingUpGradient ? Random.Range(1f, 2f) : Random.Range(0.1f, 0.3f);
        }
        else
        {
            runInterval = Random.Range(0.1f, 1f);
        }
    }
}
