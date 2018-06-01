using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HospitalDialog1 : MonoBehaviour {

    ChangeScene ChangeScene;

    // Use this for initialization
    void Start () {

        ChangeScene = GameObject.Find("SceneManager").GetComponent<ChangeScene>();
        ChangeScene.lastscene = Application.loadedLevel;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
