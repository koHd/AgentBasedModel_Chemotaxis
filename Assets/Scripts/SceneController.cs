using UnityEngine;
using System.Collections.Generic;

namespace Assets.Scripts
{
    public class SceneController : MonoBehaviour
    {
        float startTime;
        float timeElapsed;
        [SerializeField]
        private GameObject ecoliPrefab;
        private GameObject _ecoli;
        private int numEcoli;

        void Start()
        {
            startTime = Time.time;
            numEcoli = 50;
            for (int i = 0; i < numEcoli; i++)
            {
                _ecoli = Instantiate(ecoliPrefab) as GameObject;
                _ecoli.transform.position = new Vector3(0, 0.5f, -40f);
            }
        }

        void Update()
        {
            timeElapsed = timeElapsed - startTime;
        }
    }
}
