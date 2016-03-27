using UnityEngine;
using System.Collections.Generic;

public class Chemical : MonoBehaviour {

    public enum BacteriaReaction { Attractant, Neutral, Repellent }
    public enum Source { External, Ecoli }

    private Vector3 origin;
    private float concentration, creationTime;
    private GameObject environment;
    private BacteriaReaction ecoliReaction;
    private Source source;

    void Update()
    {
        if (source == Source.Ecoli && Time.time - creationTime >= 10.0f)
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

    public void setConcentration(float concentration)
    {
        this.concentration = concentration;
        transform.localScale += new Vector3(concentration, 100, concentration);
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

    public void setSource(Source source)
    {
        this.source = source;
    }

}
