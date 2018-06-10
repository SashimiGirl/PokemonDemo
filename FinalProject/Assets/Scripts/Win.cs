using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour {
    ChangeScene ChangeScene;
    public Text win;
    public Text gain;
    BagStuff BagStuff;
    //ChangeScene ChangeScene;
    //public int lastscene;

    void Start()
    {
        ChangeScene = GameObject.Find("SceneManager").GetComponent<ChangeScene>();
        //lastscene=ChangeScene.lastscene;

        BagStuff = GameObject.Find("TrainerBag").GetComponent<BagStuff>();
        win.fontSize = 1;
        gain.fontSize = 1;
        BagStuff.money += 15;
        Debug.Log("Before change lastscene: ");
        Debug.Log(ChangeScene.lastscene);
    }

    void Update()
    {                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
        if (win.fontSize<31)
            win.fontSize += 2;
        if (win.fontSize >= 31 && gain.fontSize<35)
            gain.fontSize += 2;
    }

    public void Change()
    {
        Debug.Log("lastscene Befor Exit battle is called: " + ChangeScene.lastscene);
        //SceneManager.LoadScene(ChangeScene.lastscene);
        ChangeScene.ExitBattle();
    }


}
