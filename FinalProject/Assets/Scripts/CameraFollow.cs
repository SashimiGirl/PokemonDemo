using UnityEngine;
using System.Collections;
using System;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    Camera mycam;

    
    // Use this for initialization
    void Start () {
        mycam = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {

        Vector2 movement_vector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        mycam.orthographicSize = (Screen.height / 100f) / 2f;

        if (target && movement_vector != Vector2.zero)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, 0.1f) + new Vector3(0, 0, -1.3f);
        }
        else if (target)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, 0.1f) + new Vector3(0, 0, -1.6f);
        }
	
	}

    public void encounter()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, 0.1f) + new Vector3(0, 0, -0.3f);
    }

}
