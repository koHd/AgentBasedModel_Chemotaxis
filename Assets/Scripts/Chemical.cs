using UnityEngine;
using System.Collections.Generic;

public class Chemical : MonoBehaviour {

    public enum BacteriaReaction { Attractant, Neutral, Repellent }

    private Vector3 origin;
    private float concentration, radius;
    private BacteriaReaction ecoliReaction;

    // Use this for initialization
    void Start()
    {

    }

    public void setOrigin(Vector3 location)
    {
        this.origin = location;
    }

    public void setConcentration(float concentration)
    {
        this.concentration = concentration;
    }

    public float getConcentration(Vector3 position)
    {
        return this.concentration * (transform.localScale.magnitude / Vector3.Distance(origin, position));
    }

    public void setEcoliReaction(BacteriaReaction reaction)
    {
        this.ecoliReaction = reaction;
        if (reaction == BacteriaReaction.Repellent) GetComponent<Renderer>().material.SetColor("_Color", Color.red);
    }

    public BacteriaReaction getEcoliReaction()
    {
        return this.ecoliReaction;
    }

}
