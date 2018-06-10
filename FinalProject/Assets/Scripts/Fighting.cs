using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fighting : MonoBehaviour
{
    public BagStuff bagStuff;
    public PokeSwitch pokeSwitch;
    public ChangeScene changeScene;
    public PokemonStats pokemonStats;
    public OpponentPokemon opponentPokemon;

    public PokemonStats.Stats[] chosenPoke = new PokemonStats.Stats[SIZE];
    public int[] currentHP = new int[SIZE];

    public int chosenIndex = -1;

    public Canvas initial; //The Canvas that holds the first menu: fight, pokemon, bag, and run
    public Canvas attacks; //The Canvas that holds the 4 set of attacks for our pokemon
    public Canvas bag; //The Canvas that holds the buttons for bag and switching pokemon
    public Canvas bribe;
    public Canvas pokeMenu;
    public Canvas hp;
    public Canvas wildhp;
    public Canvas words;
    public Canvas releaseMenu;

    public Text chooseFighter;
    public Text commands; //Text box that gives the instructions next to the menus/options
    public Text pokemonName; //Text box for our pokemon's name
    public Text healthNum; //Text box for our pokemon's health

    public Button option1; //Button for the top left option for pokemon/bag
    public Button option2; //Button for the top right option for pokemon/bag
    public Button option3; //Button for the bottom left option for pokemon/bag
    public Button option4; //Button for the bottom right option for pokemon/bag
    public Button backButton;

    public Button runOption;
    public Button bOption1; //Button for the top left option for bribes
    public Button bOption2; //Button for the top right option for bribes
    public Button bOption3; //Button for the bottom left option for bribes
    public Button bOption4; //Button for the bottom right option for bribes
    public Button bBackButton;

    public Text[] attackName = new Text[SIZE];
    public int[] attackPower = new int[SIZE];

    public Button exit;
    public GameObject menuBox;
    public GameObject pokeBackground1;
    public GameObject pokeBackground2;
    public GameObject pokeBackground3;
    public GameObject pokeBackground4;

    public GameObject pokeballObject;
    public GameObject garyObject;
    public GameObject berryObject;

    public GameObject wildThing;
    public GameObject pokemon; //Our pokemon Game Object

    const int WINSCENE = 5;
    const int WALKINGSCENE = 1; //This is the menu scene's build number
    const int POKECENTER = 6;
    const int DEAD = 0; //This is the health comparison to see if pokemon is... fainted
    const int EMPTY = 0;
    const int SIZE = 4;

    int pokeCatch = 0;
    public int runChance = 0;

    void Start()
    {
        //Grabbing scripts
        bagStuff = GameObject.Find("TrainerBag").GetComponent<BagStuff>();
        pokeSwitch = GameObject.Find("PokeMenu").GetComponent<PokeSwitch>();
        pokemonStats = GameObject.Find("Pokemon").GetComponent<PokemonStats>();
        changeScene = GameObject.Find("SceneManager").GetComponent<ChangeScene>();
        opponentPokemon = GameObject.Find("WildThing").GetComponent<OpponentPokemon>();
        /*
        for (int j = 0; j < SIZE; j++) //Setting up pokemenu
            chosenPoke[j] = new PokemonStats.Stats();
        for (int j = 0; j < bagStuff.TeamSize(); j++)
        {
            if (bagStuff.pokePlaya[j].pokeName != "")
            {
                chosenPoke[j].pokeFront = bagStuff.pokePlaya[j].pokeFront;
                chosenPoke[j].pokeBack = bagStuff.pokePlaya[j].pokeBack;
                chosenPoke[j].pokeName = bagStuff.pokePlaya[j].pokeName;
                chosenPoke[j].hp = bagStuff.pokePlaya[j].hp;
                chosenPoke[j].atk = bagStuff.pokePlaya[j].atk;
                chosenPoke[j].sp = bagStuff.pokePlaya[j].sp;
                chosenPoke[j].def = bagStuff.pokePlaya[j].def;
                currentHP[j] = bagStuff.pokePlaya[j].hp;
                for (int k = 0; k < SIZE; k++)
                {
                    chosenPoke[j].attackName[k] = bagStuff.pokePlaya[j].attackName[k];
                    chosenPoke[j].description[k] = bagStuff.pokePlaya[j].description[k];
                    chosenPoke[j].attackPower[k] = bagStuff.pokePlaya[j].attackPower[k];
                }

            }
            else
                break;
        }*/
        for (int k = 0; k < bagStuff.TeamSize(); k++)
        {
            currentHP[k] = bagStuff.pokePlaya[k].hp;
        }
        Switch();
        PokemonSwitch();
        exit.gameObject.SetActive(false);
    }

    public void Switch()
    {
        //Changing our pokemon pic to the correct pokemon
        pokemon.GetComponent<Image>().sprite = bagStuff.pokePlaya[chosenIndex].pokeBack;

        garyObject.SetActive(false);
        pokeballObject.SetActive(false);
        berryObject.SetActive(false);
        pokemon.SetActive(true);
        wildThing.SetActive(true);

        pokemonName.text = bagStuff.pokePlaya[chosenIndex].pokeName; //Setting our pokemon's name to the one chosen
        healthNum.text = currentHP[chosenIndex].ToString() + "/" + bagStuff.pokePlaya[chosenIndex].hp.ToString(); //Setting the initial health for our pokemon
        commands.text = "What will " + bagStuff.pokePlaya[chosenIndex].pokeName + " do?"; //Asking the user to choose something
        initial.enabled = true; //Turns on the initial menu by turning off canvas
        attacks.enabled = false; //Turns off the attack menu by turning off canvas
        bag.enabled = false; //Turns off the pokemon bag
        bribe.enabled = false;
        releaseMenu.enabled = false;
        pokeMenu.enabled = false;
        hp.enabled = true;
        wildhp.enabled = true;
        words.enabled = true;
        menuBox.SetActive(false);
        pokeBackground1.SetActive(false);
        pokeBackground2.SetActive(false);
        pokeBackground3.SetActive(false);
        pokeBackground4.SetActive(false);
        runOption.gameObject.SetActive(false);
        bOption1.gameObject.SetActive(false);
        bOption2.gameObject.SetActive(false);
        bOption3.gameObject.SetActive(false);
        bOption4.gameObject.SetActive(false);
        bBackButton.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);

        for (int i = 0; i < SIZE; i ++)
        {
            attackName[i].text = bagStuff.pokePlaya[chosenIndex].attackName[i];
            attackPower[i] = bagStuff.pokePlaya[chosenIndex].attackPower[i];
        }
    }

    public void WildDead() //Changing the scene if the wild pokemon... faints
    {
        changeScene.ChangeToScene(WINSCENE);
    } 

    public void PokeDied()
    {
        pokeSwitch.DeadPoke();
        if(pokeSwitch.anymore)
        {
            PokemonSwitch();
            exit.gameObject.SetActive(false);
        }
        else
        {
            changeScene.ChangeToScene(POKECENTER);
        }
    }

    public void RunButton()
    {
        changeScene.ExitBattle();
    }

    public void LikeTheWind() //Chaning the scene if trainer runs... dif from wild dead if we want to add experience/not being able to run...
    {
        commands.text = "What would you like to use to try bribing the wild " + opponentPokemon.wildPoke.pokeName + "?";
        initial.enabled = false; //Turns off the initial menu by turning off canvas
        attacks.enabled = false; //Turns off the attack menu by turning off canvas

        bOption1.gameObject.SetActive(false);
        bOption2.gameObject.SetActive(false);
        bOption3.gameObject.SetActive(false);
        bOption4.gameObject.SetActive(false);
        bribe.enabled = true; //Turns on the pokemon bag
        bBackButton.gameObject.SetActive(true);
        if (bagStuff.berries == EMPTY)
        {
            commands.text = "You have nothing to use in your bag...\nYou can't bribe the wild " + opponentPokemon.wildPoke.pokeName + "...\nGood luck!";
        }
        else
        {
             if (bagStuff.berries > 0)
            {
                bOption1.GetComponentInChildren<Text>().text = "x" + bagStuff.berries;
                bOption1.gameObject.SetActive(true);
                bOption1.GetComponent<Image>().sprite = bagStuff.berryPic;
            }
        }
    }

    public void BribeOption1()
    {
        bagStuff.berries--;
        StartCoroutine(BerryPlay());
    }

    IEnumerator BerryPlay()
    {
        bribe.enabled = false;
        pokemon.SetActive(false);
        garyObject.SetActive(true);
        yield return new WaitForSeconds(0.65f);
        berryObject.SetActive(true);

        yield return new WaitForSeconds(1.35f);
        berryObject.GetComponent<Animator>().speed = 0;
        runChance = Random.Range(0, 50);
        if (runChance != 2)
        {
            commands.text = "The wild " + opponentPokemon.wildPoke.pokeName + " is distracted by the berry!";

            runOption.gameObject.SetActive(true);
            yield return new WaitForSeconds(2f);
            Switch();
            berryObject.GetComponent<Animator>().speed = 1;
        }
        else
        {
            commands.text = "The wild " + opponentPokemon.wildPoke.pokeName + " did not like the berry!";
            wildThing.GetComponent<Animator>().SetBool("Smack", true);

            yield return new WaitForSeconds(.2f);
            berryObject.GetComponent<Animator>().speed = 5;
            yield return new WaitForSeconds(.5f);
            berryObject.GetComponent<Animator>().speed = 1;
            berryObject.SetActive(false);
            wildThing.GetComponent<Animator>().SetBool("Smack", false);
            yield return new WaitForSeconds(1f);
            Switch();
        }
    }

    
    public void BagOption()
    {
        initial.enabled = false; //Turns off the initial menu by turning off canvas
        attacks.enabled = false; //Turns off the attack menu by turning off canvas
        
        option1.gameObject.SetActive(false);
        option2.gameObject.SetActive(false);
        option3.gameObject.SetActive(false);
        option4.gameObject.SetActive(false);
        bag.enabled = true; //Turns on the pokemon bag
        backButton.gameObject.SetActive(true);
        if (bagStuff.pokeballs == EMPTY && bagStuff.berries == EMPTY)
        {
            commands.text = "You have nothing to use in your bag...\nYou're probably in trouble...\nGood luck!";
        }
        else
        {
            if (bagStuff.pokeballs > 0)
            {
                option1.GetComponentInChildren<Text>().text = "x" + bagStuff.pokeballs;
                option1.gameObject.SetActive(true);
                option1.GetComponent<Image>().sprite = bagStuff.pokeballPic;
            }
        }
    }

    public void Option1Button()
    {
        if(option1.GetComponentInChildren<Text>().text == "x" + bagStuff.berries)
        {
            //Do berry stuffz
        }
        if(option1.GetComponentInChildren<Text>().text == "x" + bagStuff.pokeballs)
        {
            bag.enabled = false;
            StartCoroutine(PokePlay());
        }
    }
    public void Option2Button()
    {
        if (option1.GetComponentInChildren<Text>().text == "x" + bagStuff.berries)
        {
            //Do berry stuffz
        }
        if (option1.GetComponentInChildren<Text>().text == "x" + bagStuff.pokeballs)
        {
            bag.enabled = false;
            StartCoroutine(PokePlay());
        }
    }

    IEnumerator PokePlay()
    {
        pokemon.SetActive(false);
        garyObject.SetActive(true);
        yield return new WaitForSeconds(0.65f);
        pokeballObject.SetActive(true);

        yield return new WaitForSeconds(1.3f);

        wildThing.SetActive(false);

        if (opponentPokemon.currentHP / opponentPokemon.wildPoke.hp > 0.9f)
            pokeCatch = Random.Range(0, 50);
        else if (opponentPokemon.currentHP / opponentPokemon.wildPoke.hp > 0.7f)
            pokeCatch = Random.Range(0, 40);
        else if (opponentPokemon.currentHP / opponentPokemon.wildPoke.hp > 0.5f)
            pokeCatch = Random.Range(0, 30);
        else if (opponentPokemon.currentHP / opponentPokemon.wildPoke.hp > 0.3f)
            pokeCatch = Random.Range(0, 15);
        else if (opponentPokemon.currentHP / opponentPokemon.wildPoke.hp > 0.1f)
            pokeCatch = Random.Range(0, 4);
        else if (opponentPokemon.currentHP / opponentPokemon.wildPoke.hp <= 0.1f)
            pokeCatch = 2;

        if (pokeCatch == 2)
        {
            yield return new WaitForSeconds(5f);
            commands.text = "You caught " + opponentPokemon.wildPoke.pokeName + "!";
        }
        else
        {
            yield return new WaitForSeconds(3.2f);
            pokeballObject.GetComponent<Animator>().speed = 50;
            yield return new WaitForSeconds(.5f);
            pokeballObject.GetComponent<Animator>().speed = 1;
        }
        Pokeball();
    }

    public void Pokeball()
    {
        bagStuff.pokeballs -= 1;
        if (pokeCatch == 2)
        {
            if (bagStuff.TeamSize() < BagStuff.MAXSIZE)
            {
                bagStuff.pokePlaya.Add(opponentPokemon.wildPoke);
                changeScene.ExitBattle();
            } else
            {
                PokemonSwitch();
                pokeMenu.enabled = false;
                pokeSwitch.ResetForRelease();
                releaseMenu.enabled = true;
            }
        }
        else
        {
            Switch();
            commands.text = opponentPokemon.wildPoke.pokeName + " faught its way free.\nWhat will " + bagStuff.pokePlaya[chosenIndex].pokeName + " do?";
            double opdamage = (double)opponentPokemon.wildPoke.atk / (double)bagStuff.pokePlaya[chosenIndex].def * (double)opponentPokemon.power;
            currentHP[chosenIndex] = currentHP[chosenIndex] - (int)opdamage;

            opponentPokemon.wildHealthNum.text = opponentPokemon.currentHP.ToString() + "/" + opponentPokemon.wildPoke.hp.ToString();

            if (opponentPokemon.currentHP <= DEAD)
            {
                WildDead();
            }
        }
    }

    public void BackButton() //Returns the original options
    {
        initial.enabled = true; //Turns on the initial menu by turning off canvas
        attacks.enabled = false; //Turns off the attack menu by turning off canvas
        words.enabled = true;
        commands.text = "What will " + bagStuff.pokePlaya[chosenIndex].pokeName + " do?";
        bribe.enabled = false;
        bOption1.gameObject.SetActive(false);
        bOption2.gameObject.SetActive(false);
        bOption3.gameObject.SetActive(false);
        bOption4.gameObject.SetActive(false);
        bBackButton.gameObject.SetActive(false);
        option1.gameObject.SetActive(false);
        option2.gameObject.SetActive(false);
        option3.gameObject.SetActive(false);
        option4.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);
        menuBox.SetActive(false);
        pokeBackground1.SetActive(false);
        pokeBackground2.SetActive(false);
        pokeBackground3.SetActive(false);
        pokeBackground4.SetActive(false);
        pokeMenu.enabled = false;
        hp.enabled = true;
        wildhp.enabled = true;
    }

    public void PokemonSwitch()
    {
        initial.enabled = false;
        attacks.enabled = false;
        hp.enabled = false;
        wildhp.enabled = false;
        words.enabled = false;
        menuBox.SetActive(true);
        pokeBackground1.SetActive(true);
        pokeBackground2.SetActive(true);
        pokeBackground3.SetActive(true);
        pokeBackground4.SetActive(true);
        exit.gameObject.SetActive(true);
        pokeMenu.enabled = true;
    }

    public void FightSwitch() //Change from initial menu to attack menu when Fight button is clicked
    {
        commands.text = "Which attack should " + bagStuff.pokePlaya[chosenIndex].pokeName + " use?"; //Self explanitory
        initial.enabled = false; //Turns off the attack menu by turning off canvas
        attacks.enabled = true;//Turns on the attack menu by turning off canvas
    }

    public void HighlightReset()
    {
        commands.text = "What will " + bagStuff.pokePlaya[chosenIndex].pokeName + " do?";
    }
    public void HighlightAttack1()
    {
        commands.text = bagStuff.pokePlaya[chosenIndex].description[0];
    }
    public void HighlightAttack2()
    {
        commands.text = bagStuff.pokePlaya[chosenIndex].description[1];
    }
    public void HighlightAttack3()
    {
        commands.text = bagStuff.pokePlaya[chosenIndex].description[2];
    }
    public void HighlightAttack4()
    {
        commands.text = bagStuff.pokePlaya[chosenIndex].description[3];
    }
    
    IEnumerator AttackCalc(int i)
    {
        attacks.enabled = false; //Returns to initial menu
        opponentPokemon.WildAttack();
        double mydamage = (double)bagStuff.pokePlaya[chosenIndex].atk / (double)opponentPokemon.wildPoke.def * (double)attackPower[i];
        double opdamage = (double)opponentPokemon.wildPoke.atk / (double)bagStuff.pokePlaya[chosenIndex].def * (double)opponentPokemon.power;

        if (bagStuff.pokePlaya[chosenIndex].sp >= opponentPokemon.wildPoke.sp)
        {
            pokemon.GetComponent<Animator>().SetBool("Attack", true);
            yield return new WaitForSeconds(.5f);
            pokemon.GetComponent<Animator>().SetBool("Attack", false);

            opponentPokemon.currentHP = opponentPokemon.currentHP - (int)mydamage;
            opponentPokemon.wildHealthNum.text = opponentPokemon.currentHP.ToString() + "/" + opponentPokemon.wildPoke.hp.ToString();
            if (opponentPokemon.currentHP <= DEAD)
            {
                WildDead();
            }
            else
            {
                wildThing.GetComponent<Animator>().SetBool("Smack", true);
                yield return new WaitForSeconds(.5f);
                wildThing.GetComponent<Animator>().SetBool("Smack", false);
                currentHP[chosenIndex] = currentHP[chosenIndex] - (int)opdamage;
                healthNum.text = currentHP[chosenIndex].ToString() + "/" + bagStuff.pokePlaya[chosenIndex].hp.ToString();
            }
        }
        else
        {
            wildThing.GetComponent<Animator>().SetBool("Smack", true);
            yield return new WaitForSeconds(.5f);
            wildThing.GetComponent<Animator>().SetBool("Smack", false);
            currentHP[chosenIndex] = currentHP[chosenIndex] - (int)opdamage;
            healthNum.text = currentHP[chosenIndex].ToString() + "/" + bagStuff.pokePlaya[chosenIndex].hp.ToString();
            if (currentHP[chosenIndex] <= DEAD)
            {
                PokeDied();
            }
            else
            {
                pokemon.GetComponent<Animator>().SetBool("Attack", true);
                yield return new WaitForSeconds(.5f);
                pokemon.GetComponent<Animator>().SetBool("Attack", false);
                opponentPokemon.currentHP = opponentPokemon.currentHP - (int)mydamage;
                opponentPokemon.wildHealthNum.text = opponentPokemon.currentHP.ToString() + "/" + opponentPokemon.wildPoke.hp.ToString();
            }
        }

        if (opponentPokemon.currentHP <= DEAD)
        {
            WildDead();
        }
        if (currentHP[chosenIndex] <= DEAD)
        {
            PokeDied();
        }
        else
        {
            commands.text = "What will " + bagStuff.pokePlaya[chosenIndex].pokeName + " do?";
            initial.enabled = true; //Turns off the attack menu
        }
    }
    public void Attack1() //Function for when first attack is used...
    {
        StartCoroutine(AttackCalc(0));
    }
    public void Attack2() //Function for when attack 2 is used...
    {
        StartCoroutine(AttackCalc(1));
    }
    public void Attack3() //Function for when attack 3 is used...
    {
        StartCoroutine(AttackCalc(2));
    }
    public void Attack4()//Function for when attack 4 is used...
    {
        StartCoroutine(AttackCalc(3));
    }
}