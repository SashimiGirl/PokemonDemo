using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OpponentPokemon : MonoBehaviour {

    public Text wildThingName;
    public Text wildHealthNum;

    PokemonStats pokemonStats;
    public PokemonStats.Stats wildPoke = new PokemonStats.Stats();
    public int power;
    public int currentHP;
    const int SIZE = 4;

    // Use this for initialization
    void Start ()
    {
        pokemonStats = GameObject.FindObjectOfType<PokemonStats>();
        int index = Random.Range(0, 4);

        if (index == 0)
        {
            wildPoke = pokemonStats.GrStats();
        }
        if(index == 1)
        {
            wildPoke = pokemonStats.EvStats();
        }
        if (index == 2)
        {
            wildPoke = pokemonStats.MuStats();
        }
        if (index == 3)
        {
            wildPoke = pokemonStats.PsStats();
        }
        GetComponent<Image>().sprite = wildPoke.pokeFront;
        currentHP = wildPoke.hp;
        wildHealthNum.text = currentHP.ToString() + "/" + wildPoke.hp.ToString();
        wildThingName.text = wildPoke.pokeName;
    }

    public void WildAttack()
    {
        int ran = Random.Range(0, 4);
        power = wildPoke.attackPower[ran];
    }
}
