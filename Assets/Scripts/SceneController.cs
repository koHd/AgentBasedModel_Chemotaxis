using UnityEngine;
using System.Collections.Generic;

namespace Assets.Scripts
{
    public class SceneController : MonoBehaviour
    {
        float startTime;

        void Start()
        {
            startTime = Time.time;
        }

        void Update()
        {
            Debug.Log("Time elapsed: " + (Time.time - startTime));
        }
    }
}
