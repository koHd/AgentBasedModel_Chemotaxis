using UnityEngine;
using System.Collections;

public class Ecoli : MonoBehaviour
{
    private float speed, runInterval, tumbleInterval, previousChemicalMeasure, currentChemicalMeasure;
    private bool inChemical, busy, goingUpGradient;
    private static int numInChemical;

    void Start ()
    {
        speed = transform.localScale.z * 10;
        goingUpGradient = false;
        setRunAndTumbleIntervals();
        previousChemicalMeasure = 0f;
        currentChemicalMeasure = 0f;
    }

    void OnTriggerEnter(Collider other)
    {
        numInChemical++;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Chemical>())
        {
            inChemical = true;
            previousChemicalMeasure = currentChemicalMeasure;
            float concentration = other.GetComponent<Chemical>().getConcentration(transform.position);
            currentChemicalMeasure = other.GetComponent<Chemical>().getChemotaxisType() ? concentration : -concentration;
        }
    }

    void FixedUpdate()
    {
        goingUpGradient = (currentChemicalMeasure > previousChemicalMeasure) ? true : false;
        if (!busy)
            StartCoroutine(swim()); ;
    }

    void OnTriggerExit(Collider other)
    {
        if (inChemical)
        {
            numInChemical--;
            inChemical = false;
            goingUpGradient = false;
            previousChemicalMeasure = 0f;
            currentChemicalMeasure = 0f;
        }
    }

    public IEnumerator swim()
    {
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
        setRunAndTumbleIntervals();
        if (!goingUpGradient)
            StartCoroutine(tumble());
    }

    public IEnumerator tumble()
    {
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
        setRunAndTumbleIntervals();
    }

    public void setRunAndTumbleIntervals()
    {
        if (inChemical)
        {
            if (goingUpGradient)
            {
                runInterval = Random.Range(1.0f, 3.04f);
                tumbleInterval = Random.Range(0.05f, 0.20f);
            }
            else
            {
                runInterval = Random.Range(1.0f, 2.04f);
                tumbleInterval = Random.Range(0.08f, 0.25f);
            }
        }
        else
        {
            runInterval = Random.Range(0.0f, 2.04f);
            tumbleInterval = Random.Range(0.14f, 0.33f);
        }
    }

    public bool getInChemical()
    {
        return inChemical;
    }

    public static int getNumInChemical()
    {
        return numInChemical;
    }
}
