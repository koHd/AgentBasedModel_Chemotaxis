using UnityEngine;
using System.Collections;

public class Ecoli : MonoBehaviour
{
    private float speed = 20;
    private float runInterval, tumbleInterval;
    private int previousChemicalMeasure, currentChemicalMeasure;
    private bool inAttractant, busy, goingUpGradient;
    private Collider environment;
    private GameObject lastSampledChemical;

    private static int numInAttractant;

    void OnTriggerEnter(Collider other) // E. coli detects it's environment
    {
        if (other.GetComponent<Agar>())
        {
            environment = other;
            updateChemicalSamples();
            if (inAttractant) numInAttractant++;
            Debug.Log("Number of E. coli in attractant: " + numInAttractant);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Agar>())
        {
            Destroy(this);
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
        if (environment) updateChemicalSamples();
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
        previousChemicalMeasure = currentChemicalMeasure;
        currentChemicalMeasure = environment.GetComponent<Agar>().sample(transform.position);
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

}
