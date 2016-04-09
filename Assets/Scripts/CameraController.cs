using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    private float zoomSpeed = 5f, moveSpeed = 100f;
	
	void Update () {
        if (Input.GetKey("w"))
            Camera.main.orthographicSize += zoomSpeed;
        if (Input.GetKey("s"))
            Camera.main.orthographicSize -= zoomSpeed;
        if (Input.GetKey("a"))
            transform.localPosition += -Vector3.right * Time.deltaTime * moveSpeed;
        if (Input.GetKey("d"))
            transform.localPosition += Vector3.right * Time.deltaTime * moveSpeed;
    }
}
