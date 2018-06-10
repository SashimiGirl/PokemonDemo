using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{ 
    public int lastscene = 2;
    const int BATTLESCENE = 3;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void ExitBattle()
    {
        SceneManager.LoadScene(lastscene);
        lastscene = BATTLESCENE;
    }

    public void ChangeToScene(int sceneChange)
    {
        SceneManager.LoadScene(sceneChange);
    }
}
