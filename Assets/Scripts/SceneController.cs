using UnityEngine;
using System.Collections.Generic;

namespace Assets.Scripts
{
    public class SceneController : MonoBehaviour
    {
        [SerializeField] GameObject sugarPrefab;
        private GameObject _sugar;

        void Update()
        {
            if (_sugar == null)
            {
                _sugar = Instantiate(sugarPrefab) as GameObject;
                Sugar sugar = new Sugar(_sugar, 1, new Vector3(0, 1, 0));
            }
        }
    }
}
