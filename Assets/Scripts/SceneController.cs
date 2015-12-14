using UnityEngine;
using System.Collections.Generic;

namespace Assets.Scripts
{
    public class SceneController : MonoBehaviour
    {
        float startTime;
        [SerializeField]
        private GameObject ecoliPrefab;
        private GameObject _ecoli;
        private int numEcoli;

        void Start()
        {
            startTime = Time.time;
            numEcoli = 20;
            for (int i = 0; i < numEcoli; i++)
            {
                _ecoli = Instantiate(ecoliPrefab) as GameObject;
                _ecoli.transform.position = new Vector3(0, 0.5f, -30f);
            }
        }

        void Update()
        {
            Debug.Log("Time elapsed: " + (Time.time - startTime));
        }
    }
}
