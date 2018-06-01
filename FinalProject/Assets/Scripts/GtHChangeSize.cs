using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GtHChangeSize : MonoBehaviour {
    public Image Background;
    public Text Sorry;
    public Text PokemonGetHurt;
    public Button GoHospital;
    ScreenFader sf;
	
    // Use this for initialization
    void Start()
    {
        Sorry.fontSize = 1;
        PokemonGetHurt.fontSize = 1;
        GoHospital.enabled = false;
 //       ChangeScene = GameObject.Find("SceneManager").GetComponent<ChangeScene>();
        sf = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();
        StartCoroutine(sf.FadeToClear());
    }
	
	// Update is called once per frame
	void Update () {
        if (Sorry.fontSize < 25 && PokemonGetHurt.fontSize == 1)
            Sorry.fontSize += 1; 
        if (Sorry.fontSize >= 1)
            Sorry.fontSize -= 2;
        if (PokemonGetHurt.fontSize < 25)
            PokemonGetHurt.fontSize += 1;
        if (PokemonGetHurt.fontSize == 25)
            GoHospital.enabled = true;

	
	}
}
