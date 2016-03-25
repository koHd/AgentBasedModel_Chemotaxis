using UnityEngine;
using System.Collections;

public class Chemical : MonoBehaviour {

    public enum BacteriaReaction { Attractant, Neutral, Repellent }

    private Vector3 origin;
    private float concentration;
    private BacteriaReaction ecoliReaction;

    // Use this for initialization
    void Start()
    {
        origin = transform.position;
    }

    public int getConcentration(Vector3 position)
    {
        return (int) (transform.localScale.magnitude / Vector3.Distance(origin, position));
    }

    public void setEcoliReaction(BacteriaReaction reaction)
    {
        this.ecoliReaction = reaction;
        if (reaction == BacteriaReaction.Repellent) GetComponent<Renderer>().material.SetColor("_Color", Color.red);
    }

    public BacteriaReaction getEcoliReaction()
    {
        return ecoliReaction;
    }

}
