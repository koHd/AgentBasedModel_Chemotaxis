using UnityEngine;
using System.Collections.Generic;

namespace Assets.Scripts
{
    public class Sugar
    {

        private GameObject _sugar;
        private float size, neighbourSize;
        private Vector3[] neighbourSpawnPoints = new Vector3[4];

        public Sugar(GameObject prefab, float size, Vector3 position)
        {
            this.size = size;
            _sugar = prefab;
            _sugar.transform.position = position;
            _sugar.transform.localScale = new Vector3(size, size, size);
            neighbourSize = this.size / 2;
            if (neighbourSize > 0.2)
            {
                this.buildNeighbourhood();
            }
            Debug.Log("Created new sugar of size: " + size);
        }

        public void buildNeighbourhood()
        {
            for (int i = 0; i < neighbourSpawnPoints.Length; i++)
            {
                neighbourSpawnPoints[i] = _sugar.transform.position;
            }
            neighbourSpawnPoints[0].z++;
            neighbourSpawnPoints[1].x++;
            neighbourSpawnPoints[2].z--;
            neighbourSpawnPoints[3].x--;
        }

        public void spawnNeighbours()
        {
            foreach (Vector3 spawnPoint in neighbourSpawnPoints)
            {
                Sugar neighbour = new Sugar(_sugar, neighbourSize, spawnPoint);
                Debug.Log("Spawned new sugar of size: " + neighbourSize);
                Debug.Log("Spawned new sugar at: " + spawnPoint.x);
            }
        }

        public GameObject getSugar()
        {
            return _sugar;
        }

        public float getSize()
        {
            return size;
        }

        public Vector3[] getNeighbourSpawnPoints()
        {
            return neighbourSpawnPoints;
        }

        public float getNeighbourSize()
        {
            return neighbourSize;
        }
    }
}
