using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PokeSwitch : MonoBehaviour {

    public Canvas pokeMenu;
    public GameObject[] pokeSprite;
    public Button[] pokeButton = new Button[4];
    private BagStuff bagStuff;
    private Fighting fighting;
    private OpponentPokemon opponentPokemon;

    public Text choose;
    public Text release;
    public bool anymore = false;
    const int WALKINGSCENE = 1;
    const int SIZE = 4;

    // Use this for initialization
    void Start()
    {
        bagStuff = GameObject.FindObjectOfType<BagStuff>();
        fighting = GameObject.Find("Initial").GetComponent<Fighting>();
        opponentPokemon = GameObject.Find("WildThing").GetComponent<OpponentPokemon>();

        fighting.chosenIndex = -1;
        
        for (int j = 0; j < SIZE; j++)
        {
            if (bagStuff.TeamSize() > j)
            {
                pokeSprite[j].GetComponent<Image>().sprite = bagStuff.pokePlaya[j].pokeFront;
            }
            else
            {
                pokeSprite[j].SetActive(false);
                pokeButton[j].gameObject.SetActive(false);
            }
        }
    }

    public void DeadPoke()
    {
        anymore = false;
        if (fighting.currentHP[0] <= 0 && pokeSprite[0].activeSelf)
        {
            pokeSprite[0].SetActive(false);
            pokeButton[0].gameObject.SetActive(false);
        }
        if (fighting.currentHP[1] <= 0 && pokeSprite[1].activeSelf)
        {
            pokeSprite[1].SetActive(false);
            pokeButton[1].gameObject.SetActive(false);
        }
        if (fighting.currentHP[2] <= 0 && pokeSprite[2].activeSelf)
        {
            pokeSprite[2].SetActive(false);
            pokeButton[2].gameObject.SetActive(false);
        }
        if (fighting.currentHP[3] <= 0 && pokeSprite[3].activeSelf)
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

    public void Genrelease(int i)
    {
        bagStuff.pokePlaya[i].pokeFront = opponentPokemon.wildPoke.pokeFront;
        bagStuff.pokePlaya[i].pokeBack = opponentPokemon.wildPoke.pokeBack;
        bagStuff.pokePlaya[i].pokeName = opponentPokemon.wildPoke.pokeName;
        bagStuff.pokePlaya[i].hp = opponentPokemon.wildPoke.hp;
        bagStuff.pokePlaya[i].atk = opponentPokemon.wildPoke.atk;
        bagStuff.pokePlaya[i].sp = opponentPokemon.wildPoke.sp;
        bagStuff.pokePlaya[i].def = opponentPokemon.wildPoke.def;
        for (int j = 0; j < SIZE; j++)
        {
            bagStuff.pokePlaya[i].attackName[j] = opponentPokemon.wildPoke.attackName[j];
            bagStuff.pokePlaya[i].description[j] = opponentPokemon.wildPoke.description[j];
            bagStuff.pokePlaya[i].attackPower[j] = opponentPokemon.wildPoke.attackPower[j];
        }
        fighting.RunButton();
    }

    public void ReleaseCaught()
    {
        fighting.RunButton();
    }

    public void Release0()
    {
        Genrelease(0);
    }

    public void Release1()
    {
        Genrelease(1);
    }

    public void Release2()
    {
        Genrelease(2);
    }

    public void Release3()
    {
        Genrelease(3);
    }

    public void HighlightReset()
    {
        release.text = "Who will you release?";
    }

    public void HighlightCaught()
    {
        release.text = "release " + opponentPokemon.wildPoke.pokeName;
    }

    public void HighlightRelease0()
    {
        release.text = "release " + bagStuff.pokePlaya[0].pokeName;
    }

    public void HighlightRelease1()
    {
        release.text = "release " + bagStuff.pokePlaya[1].pokeName;
    }

    public void HighlightRelease2()
    {
        release.text = "release " + bagStuff.pokePlaya[2].pokeName;
    }

    public void HighlightRelease3()
    {
        release.text = "release " + bagStuff.pokePlaya[3].pokeName;
    }

    public void HighlightPoke()
    {
        choose.text = "Who will you choose?";
    }

    public void HighlightExit()
    {
        choose.text = "Continue battling with " + bagStuff.pokePlaya[fighting.chosenIndex].pokeName;
    }

    public void HighlightPoke0()
    {
        if (fighting.chosenIndex == 0)
            HighlightExit();
        else
            choose.text = bagStuff.pokePlaya[0].pokeName;
    }

    public void HighlightPoke1()
    {
        if (fighting.chosenIndex == 1)
            HighlightExit();
        else
            choose.text = bagStuff.pokePlaya[1].pokeName;
    }

    public void HighlightPoke2()
    {
        if (fighting.chosenIndex == 2)
            HighlightExit();
        else
            choose.text = bagStuff.pokePlaya[2].pokeName;
    }

    public void HighlightPoke3()
    {
        if (fighting.chosenIndex == 3)
            HighlightExit();
        else
            choose.text = bagStuff.pokePlaya[3].pokeName;
    }

    public void Poke0()
    {
        fighting.chosenIndex = 0;
        fighting.Switch();
    }

    public void Poke1()
    {
        fighting.chosenIndex = 1;
        fighting.Switch();
    }

    public void Poke2()
    {
        fighting.chosenIndex = 2;
        fighting.Switch();
    }

    public void Poke3()
    {
        fighting.chosenIndex = 3;
        fighting.Switch(); 
    }
}
