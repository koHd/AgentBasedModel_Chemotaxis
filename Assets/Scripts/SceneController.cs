using UnityEngine;
using System.Collections.Generic;

namespace Assets.Scripts
{
    public class SceneController : MonoBehaviour
    {
        float startTime;
        float timeElapsed;
        [SerializeField]
        private GameObject ecoliPrefab, checmicalPrefab;
        private GameObject _ecoli, _chemical;
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
            _chemical = Instantiate(checmicalPrefab) as GameObject;
            _chemical.transform.localScale += new Vector3(100.0f, 0, 100.0f);
        }

        void Update()
        {
            timeElapsed = timeElapsed - startTime;
        }
    }
}
