using UnityEngine;
using System.Collections;

public class Ecoli : MonoBehaviour
{
    private int successiveClimbs = 0, chemotacticSteps = 0;
    private float speed = 20;
    private float releaseAttractantFrequency = 0.1f;
    private float runInterval, tumbleInterval, tumbleFrequency;
    private float previousChemicalMeasure, currentChemicalMeasure;
    private bool wasInAttractant, currentlyInAttractant, swimming, tumbling, climbingGradient;
    private Collider environment;

    private static int numInAttractant;

    [SerializeField]
    private GameObject chemicalPrefab;

    void OnTriggerEnter(Collider other) // E. coli detects it's environment
    {
        if (other.GetComponent<Agar>())
        {
            environment = other;
            sampleEnvironment();
        }
    }

    void Update()
    {
        if (!swimming && !tumbling)
        {
            if (environment) sampleEnvironment();
            if (chemotacticSteps % 2 == 0 && Random.Range(0.0f, 1.0f) <= releaseAttractantFrequency) releaseAttractant();
            if (Random.Range(0.0f, 1.0f) <= tumbleFrequency) StartCoroutine(tumble());
            if (!tumbling) StartCoroutine(swim());
            chemotacticSteps++;
        }
    }

    private IEnumerator swim()
    {
        while (runInterval > 0)
        {
            swimming = true;
            transform.Translate(0, speed * Time.deltaTime, 0);
            transform.Rotate(Vector3.forward, Random.Range(2, 10) * Time.deltaTime); // Brownian motion causes E. coli to slightly wander from straight path
            runInterval -= Time.deltaTime;

            yield return null;
        }
        swimming = false;
    }

    private IEnumerator tumble()
    {
        while (tumbleInterval > 0)
        {
            tumbling = true;
            transform.Rotate(Vector3.forward, 720 * Time.deltaTime);
            tumbleInterval -= Time.deltaTime;

            yield return null;
        }
        tumbling = false;
    }

    private void sampleEnvironment()
    {
        previousChemicalMeasure = currentChemicalMeasure;
        currentChemicalMeasure = environment.GetComponent<Agar>().sample(transform.position);
        adjustInternalParameters();
    }

    private void adjustInternalParameters()
    {
        wasInAttractant = currentlyInAttractant;
        currentlyInAttractant = (currentChemicalMeasure >= 1) ? true : false;
        if (wasInAttractant != currentlyInAttractant)
        {
            if (currentlyInAttractant) numInAttractant++;
            else numInAttractant--;
            //Debug.Log("Number of E. coli in attractant: " + numInAttractant);
        }
        climbingGradient = (currentChemicalMeasure > previousChemicalMeasure + 2 * (previousChemicalMeasure / 100)) ? true : false;
        tumbleFrequency = climbingGradient ? 0.2f : 0.5f;
        if (climbingGradient) successiveClimbs++;
        else successiveClimbs = 0;
        runInterval = (currentlyInAttractant && climbingGradient) ? Random.Range(2.0f, 5.52f) : Random.Range(0.0f, 2.04f);
        tumbleInterval = Random.Range(0.14f, 0.33f);
    }

    private void releaseAttractant()
    {
        GameObject chemical = Instantiate(chemicalPrefab) as GameObject;
        chemical.GetComponent<Chemical>().setOrigin(environment.gameObject, transform.position);
        chemical.GetComponent<Chemical>().setConcentration(2.0f);
        chemical.GetComponent<Chemical>().setEcoliReaction(Chemical.BacteriaReaction.Attractant);
        chemical.GetComponent<Chemical>().setSource(Chemical.Source.Ecoli);
        environment.GetComponent<Agar>().addChemical(chemical);
    }

}