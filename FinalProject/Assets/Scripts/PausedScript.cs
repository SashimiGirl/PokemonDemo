using UnityEngine;
using System.Collections;

public class PausedScript : MonoBehaviour {

    public bool paused;

	// Use this for initialization
	void Start () {
        paused = false;

	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKey (KeyCode.Space))
        {
            paused = !paused;
        }
        if (paused)
        {
            Time.timeScale = 0;
        }
        else if (!paused)
        {
            Time.timeScale = 1;
        }
     }
    /*
    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            paused = !paused;
        }
        if (paused)
        {
            Time.timeScale = 0;
        }
        else if (!paused)
        {
            Time.timeScale = 1;
        }
    }
    */
}
