using UnityEngine;
using System.Collections;

public class Ecoli : MonoBehaviour
{
    private float speed, runInterval, tumbleInterval, previousChemicalMeasure, currentChemicalMeasure;
    private bool inAttractant, busy, goingUpGradient;
    private Collider curChemical;

    private static int numInAttractant;

    void Start () // initialise E. coli
    {
        speed = transform.localScale.z * 10; // E. coli can swim ten body lengths per second
        goingUpGradient = false;
        previousChemicalMeasure = 0;
        currentChemicalMeasure = 0;
        setRunAndTumbleIntervals();
    }

    void OnTriggerEnter(Collider other) // E. coli detects some new medium in the environment
    {
        if (other.GetComponent<Chemical>())
        {
            curChemical = other;
            updateChemicalSamples();
            if (inAttractant) numInAttractant++;
        }
    }

    void Update()
    {
        if (!busy)
        {
            setRunAndTumbleIntervals();
            StartCoroutine(swim());
        }
    }

    void OnTriggerExit(Collider other) // E. coli has detected it has left some medium
    {
        if (curChemical)
        {
            curChemical = null;
            goingUpGradient = false;
            previousChemicalMeasure = 0;
            currentChemicalMeasure = 0;
            if (inAttractant)
            {
                numInAttractant--;
                inAttractant = false;
            }
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
        if (curChemical) updateChemicalSamples();
        if (!goingUpGradient) StartCoroutine(tumble());

    }

    public IEnumerator tumble()
    {
        float startTime = Time.time;
        while (tumbleInterval > 0)
        {
            busy = true;
            transform.Rotate(Vector3.forward, 720 * Time.deltaTime);
            tumbleInterval -= Time.deltaTime;

            yield return null;
        }
        busy = false;
        float totalTime = Time.time - startTime;
    }


    public void updateChemicalSamples()
    {
        float concentration = curChemical.GetComponent<Chemical>().getConcentration(transform.position);
        previousChemicalMeasure = currentChemicalMeasure;
        currentChemicalMeasure = (curChemical.GetComponent<Chemical>().getEcoliReaction() == Chemical.BacteriaReaction.Attractant)  ? concentration : -concentration;
        inAttractant = (currentChemicalMeasure > 0) ? true : false;
        goingUpGradient = (currentChemicalMeasure > previousChemicalMeasure) ? true : false;

    }

    public void setRunAndTumbleIntervals()
    {
        if (inAttractant && goingUpGradient)
        {
            runInterval = Random.Range(2.0f, 5.52f);
            tumbleInterval = Random.Range(0.0f, 0.05f);

        }
        else // baseline search/avoidance behaviour
        {
            runInterval = Random.Range(0.0f, 2.04f);
            tumbleInterval = Random.Range(0.14f, 0.33f);
        }
    }

    public bool getInAttractant()
    {
        return inAttractant;
    }

    public static int getNumInAttractant()
    {
        return numInAttractant;
    }

}
