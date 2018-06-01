using UnityEngine;
using System.Collections;

public class PokemonStats : MonoBehaviour {

    const int SIZE = 4;

    public class Stats
    {
        public Sprite pokeFront;
        public Sprite pokeBack;
        public string pokeName = "";
        public string[] attackName = new string[SIZE];
        public string[] description = new string[SIZE];
        public int[] attackPower = new int[SIZE];
        public int hp = 0;
        public int atk = 0;
        public int sp = 0;
        public int def = 0;
    }

    public Stats poke;
    public Sprite pikachu;
    public Sprite pikachuBack;
    public Sprite growlithe;
    public Sprite growlitheBack;
    public Sprite eevee;
    public Sprite eeveeBack;
    public Sprite mudkip;
    public Sprite mudkipBack;
    public Sprite psyduck;
    public Sprite psyduckBack;
    TeamSetUp TeamSetUp;
    /*
    void Start()
    {
        poke = new Stats();
    }
    */
    public Stats PikaStats()
    {
        poke = new Stats();
        TeamSetUp = GameObject.Find("SetTeam").GetComponent<TeamSetUp>();
        poke.pokeFront = pikachu;
        poke.pokeBack = pikachuBack;
        poke.pokeName = "Pikachu";
        poke.hp = 170;
        poke.atk = 50;
        poke.sp = 85;
        poke.def = 70;
        AttackSet();
        for (int j = 0; j < SIZE; j++)
        {
            poke.attackName[j] = poke.attackName[j];
            poke.description[j] = poke.description[j];
            poke.attackPower[j] = poke.attackPower[j];
        }
        return poke;
    }
    public Stats GrStats()
    {
        poke = new Stats();
        poke.pokeName = "";
        poke.pokeFront = growlithe;
        poke.pokeBack = growlitheBack;
        poke.pokeName = "Growlithe";
        poke.hp = 150;
        poke.atk = 50;
        poke.sp = 65;
        poke.def = 70;
        AttackSet();
        for (int j = 0; j < SIZE; j++)
        {
            poke.attackName[j] = poke.attackName[j];
            poke.description[j] = poke.description[j];
            poke.attackPower[j] = poke.attackPower[j];
        }

        return poke;
    }
    public Stats EvStats()
    {
        poke = new Stats();
        poke.pokeFront = eevee;
        poke.pokeBack = eeveeBack;
        poke.pokeName = "Eevee";
        poke.hp = 200;
        poke.atk = 50;
        poke.sp = 70;
        poke.def = 70;
        AttackSet();
        for (int j = 0; j < SIZE; j++)
        {
            poke.attackName[j] = poke.attackName[j];
            poke.description[j] = poke.description[j];
            poke.attackPower[j] = poke.attackPower[j];
        }
        return poke;
    }

    public Stats MuStats()
    {
        poke = new Stats();
        poke.pokeFront = mudkip;
        poke.pokeBack = mudkipBack;
        poke.pokeName = "Mudkip";
        poke.hp = 160;
        poke.atk = 65;
        poke.sp = 50;
        poke.def = 60;
        AttackSet();
        for (int j = 0; j < SIZE; j++)
        {
            poke.attackName[j] = poke.attackName[j];
            poke.description[j] = poke.description[j];
            poke.attackPower[j] = poke.attackPower[j];
        }
        return poke;
    }
    public Stats PsStats()
    {
        poke = new Stats();
        poke.pokeFront = psyduck;
        poke.pokeBack = psyduckBack;
        poke.pokeName = "Psyduck";
        poke.hp = 200;
        poke.atk = 45;
        poke.sp = 35;
        poke.def = 90;
        AttackSet();
        for (int j = 0; j < SIZE; j++)
        {
            poke.attackName[j] = poke.attackName[j];
            poke.description[j] = poke.description[j];
            poke.attackPower[j] = poke.attackPower[j];
        }
        return poke;
    }

    public void AttackSet()
    {
        for (int i = 0; i < SIZE; i++)
        {
            int index = Random.Range(0, 360);
            if (index >= 0 && index < 70)
            {
                FiveDs(i);
            }
            else if (index >= 70 && index < 140)
            {
                Shank(i);
            }
            else if (index >= 140 && index < 210)
            {
                DoubleTap(i);
            }
            else if (index >= 210 && index < 280)
            {
                Lance(i);
            }
            else if (index >= 280 && index < 330)
            {
                ArmsOff(i);
            }
            else if (index >= 330 && index <= 360)
            {
                AncientOne(i);
            }
            if (i > 0)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    if (poke.attackName[i] == poke.attackName[j])
                    {
                        i--;
                        break;
                    }
                }
            }
        }
    }

    void FiveDs(int i)
    {
        //70
        poke.attackName[i] = "The 5 D's";
        poke.attackPower[i] = 55;
        poke.description[i] = "Dodge, Duck, Dive, Dip, and Dodge";
    }

    void Shank(int i)
    {
        //70
        poke.attackName[i] = "Shank";
        poke.attackPower[i] = 65;
        poke.description[i] = "You can make shank out of anything";
    }
    void DoubleTap(int i)
    {
        //70
        poke.attackName[i] = "Double Tap";
        poke.attackPower[i] = 35;
        poke.description[i] = "Rule number 2.";
    }
    void Lance(int i)
    {
        poke.attackName[i] = "Lance";
        poke.attackPower[i] = 50;
        poke.description[i] = "It's called a lance, hello.";
        //70
    }
    void ArmsOff(int i)
    {
        //50
        poke.attackName[i] = "Arms Off";
        poke.attackPower[i] = 60;
        poke.description[i] = "Tis, but a scratch... I've had worse";
    }
    void AncientOne(int i)
    {
        //30
        poke.attackName[i] = "Antient One";
        poke.attackPower[i] = 100;
        poke.description[i] = "Summon the great power of the almighty... Betty White!";
    }
    void Awake()
    {
        DontDestroyOnLoad(this);
    }
}