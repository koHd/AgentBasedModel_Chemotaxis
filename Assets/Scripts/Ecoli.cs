using UnityEngine;
using System.Collections;

public class Ecoli : MonoBehaviour
{
    private float speed, burstLength;
    private bool inSugar, moving;

	void Start ()
    {
        speed = transform.localScale.z * 10;
        burstLength = 1f;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<SugarGradient>())
        {
            inSugar = true;
            doSomething();
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
        while (burstLength > 0)
        {
            moving = true;
            transform.Translate(0, speed * Time.deltaTime, 0);
            burstLength -= Time.deltaTime;

            yield return null;
        }
        moving = false;
        float totalTime = Time.time - startTime;
        burstLength = 1f;
        Debug.Log("Finished swimming after burst of " + burstLength + " seconds.");
    }

    public IEnumerator tumble()
    {
        Debug.Log("Tumbling...");
        float startTime = Time.time;
        while (burstLength > 0)
        {
            moving = true;
            transform.Rotate(Vector3.forward, 200f * Time.deltaTime);
            burstLength -= Time.deltaTime;

            yield return null;
        }
        moving = false;
        float totalTime = Time.time - startTime;
        burstLength = 1f;
        Debug.Log("Finished tumbling after burst of " + burstLength + " seconds.");
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
