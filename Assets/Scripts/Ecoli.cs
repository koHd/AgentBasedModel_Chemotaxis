using UnityEngine;
using System.Collections;

public class Ecoli : MonoBehaviour
{
    private float speed, runLength, tumbleLength, oldSugarConcentration, currentSugarConcentration;
    private bool inSugar, moving, goingUpGradient;

    void Start ()
    {
        speed = transform.localScale.z * 10;
        goingUpGradient = false;
        runLength = 1f;
        tumbleLength = 1f;
        oldSugarConcentration = 0f;
        currentSugarConcentration = 0f;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<SugarGradient>())
        {
            inSugar = true;
            doSomething();
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (inSugar)
        {
            oldSugarConcentration = currentSugarConcentration;
            currentSugarConcentration = other.GetComponent<SugarGradient>().getSugarConcentration(transform.position);
        }
    }

    void FixedUpdate()
    {
        if (!moving)
            doSomething();
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

    public void doSomething()
    {
        if (!moving)
            StartCoroutine(swim());

    }

    public IEnumerator swim()
    {
        Debug.Log("Swimming");
        float startTime = Time.time;
        while (runLength > 0)
        {
            moving = true;
            transform.Translate(0, speed * Time.deltaTime, 0);
            runLength -= Time.deltaTime;

            yield return null;
        }
        moving = false;
        float totalTime = Time.time - startTime;
        if (inSugar)
        {
            if (goingUpGradient)
                runLength = Random.Range(1f, 3f);
            else
                runLength = Random.Range(0.1f, 0.2f);
        } else
        {
            runLength = Random.Range(0.2f, 0.5f);
        }

        Debug.Log("Finished swimming after burst of " + runLength + " seconds.");
        StartCoroutine(tumble());
        if (inSugar)
        {
            Debug.Log("Sugar concentration: " + currentSugarConcentration);
            if (currentSugarConcentration > oldSugarConcentration)
                goingUpGradient = true;
            else
                goingUpGradient = false;
        }
    }

    public IEnumerator tumble()
    {
        Debug.Log("Tumbling...");
        float startTime = Time.time;
        while (tumbleLength > 0)
        {
            moving = true;
            transform.Rotate(Vector3.forward, 360 * Time.deltaTime);
            tumbleLength -= Time.deltaTime;

            yield return null;
        }
        moving = false;
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
}
