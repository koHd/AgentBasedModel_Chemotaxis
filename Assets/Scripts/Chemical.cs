using UnityEngine;
using System.Collections.Generic;

public class Chemical : MonoBehaviour {

    public enum BacteriaReaction { Attractant, Neutral, Repellent }

    private Vector3 origin;
    private float concentration;
    private BacteriaReaction ecoliReaction;

    public void setOrigin(Vector3 location)
    {
        this.origin = location;
        transform.position = location;
    }

    public void setConcentration(float concentration)
    {
        this.concentration = concentration;
        transform.localScale += new Vector3(concentration, concentration, concentration);
    }

    public float getConcentrationAtPosition(Vector3 position)
    {
        return (concentration / 2) / Vector3.Distance(origin, position);
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

}
