using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class encounter : MonoBehaviour
{
    // public Transform target;
    // Use this for initialization
    public float xPosition;
    public float yPosition;
    public GameObject player;
    const int BATTLESCENE = 3;
    ChangeScene ChangeScene;

    void Start()
    {
        ChangeScene = GameObject.Find("SceneManager").GetComponent<ChangeScene>();
    }

    IEnumerator OnTriggerEnter2D(Collider2D other)
    {

        //Debug.Log("An Object Collider");
        player = GameObject.Find("player");

        //GameObject.Find("WarpTrigger").GetComponent<WarpScenes>().lastscene = 2;
        int randomPick = Random.Range(1, 35);
       // Debug.Log("BushEncounter 1-20 if 1");
       // Debug.Log(randomPick);

        PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);


        if (randomPick == 1)
        {
            GameObject.Find("Main Camera").GetComponent<CameraFollow>().encounter();
            ScreenFader sf = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();
            //ChangeScene.lastscene = BATTLESCENE;
            //other.GetComponent<PlayerMove>().lastLevel = Application.loadedLevel;
            yield return StartCoroutine(sf.FadeToBlack());
            ChangeScene.ChangeToScene(BATTLESCENE);
        }
    }
}



