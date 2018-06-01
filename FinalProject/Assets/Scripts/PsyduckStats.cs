using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PsyduckStats : MonoBehaviour {

    const int SIZE = 4;

    public Sprite psyduck;
    public Sprite psyduckBack;
    public string pokeName;
    public int hp;
    public int atk;
    public int sp;
    public int def;
    public string[] attackName = new string[SIZE];
    public string[] description = new string[SIZE];
    public int[] attackPower = new int[SIZE];

    //int i = 0;

    void Start()
    {
        pokeName = "Psyduck";
        hp = 200;
        atk = 45;
        sp = 35;
        def = 90;
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
                Transmutation(i);
            }
            else if (index >= 280 && index < 330)
            {
                ArmsOff(i);
            }
            else if (index >= 330 && index < 360)
            {
                AncientOne(i);
            }
            if (i > 0)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    if (attackName[i] == attackName[j])
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
        attackName[i] = "The 5 D's";
        attackPower[i] = 55;
        description[i] = "Dodge, Duck, Dive, Dip, and Dodge";
    }

    void Shank(int i)
    {
        //70
        attackName[i] = "Shank";
        attackPower[i] = 65;
        description[i] = "You can make shank out of anything";
    }
    void DoubleTap(int i)
    {
        //70
        attackName[i] = "Double Tap";
        attackPower[i] = 35;
        description[i] = "Rule number 2.";
    }
    void Lance(int i)
    {
        attackName[i] = "Lance";
        attackPower[i] = 50;
        description[i] = "It's called a lance, hello.";
        //70
    }
    void ArmsOff(int i)
    {
        //50
        attackName[i] = "Arms Off";
        attackPower[i] = 60;
        description[i] = "Tis, but a scratch... I've had worse";
    }
    void AncientOne(int i)
    {
        //30
        attackName[i] = "Antient One";
        attackPower[i] = 100;
        description[i] = "Summon the great power of the almighty... Betty White!";
    }

    void Transmutation(int i)
    {
        attackName[i] = "Transmutation";
        attackPower[i] = 80;
        description[i] = "Equivalent exchange";
    }
    /*
    void MagicMissle()
    {

    }
    */

    // Use this for initialization
    void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
