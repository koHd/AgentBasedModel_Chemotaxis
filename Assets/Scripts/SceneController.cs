using UnityEngine;
using System.Collections.Generic;

public class SceneController : MonoBehaviour {

    [SerializeField]
    private GameObject sugarPrefab;
    [SerializeField]
    private GameObject sugarParticlePrefab;
    private GameObject _sugar;
    private Vector3 sugarPosition;
    private GameObject _sugarParticle;
    private Vector3[] neighbours;

    void Start()
    {
        sugarPosition = new Vector3(0, 1, 0);
        neighbours = new Vector3[4];
        for (int i = 0; i < neighbours.Length; i++)
        {
            neighbours[i] = sugarPosition;
        }
        neighbours[0].z++;
        neighbours[1].x++;
        neighbours[2].z--;
        neighbours[3].x--;
    }

    // Update is called once per frame
    void Update ()
    {
	    if (_sugar == null)
        {
            _sugar = Instantiate(sugarPrefab) as GameObject;
            _sugar.transform.position = new Vector3(0, 1, 0);
            foreach (Vector3 position in neighbours)
            {
                _sugarParticle = Instantiate(sugarParticlePrefab) as GameObject;
                _sugarParticle.transform.position = position;
            }
        }
	}
}
