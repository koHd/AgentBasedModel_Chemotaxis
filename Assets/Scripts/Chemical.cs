using UnityEngine;
using System.Collections.Generic;

public class Chemical : MonoBehaviour {

    public enum BacteriaReaction { Attractant, Neutral, Repellent }
    public enum Source { External, Ecoli }

    private Vector3 origin;
    private float concentration, width, creationTime;
    private GameObject environment;
    private BacteriaReaction ecoliReaction;
    private Source source;

    void Update()
    {
        if (source == Source.Ecoli && Time.time - creationTime > 3.0f)
        {
            environment.GetComponent<Agar>().removeChemical(this.gameObject);
            Destroy(this.gameObject);
        }
    }

    public void setOrigin(GameObject environment, Vector3 location)
    {
        this.origin = location;
        transform.position = location;
        this.environment = environment;
        creationTime = Time.time;
    }

    public void moveOrigin(Vector3 location)
    {
        this.origin = location;
        transform.position = location;
    }

    public void setConcentration(float concentration)
    {
        this.concentration = concentration;
    }

    public void setWidth(float width)
    {
        this.width = width;
        transform.localScale += new Vector3(this.width, 0, this.width);
    }

    public float getConcentrationAtPosition(Vector3 position)
    {
        float concentrationAtPosition = 0;
        float distanceFromOrigin = Vector3.Distance(origin, position);
        if (position == origin) concentrationAtPosition = concentration;
        else if (distanceFromOrigin > (width/2)) concentrationAtPosition = 0;
        else concentrationAtPosition = (concentration / (width / 2)) / distanceFromOrigin;
        return (ecoliReaction == BacteriaReaction.Attractant) ? concentrationAtPosition : -concentrationAtPosition;
    }

    public void setEcoliReaction(BacteriaReaction reaction)
    {
        this.ecoliReaction = reaction;
        if (reaction == BacteriaReaction.Repellent) GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        else GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
    }

    public BacteriaReaction getEcoliReaction()
    {
        return this.ecoliReaction;
    }

    public void setSource(Source source)
    {
        this.source = source;
    }

}
