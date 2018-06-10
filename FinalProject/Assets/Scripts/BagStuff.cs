using UnityEngine;
using System.Collections.Generic;

public class BagStuff : MonoBehaviour {

    public const int MAXSIZE = 4;
    PokemonStats pokemonStats;
    public List<PokemonStats.Stats> pokePlaya;
    public int pokeballs;
    public Sprite pokeballPic;
    public int berries;
    public Sprite berryPic;
    public int money;

    void Start()
    {
        pokemonStats = GameObject.FindObjectOfType<PokemonStats>();
        pokePlaya = new List<PokemonStats.Stats>();
        pokeballs = 5;
        berries = 5;
        money = 100;
    }
    
    public int TeamSize()
    {
        return pokePlaya.Count;
    }

    public void PikaStats()
    {
        if (TeamSize() < MAXSIZE)
            pokePlaya.Add(pokemonStats.PikaStats());
    }

    public void GrStats()
    {
        if (TeamSize() < MAXSIZE)
            pokePlaya.Add(pokemonStats.GrStats());
    }

    public void EvStats()
    {
        if (TeamSize() < MAXSIZE)
            pokePlaya.Add(pokemonStats.EvStats());
    }

    public void MuStats()
    {
        if (TeamSize() < MAXSIZE)
            pokePlaya.Add(pokemonStats.MuStats());
    }

    public void PsStats()
    {
        if (TeamSize() < MAXSIZE)
            pokePlaya.Add(pokemonStats.PsStats());
    }

    public void Genrelease(int i)
    {
        if (TeamSize() > i)
            pokePlaya.Remove(pokePlaya[i]);
    }

    void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
