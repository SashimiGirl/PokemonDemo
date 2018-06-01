using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OpponentPokemon : MonoBehaviour {

    public Text wildThingName;
    public Text wildHealthNum;

    PokemonStats PokemonStats;
    public PokemonStats.Stats wildPoke = new PokemonStats.Stats();
    public int power;
    public int currentHP;
    const int SIZE = 4;

    /*
    public Sprite pokeFront;
    public Sprite pokeBack;
    public string pokeName;
    public int hp;
    public int atk;
    public int sp;
    public int def;
    public int currentHP;
    public int power;
    public string[] attackName = new string[SIZE];
    public string[] description = new string[SIZE];
    public int[] attackPower = new int[SIZE];
    */
    // Use this for initialization
    void Start ()
    {
        PokemonStats = GameObject.Find("Pokemon").GetComponent<PokemonStats>();
        //wildPoke = new PokemonStats.Stats();
        int index = 0;
        index = Random.Range(0, 4);


        if (index == 0)
        {
            //GrowlitheStats = GameObject.Find("Growlithe").GetComponent<GrowlitheStats>();
            wildPoke = PokemonStats.GrStats();
        }
        if(index == 1)
        {
            //EeveeStats = GameObject.Find("Eevee").GetComponent<EeveeStats>();
            wildPoke = PokemonStats.EvStats();
        }
        if (index == 2)
        {
            //MudkipStats = GameObject.Find("Mudkip").GetComponent<MudkipStats>();
            wildPoke = PokemonStats.MuStats();
        }
        if (index == 3)
        {
            //PsyduckStats = GameObject.Find("Psyduck").GetComponent<PsyduckStats>();
            wildPoke = PokemonStats.PsStats();
        }
        /*

        if (pokeName != "Growlithe")
        { //Changing the size of the pokemon that are not growlithe...
            transform.localScale += new Vector3(5F, 5F, 5F); //I won't need this when they...
            //transform.position += new Vector3(0, 0.14f, 0); //Are all the same size
        }
        */
        //GetComponent<Image>().sprite = pokeFront;
        GetComponent<SpriteRenderer>().sprite = wildPoke.pokeFront;
        currentHP = wildPoke.hp;
        wildHealthNum.text = currentHP.ToString() + "/" + wildPoke.hp.ToString();
        wildThingName.text = wildPoke.pokeName;
    }
    /*
    public void GrStats()
    {
        GrowlitheStats = GameObject.Find("Growlithe").GetComponent<GrowlitheStats>();
        pokeFront = GrowlitheStats.growlithe;
        pokeBack = GrowlitheStats.growlitheBack;
        pokeName = GrowlitheStats.pokeName;
        hp = GrowlitheStats.hp;
        atk = GrowlitheStats.atk;
        sp = GrowlitheStats.sp;
        def = GrowlitheStats.def;
        GrowlitheStats.AttackSet();
        for(int i = 0; i < SIZE; i++)
        {
            attackName[i] = GrowlitheStats.attackName[i];
            description[i] = GrowlitheStats.description[i];
            attackPower[i] = GrowlitheStats.attackPower[i];
        }
    }
    public void EvStats()
    {
        EeveeStats = GameObject.Find("Eevee").GetComponent<EeveeStats>();
        pokeFront = EeveeStats.eevee;
        pokeBack = EeveeStats.eeveeBack;
        pokeName = EeveeStats.pokeName;
        hp = EeveeStats.hp;
        atk = EeveeStats.atk;
        sp = EeveeStats.sp;
        def = EeveeStats.def;
        EeveeStats.AttackSet();
        for (int j = 0; j < SIZE; j++)
        {
            attackName[j] = EeveeStats.attackName[j];
            description[j] = EeveeStats.description[j];
            attackPower[j] = EeveeStats.attackPower[j];
        }
    }
    public void MuStats()
    {
        MudkipStats = GameObject.Find("Mudkip").GetComponent<MudkipStats>();
        pokeFront = MudkipStats.mudkip;
        pokeBack = MudkipStats.mudkipBack;
        pokeName = MudkipStats.pokeName;
        hp = MudkipStats.hp;
        atk = MudkipStats.atk;
        sp = MudkipStats.sp;
        def = MudkipStats.def;
        MudkipStats.AttackSet();
        for (int i = 0; i < SIZE; i++)
        {
            attackName[i] = MudkipStats.attackName[i];
            description[i] = MudkipStats.description[i];
            attackPower[i] = MudkipStats.attackPower[i];
        }
    }
    public void PsStats()
    {
        PsyduckStats = GameObject.Find("Psyduck").GetComponent<PsyduckStats>();
        pokeFront = PsyduckStats.psyduck;
        pokeBack = PsyduckStats.psyduckBack;
        pokeName = PsyduckStats.pokeName;
        hp = PsyduckStats.hp;
        atk = PsyduckStats.atk;
        sp = PsyduckStats.sp;
        def = PsyduckStats.def;
        PsyduckStats.AttackSet();
        for (int i = 0; i < SIZE; i++)
        {
            attackName[i] = PsyduckStats.attackName[i];
            description[i] = PsyduckStats.description[i];
            attackPower[i] = PsyduckStats.attackPower[i];
        }
    }
    */

    public void WildAttack()
    {
        int ran = Random.Range(0, 4);
        power = wildPoke.attackPower[ran];
    }
	
	
}
