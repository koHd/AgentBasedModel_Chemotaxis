using UnityEngine;
using System.Collections;

public class Ecoli : MonoBehaviour
{
    private float speed, runLength;
    private bool inSugar, moving;

    void Start ()
    {
        speed = transform.localScale.z * 10;
        runLength = 1f;
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
        if (other.GetComponent<SugarGradient>())
        {
            Debug.Log("Sugar concentration: " + other.GetComponent<SugarGradient>().getSugarConcentration(transform.position));
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
        runLength = Random.Range(1f, 2f);
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
        runLength = Random.Range(0.2f, 0.5f);
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
