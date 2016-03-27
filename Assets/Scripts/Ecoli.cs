using UnityEngine;
using System.Collections;

public class Ecoli : MonoBehaviour
{
    private int successiveClimbs = 0;
    private float speed = 20;
    private float runInterval, tumbleInterval;
    private float previousChemicalMeasure, currentChemicalMeasure;
    private bool wasInAttractant, currentlyInAttractant, busy, climbingGradient;
    private Collider environment;

    private static int numInAttractant;

    [SerializeField]
    private GameObject chemicalPrefab;

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
            transform.Rotate(Vector3.forward, Random.Range(2, 10) * Time.deltaTime); // Brownian motion causes E. coli to slightly wander from straight path
            runInterval -= Time.deltaTime;

            yield return null;
        }
        busy = false;
        if (environment) updateChemicalSamples();
        if (!climbingGradient || Random.Range(0.0f, 1.0f) >= 0.9f) StartCoroutine(tumble());
        else if (successiveClimbs >= 2 && currentlyInAttractant)
        {
            releaseAttractant();
            successiveClimbs = 0;
        }
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
        previousChemicalMeasure = currentChemicalMeasure;
        currentChemicalMeasure = environment.GetComponent<Agar>().sample(transform.position);
        wasInAttractant = currentlyInAttractant;
        currentlyInAttractant = (currentChemicalMeasure >= 1) ? true : false;
        if (wasInAttractant != currentlyInAttractant)
        {
            if (currentlyInAttractant) numInAttractant++;
            else numInAttractant--;
            Debug.Log("Number of E. coli in attractant: " + numInAttractant);
        }
        climbingGradient = (currentChemicalMeasure > previousChemicalMeasure + (20 * (previousChemicalMeasure/100))) ? true : false;
        if (climbingGradient) successiveClimbs++;
        else successiveClimbs = 0;
    }

    public void setRunAndTumbleIntervals()
    {
        if (currentlyInAttractant && climbingGradient)
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

    private void releaseAttractant()
    {
        GameObject chemical = Instantiate(chemicalPrefab) as GameObject;
        chemical.GetComponent<Chemical>().setOrigin(transform.position);
        chemical.GetComponent<Chemical>().setConcentration(currentChemicalMeasure/10);
        chemical.GetComponent<Chemical>().setEcoliReaction(Chemical.BacteriaReaction.Attractant);
        environment.GetComponent<Agar>().addChemical(chemical);
    }

}
