using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PokeSwitch : MonoBehaviour {

    public Canvas pokeMenu;
    public GameObject[] pokeSprite;
    public Button[] pokeButton = new Button[4];
    //private ChosenOneStats ChosenOneStats;
    private TeamSetUp TeamSetUp;
    private Fighting Fighting;
    private OpponentPokemon OpponentPokemon;

    public Text Choose;
    public Text Release;
    public bool anymore = false;
    const int WALKINGSCENE = 1;
    const int SIZE = 4;

    // Use this for initialization
    void Start()
    {
        TeamSetUp = GameObject.Find("SetTeam").GetComponent<TeamSetUp>();
        //ChosenOneStats = GameObject.Find("ChosenOne").GetComponent<ChosenOneStats>();
        Fighting = GameObject.Find("Initial").GetComponent<Fighting>();
        OpponentPokemon = GameObject.Find("WildThing").GetComponent<OpponentPokemon>();

        Fighting.chosenIndex = -1;
        Debug.Log("Pokemon Name: " + TeamSetUp.pokePlaya[0].pokeName + "\nHp: " + TeamSetUp.pokePlaya[0].hp.ToString() + "\nAttack: " + TeamSetUp.pokePlaya[0].atk.ToString() + "\nSpeed: " + TeamSetUp.pokePlaya[0].sp.ToString() + "\nDefense: " + TeamSetUp.pokePlaya[0].def.ToString());

        for (int j = 0; j < SIZE; j++)
        {
            if (TeamSetUp.pokePlaya[j].pokeName != "")
            {
                Debug.Log("Poke here at " + j);
                Debug.Log("Poke Name at " + j + " " + TeamSetUp.pokePlaya[j].pokeName);
                pokeSprite[j].GetComponent<SpriteRenderer>().sprite = TeamSetUp.pokePlaya[j].pokeFront;
            }
            else
            {
                Debug.Log("No poke at " + j);
                pokeSprite[j].SetActive(false);
                pokeButton[j].gameObject.SetActive(false);
            }
        }
    }

    public void DeadPoke()
    {
        anymore = false;
        if (Fighting.currentHP[0] <= 0 && pokeSprite[0].activeSelf)
        {
            pokeSprite[0].SetActive(false);
            pokeButton[0].gameObject.SetActive(false);
        }
        if (Fighting.currentHP[1] <= 0 && pokeSprite[1].activeSelf)
        {
            pokeSprite[1].SetActive(false);
            pokeButton[1].gameObject.SetActive(false);
        }
        if (Fighting.currentHP[2] <= 0 && pokeSprite[2].activeSelf)
        {
            pokeSprite[2].SetActive(false);
            pokeButton[2].gameObject.SetActive(false);
        }
        if (Fighting.currentHP[3] <= 0 && pokeSprite[3].activeSelf)
        {
            pokeSprite[3].SetActive(false);
            pokeButton[3].gameObject.SetActive(false);
        }
        for (int i = 0; i < SIZE; i++)
        {
            if (pokeSprite[i].activeSelf)
                anymore = true;
        }
    }

    public void ResetForRelease()
    {
        pokeSprite[0].SetActive(true);
        pokeSprite[1].SetActive(true);
        pokeSprite[2].SetActive(true);
        pokeSprite[3].SetActive(true);
    }
    public void GenRelease(int i)
    {
        TeamSetUp.pokePlaya[i].pokeFront = OpponentPokemon.wildPoke.pokeFront;
        TeamSetUp.pokePlaya[i].pokeBack = OpponentPokemon.wildPoke.pokeBack;
        TeamSetUp.pokePlaya[i].pokeName = OpponentPokemon.wildPoke.pokeName;
        TeamSetUp.pokePlaya[i].hp = OpponentPokemon.wildPoke.hp;
        TeamSetUp.pokePlaya[i].atk = OpponentPokemon.wildPoke.atk;
        TeamSetUp.pokePlaya[i].sp = OpponentPokemon.wildPoke.sp;
        TeamSetUp.pokePlaya[i].def = OpponentPokemon.wildPoke.def;
        for (int j = 0; j < SIZE; j++)
        {
            TeamSetUp.pokePlaya[i].attackName[j] = OpponentPokemon.wildPoke.attackName[j];
            TeamSetUp.pokePlaya[i].description[j] = OpponentPokemon.wildPoke.description[j];
            TeamSetUp.pokePlaya[i].attackPower[j] = OpponentPokemon.wildPoke.attackPower[j];
        }
        //Destroy(GameObject.Find("ChosenOne"));
        SceneManager.LoadScene(WALKINGSCENE);
    }

    public void ReleaseCaught()
    {
        //Destroy(GameObject.Find("ChosenOne"));
        SceneManager.LoadScene(WALKINGSCENE);
    }
    public void Release0()
    {
        GenRelease(0);
    }
    public void Release1()
    {
        GenRelease(1);
    }
    public void Release2()
    {
        GenRelease(2);
    }
    public void Release3()
    {
        GenRelease(3);
    }


    public void HighlightReset()
    {
        Release.text = "Who will you release?";
    }
    public void HighlightCaught()
    {
        Release.text = "Release " + OpponentPokemon.wildPoke.pokeName;
    }
    public void HighlightRelease0()
    {
        Release.text = "Release " + TeamSetUp.pokePlaya[0].pokeName;
    }
    public void HighlightRelease1()
    {
        Release.text = "Release " + TeamSetUp.pokePlaya[1].pokeName;
    }
    public void HighlightRelease2()
    {
        Release.text = "Release " + TeamSetUp.pokePlaya[2].pokeName;
    }
    public void HighlightRelease3()
    {
        Release.text = "Release " + TeamSetUp.pokePlaya[3].pokeName;
    }

    public void HighlightPoke()
    {
        Choose.text = "Who will you choose?";
    }
    public void HighlightExit()
    {
        Choose.text = "Continue battling with " + TeamSetUp.pokePlaya[Fighting.chosenIndex].pokeName;
    }
    public void HighlightPoke0()
    {
        if (Fighting.chosenIndex == 0)
            HighlightExit();
        else
            Choose.text = TeamSetUp.pokePlaya[0].pokeName;
    }
    public void HighlightPoke1()
    {
        if (Fighting.chosenIndex == 1)
            HighlightExit();
        else
            Choose.text = TeamSetUp.pokePlaya[1].pokeName;
    }
    public void HighlightPoke2()
    {
        if (Fighting.chosenIndex == 2)
            HighlightExit();
        else
            Choose.text = TeamSetUp.pokePlaya[2].pokeName;
    }
    public void HighlightPoke3()
    {
        if (Fighting.chosenIndex == 3)
            HighlightExit();
        else
            Choose.text = TeamSetUp.pokePlaya[3].pokeName;
    }
    public void Poke0()
    {
        Fighting.chosenIndex = 0;
        Fighting.Switch();
    }
    public void Poke1()
    {
        Fighting.chosenIndex = 1;
        Fighting.Switch();
    }
    public void Poke2()
    {
        Fighting.chosenIndex = 2;
        Fighting.Switch();
    }
    public void Poke3()
    {
        Fighting.chosenIndex = 3;
        Fighting.Switch(); 
    }
}
