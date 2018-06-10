using UnityEngine;

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

    public Stats PikaStats()
    {
        poke = new Stats()
        {
            pokeFront = pikachu,
            pokeBack = pikachuBack,
            pokeName = "Pikachu",
            hp = 170,
            atk = 50,
            sp = 85,
            def = 70
        };

        AttackSet(poke);

        return poke;
    }

    public Stats GrStats()
    {
        poke = new Stats()
        {
            pokeFront = growlithe,
            pokeBack = growlitheBack,
            pokeName = "Growlithe",
            hp = 150,
            atk = 50,
            sp = 65,
            def = 70
        };

        AttackSet(poke);

        return poke;
    }

    public Stats EvStats()
    {
        poke = new Stats()
        {
            pokeFront = eevee,
            pokeBack = eeveeBack,
            pokeName = "Eevee",
            hp = 200,
            atk = 50,
            sp = 70,
            def = 70
        };

        AttackSet(poke);
        
        return poke;
    }

    public Stats MuStats()
    {
        poke = new Stats()
        {
            pokeFront = mudkip,
            pokeBack = mudkipBack,
            pokeName = "Mudkip",
            hp = 160,
            atk = 65,
            sp = 50,
            def = 60
        };

        AttackSet(poke);

        return poke;
    }

    public Stats PsStats()
    {
        poke = new Stats()
        {
            pokeFront = psyduck,
            pokeBack = psyduckBack,
            pokeName = "Psyduck",
            hp = 200,
            atk = 45,
            sp = 35,
            def = 90
        };
        
        AttackSet(poke);

        return poke;
    }

    public void AttackSet(Stats poke)
    {
        for (int i = 0; i < SIZE; i++)
        {
            int index = UnityEngine.Random.Range(0, 360);
            if (index >= 0 && index < 70)
            {
                FiveDs(poke, i);
            }
            else if (index >= 70 && index < 140)
            {
                Shank(poke, i);
            }
            else if (index >= 140 && index < 210)
            {
                DoubleTap(poke, i);
            }
            else if (index >= 210 && index < 280)
            {
                Lance(poke, i);
            }
            else if (index >= 280 && index < 330)
            {
                ArmsOff(poke, i);
            }
            else if (index >= 330 && index <= 360)
            {
                AncientOne(poke, i);
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

    void FiveDs(Stats poke, int i)
    {
        poke.attackName[i] = "The 5 D's";
        poke.attackPower[i] = 55;
        poke.description[i] = "Dodge, Duck, Dive, Dip, and Dodge";
    }

    void Shank(Stats poke, int i)
    {
        poke.attackName[i] = "Shank";
        poke.attackPower[i] = 65;
        poke.description[i] = "You can make shank out of anything";
    }

    void DoubleTap(Stats poke, int i)
    {
        poke.attackName[i] = "Double Tap";
        poke.attackPower[i] = 35;
        poke.description[i] = "Rule number 2.";
    }

    void Lance(Stats poke, int i)
    {
        poke.attackName[i] = "Lance";
        poke.attackPower[i] = 50;
        poke.description[i] = "It's called a lance, hello.";
    }

    void ArmsOff(Stats poke, int i)
    {
        poke.attackName[i] = "Arms Off";
        poke.attackPower[i] = 60;
        poke.description[i] = "Tis, but a scratch... I've had worse";
    }

    void AncientOne(Stats poke, int i)
    {
        poke.attackName[i] = "Antient One";
        poke.attackPower[i] = 100;
        poke.description[i] = "Summon the great power of the almighty... Betty White!";
    }

    void Awake()
    {
        DontDestroyOnLoad(this);
    }
}