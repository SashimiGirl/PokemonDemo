using UnityEngine;
using System.Collections;

public class ScreenFader : MonoBehaviour {

    ChangeScene ChangeScene;
    Animator anim;
    bool isFading = false;

    const int AREA1 = 2;
    const int AREA2 = 4;
    const int WALKING = 1;

    // Use this for initialization
    void Start() {

        ChangeScene = GameObject.Find("SceneManager").GetComponent<ChangeScene>();
        anim = GetComponent<Animator>();

    }
    public IEnumerator FadeToClear()
    {
        isFading = true;
        anim.SetTrigger("FadeIn");
        while(isFading)
            yield return null;

    }

    public IEnumerator FadeToBlack()
    {
        isFading = true;
        anim.SetTrigger("FadeOut");
        while (isFading)
            yield return null;

    }

    void AnimationComplete(){
         isFading=false;
        }

    IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        yield return StartCoroutine(FadeToBlack());
        Debug.Log("After Coroutine");
        Debug.Log("Lastscene: " + ChangeScene.lastscene);
        if (ChangeScene.lastscene == AREA1)
            ChangeScene.ChangeToScene(WALKING);
        else if (ChangeScene.lastscene == AREA2)
            ChangeScene.ChangeToScene(WALKING);
        Debug.Log("The END");
    }
}
