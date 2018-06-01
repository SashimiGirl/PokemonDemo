using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BagStuff : MonoBehaviour {

    public int pokeballs;
    public Sprite pokeballPic;
    public int berries;
    public Sprite berryPic;
    public int money;

    void Start()
    {
        pokeballs = 5;
        berries = 5;
        money = 100;
    }

    void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
