using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GotoHospital : MonoBehaviour
{
    ScreenFader sf;
    
    public void change()
    {
       //SceneManager.LoadScene(2);
        StartCoroutine(ToHospital());
    }

    IEnumerator ToHospital()
    {
        yield return StartCoroutine(sf.FadeToBlack());
        SceneManager.LoadScene(2);
    } 
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
