using UnityEngine;
using System.Collections;

public class Ecoli : MonoBehaviour
{
    private float speed = 20;
    private float runInterval, tumbleInterval;
    private float previousChemicalMeasure, currentChemicalMeasure;
    private bool wasInAttractant, currentlyInAttractant, busy, goingUpGradient;
    private Collider environment;

    private static int numInAttractant;

    void OnTriggerEnter(Collider other) // E. coli detects it's environment
    {
        if (other.GetComponent<Agar>())
        {
            environment = other;
            updateChemicalSamples();
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
        while (runInterval > 0)
        {
            busy = true;
            transform.Translate(0, speed * Time.deltaTime, 0);
            runInterval -= Time.deltaTime;

            yield return null;
        }
        busy = false;
        if (environment) updateChemicalSamples();
        if (!goingUpGradient) StartCoroutine(tumble());

    }

    public IEnumerator tumble()
    {
        while (tumbleInterval > 0)
        {
            busy = true;
            transform.Rotate(Vector3.forward, 720 * Time.deltaTime);
            tumbleInterval -= Time.deltaTime;

            yield return null;
        }
        busy = false;
    }

    public void updateChemicalSamples()
    {
        wasInAttractant = currentlyInAttractant;
        previousChemicalMeasure = currentChemicalMeasure;
        currentChemicalMeasure = environment.GetComponent<Agar>().sample(transform.position); 
        currentlyInAttractant = (currentChemicalMeasure > 1) ? true : false;
        if (wasInAttractant != currentlyInAttractant)
        {
            if (currentlyInAttractant) numInAttractant++;
            else numInAttractant--;
            Debug.Log("Number of E. coli in attractant: " + numInAttractant);
        }
        if (System.Math.Abs(currentChemicalMeasure) > 1)
            goingUpGradient = (currentChemicalMeasure > previousChemicalMeasure) ? true : false;
        else
            goingUpGradient = false;
    }

    public void setRunAndTumbleIntervals()
    {
        if (currentlyInAttractant && goingUpGradient)
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
