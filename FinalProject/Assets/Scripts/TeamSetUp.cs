using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class TeamSetUp : MonoBehaviour
{
    public ChangeScene ChangeScene;
    const int AREA1 = 2;
    const int SIZE = 4;
    public PokemonStats PokemonStats;
    public PokemonStats.Stats[] pokePlaya = new PokemonStats.Stats[SIZE];
    public Text stats;
    public int i = 0;

    void Start()
    {
        ChangeScene = GameObject.Find("SceneManager").GetComponent<ChangeScene>();
        PokemonStats = GameObject.Find("Pokemon").GetComponent<PokemonStats>();
        for (int j = 0; j < SIZE; j++)
            pokePlaya[j] = new PokemonStats.Stats();
    }

    void Awake()
    {
        DontDestroyOnLoad(this);
    }
    public void SwitchToWalk()
    {
        Debug.Log("Pokemon Name: " + pokePlaya[i].pokeName + "\nHp: " + pokePlaya[i].hp.ToString() + "\nAttack: " + pokePlaya[i].atk.ToString() + "\nSpeed: " + pokePlaya[i].sp.ToString() + "\nDefense: " + pokePlaya[i].def.ToString());
        this.GetComponent<SpriteRenderer>().sprite = pokePlaya[i].pokeFront;
        stats.text = "Pokemon Name: " + pokePlaya[i].pokeName + "\nHp: " + pokePlaya[i].hp.ToString() + "\nAttack: " + pokePlaya[i].atk.ToString() + "\nSpeed: " + pokePlaya[i].sp.ToString() + "\nDefense: " + pokePlaya[i].def.ToString();
        ChangeScene.ChangeToScene(AREA1);
    }
    public void PikaStats(int i)
    {
        Debug.Log("PikaStats Call");
        pokePlaya[i] = PokemonStats.PikaStats();
    }
    public void GrStats(int i)
    {
        Debug.Log("GrStats Call");
        pokePlaya[i] = PokemonStats.GrStats();
    }
    public void EvStats(int i)
    {
        Debug.Log("EvStats Call");
        pokePlaya[i] = PokemonStats.EvStats();
    }
    public void MuStats(int i)
    {
        pokePlaya[i] = PokemonStats.MuStats();
    }
    public void PsStats(int i)
    {
        pokePlaya[i] = PokemonStats.PsStats();
    }
}
