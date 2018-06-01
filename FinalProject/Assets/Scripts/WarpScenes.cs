using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WarpScenes : MonoBehaviour

{
    ChangeScene ChangeScene;
    ScreenFader sf;
    const int AREA1 = 2;
    const int AREA2 = 4;
    const int WALKSCENE = 1;

    void Start()
    {
        ChangeScene = GameObject.Find("SceneManager").GetComponent<ChangeScene>();
        sf = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();
        StartCoroutine(sf.FadeToClear());
    }

    IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        yield return StartCoroutine(sf.FadeToBlack());
        Debug.Log("After Coroutine");
        Debug.Log("Lastscene: " + ChangeScene.lastscene);
        if (ChangeScene.lastscene == AREA1)
            ChangeScene.ChangeToScene(AREA2);
        else if (ChangeScene.lastscene == AREA2)
            ChangeScene.ChangeToScene(AREA2);
        Debug.Log("The END");
    }
}
