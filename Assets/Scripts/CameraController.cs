using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    private float zoomSpeed = 5f, moveSpeed = 2000f;
	
	void Update () {
        // zoom control
        if (Input.GetKey("down") && Camera.main.orthographicSize <= 1500)
            Camera.main.orthographicSize += zoomSpeed; // zoom out
        if (Input.GetKey("up") && Camera.main.orthographicSize >= 20f)
            Camera.main.orthographicSize -= zoomSpeed; // zoom in

        // pan control
        if (Input.GetKey("w"))
            transform.localPosition += Vector3.forward * Time.deltaTime * moveSpeed; // pan up
        if (Input.GetKey("s"))
            transform.localPosition += -Vector3.forward * Time.deltaTime * moveSpeed; // pan down
        if (Input.GetKey("a"))
            transform.localPosition += -Vector3.right * Time.deltaTime * moveSpeed; // pan left
        if (Input.GetKey("d"))
            transform.localPosition += Vector3.right * Time.deltaTime * moveSpeed; // pan right
    }
}
