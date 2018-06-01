using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{ 
    public int lastscene = 2;
    const int BATTLESCENE = 3;
   // private int tempScene;

    void Awake()
    {
        Debug.Log(gameObject);
        DontDestroyOnLoad(this);
    }

    public void ExitBattle()
    {
        //tempScene = lastscene;
        //lastscene = BATTLESCENE;
        Debug.Log("ExitBattle Called");
        Debug.Log("lastscene: " + lastscene);
        //Debug.Log("tempscene: " + tempScene);
        SceneManager.LoadScene(lastscene);
        lastscene = BATTLESCENE;
        Debug.Log("lastscene: " + lastscene);
        

       // Debug.Log("After change lastscene: " + lastscene);
    }

    public void ChangeToScene(int sceneChange)
    {
        SceneManager.LoadScene(sceneChange);
    }
}
