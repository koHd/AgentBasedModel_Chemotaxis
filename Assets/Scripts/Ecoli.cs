using UnityEngine;
using System.Collections;

public class Ecoli : MonoBehaviour
{
    private float speed, runLength, sugarConcentration;
    private bool inSugar, moving, goingUpGradient;

    void Start ()
    {
        speed = transform.localScale.z * 10;
        goingUpGradient = false;
        runLength = 1f;
        sugarConcentration = 0f;
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
            Debug.Log("Sugar concentration: " + other.GetComponent<SugarGradient>().getSugarConcentration(transform.position));
            if (other.GetComponent<SugarGradient>().getSugarConcentration(transform.position) > sugarConcentration)
                goingUpGradient = true;
            else
                goingUpGradient = false;
            sugarConcentration = other.GetComponent<SugarGradient>().getSugarConcentration(transform.position);
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
            sugarConcentration = 0;
        }
    }

    public void doSomething()
    {
        if (inSugar & !moving)
            StartCoroutine(swim());
        else if (!moving)
            StartCoroutine(tumble());
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
                runLength = Random.Range(3f, 4f);
            else
                runLength = Random.Range(0.1f, 0.3f);
        } else
        {
            runLength = Random.Range(0.3f, 0.6f);
        }

        Debug.Log("Finished swimming after burst of " + runLength + " seconds.");
    }

    public IEnumerator tumble()
    {
        Debug.Log("Tumbling...");
        float startTime = Time.time;
        while (runLength > 0)
        {
            moving = true;
            float tumbleAmount = Random.Range(0f, 360f);
            transform.Rotate(Vector3.forward, tumbleAmount * Time.deltaTime);
            runLength -= Time.deltaTime;

            yield return null;
        }
        moving = false;
        float totalTime = Time.time - startTime;
        runLength = Random.Range(0.5f, 1f);
        Debug.Log("Finished tumbling after burst of " + runLength + " seconds.");
        StartCoroutine(swim());
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
