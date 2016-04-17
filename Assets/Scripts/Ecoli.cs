using UnityEngine;
using System.Collections;

public class Ecoli : MonoBehaviour
{
    private int successiveClimbs = 0, chemotacticSteps = 0;
    private float speed = 20, health = 50;
    private float runInterval, tumbleInterval, tumbleFrequency;
    private float previousChemicalMeasure, currentChemicalMeasure;
    private bool wasInAttractant, currentlyInAttractant, swimming, tumbling, climbingGradient;
    private Collider environment;
    private GameObject secretedAttractant, secretedRepellent;

    [SerializeField]
    private GameObject chemicalPrefab;

    public static int numEcoli;
    public static int numInAttractant;

    void Start()
    {
        numEcoli++;
    }

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
        useEnergy(0.001f);
        if (health <= 0) Destroy(this.gameObject);
        if (!swimming && !tumbling)
        {
            if (environment) sampleEnvironment();
            if (health >= 90) secreteAttractant();
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
        consumeEnergy();
        wasInAttractant = currentlyInAttractant;
        currentlyInAttractant = (Vector3.Distance(transform.position, new Vector3(0, 0, 0)) <= 1000.0f) ? true : false;
        updateInAttractantCount();
        climbingGradient = (currentChemicalMeasure > previousChemicalMeasure) ? true : false;
        tumbleFrequency = climbingGradient ? Random.Range(0.0f, 0.1f) : Random.Range(0.5f, 1.0f);
        if (climbingGradient) successiveClimbs++;
        else successiveClimbs = 0;
        runInterval = (currentlyInAttractant && climbingGradient) ? Random.Range(2.0f, 5.52f) : Random.Range(0.0f, 2.04f);
        tumbleInterval = Random.Range(0.14f, 0.33f);
    }

    private void consumeEnergy()
    {
        if (currentChemicalMeasure > 0 && health < 100) health += currentChemicalMeasure/2;
    }

    private void useEnergy(float amount)
    {
        health -= amount;
    }

    private void updateInAttractantCount()
    {
        if (wasInAttractant != currentlyInAttractant)
        {
            if (currentlyInAttractant) numInAttractant++;
            else numInAttractant--;
        }
    }

    private void secreteAttractant()
    {
        secretedAttractant = Instantiate(chemicalPrefab) as GameObject;
        secretedAttractant.GetComponent<Chemical>().setOrigin(environment.gameObject, transform.position);
        secretedAttractant.GetComponent<Chemical>().setConcentration(5.0f);
        secretedAttractant.GetComponent<Chemical>().setWidth(100.0f);
        secretedAttractant.GetComponent<Chemical>().setEcoliReaction(Chemical.BacteriaReaction.Attractant);
        secretedAttractant.GetComponent<Chemical>().setSource(Chemical.Source.Ecoli);
        environment.GetComponent<Agar>().addChemical(secretedAttractant);
    }
}