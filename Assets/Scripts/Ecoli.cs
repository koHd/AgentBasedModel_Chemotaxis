using UnityEngine;
using System.Collections;

public class Ecoli : MonoBehaviour
{
    private float speed, burstLength;
    private bool inSugar;

	// Use this for initialization
	void Start ()
    {
        speed = transform.localScale.z * 10;
        burstLength = 1f;
    }

    public void doSomething()
    {
        StartCoroutine(swim());
    }

    public IEnumerator swim()
    {
        Debug.Log("Swimming");
        float startTime = Time.time;
        while (burstLength > 0)
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
            burstLength -= Time.deltaTime;

            yield return null;
        }
        float totalTime = Time.time - startTime;
        burstLength = 1f;
        Debug.Log("Finished swimming after burst of " + burstLength + " seconds.");
    }

    public void tumble()
    {
        Debug.Log("Tumbling...");
        transform.Rotate(Vector3.forward, 200f * Time.deltaTime);
    }

    public void sugarSensor(bool inSugar)
    {
        this.inSugar = inSugar;
        doSomething();
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
