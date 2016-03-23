using UnityEngine;
using System.Collections;

public class Ecoli : MonoBehaviour
{
    private float speed, runLength, tumbleLength, oldSugarConcentration, currentSugarConcentration;
    private bool inSugar, busy, goingUpGradient;

    void Start ()
    {
        speed = transform.localScale.z * 10;
        goingUpGradient = false;
        runLength = Random.Range(0.1f, 0.5f);
        tumbleLength = Random.Range(0.5f, 1f);
        oldSugarConcentration = 0f;
        currentSugarConcentration = 0f;
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
            oldSugarConcentration = currentSugarConcentration;
            float concentration = other.GetComponent<Chemical>().getConcentration(transform.position);
            currentSugarConcentration = other.GetComponent<Chemical>().getChemotaxisType() ? concentration : -concentration;
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
            oldSugarConcentration = 0f;
            currentSugarConcentration = 0f;
        }
    }

    public IEnumerator swim()
    {
        //Debug.Log("Swimming");
        float startTime = Time.time;
        while (runLength > 0)
        {
            busy = true;
            transform.Translate(0, speed * Time.deltaTime, 0);
            runLength -= Time.deltaTime;
            yield return null;
        }
        busy = false;
        float totalTime = Time.time - startTime;
        Debug.Log("Finished swimming after burst of " + runLength + " seconds.");
        setRunLength();
        if (!goingUpGradient)
            StartCoroutine(tumble());
    }

    public IEnumerator tumble()
    {
        //Debug.Log("Tumbling...");
        float startTime = Time.time;
        while (tumbleLength > 0)
        {
            busy = true;
            transform.Rotate(Vector3.forward, 360 * Time.deltaTime);
            tumbleLength -= Time.deltaTime;

            yield return null;
        }
        busy = false;
        float totalTime = Time.time - startTime;
        tumbleLength = Random.Range(0.1f, 1.5f);
        Debug.Log("Finished tumbling after burst of " + tumbleLength + " seconds.");
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
            Debug.Log("Sugar concentration: " + currentSugarConcentration);
            goingUpGradient = (currentSugarConcentration > oldSugarConcentration) ? true : false;
            runLength = goingUpGradient ? Random.Range(1f, 2f) : Random.Range(0.1f, 0.3f);
        }
        else
        {
            runLength = Random.Range(0.1f, 1f);
        }
    }
}
