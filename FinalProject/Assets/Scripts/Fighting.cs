using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fighting : MonoBehaviour
{
    public ChangeScene ChangeScene;
    public PokemonStats PokemonStats;
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
    public BagStuff BagStuff; //Grabbing the bag shizzle
    public TeamSetUp TeamSetUp;
    public OpponentPokemon OpponentPokemon; //This is the randomly selected wild pokemon
    public PokeSwitch PokeSwitch;

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
        BagStuff = GameObject.Find("TrainerBag").GetComponent<BagStuff>();
        ChangeScene = GameObject.Find("SceneManager").GetComponent<ChangeScene>();
        OpponentPokemon = GameObject.Find("WildThing").GetComponent<OpponentPokemon>(); //Grabing opponent script
        TeamSetUp = GameObject.Find("SetTeam").GetComponent<TeamSetUp>();
        PokeSwitch = GameObject.Find("PokeMenu").GetComponent<PokeSwitch>();
        PokemonStats = GameObject.Find("Pokemon").GetComponent<PokemonStats>();
        for (int j = 0; j < SIZE; j++)
            chosenPoke[j] = new PokemonStats.Stats();
        for (int j = 0; j < SIZE; j++)
        {
            if (TeamSetUp.pokePlaya[j].pokeName != "")
            {
                Debug.Log("Team set up for poke playa begin fighting.");
                Debug.Log("Pokemon Name: " + TeamSetUp.pokePlaya[0].pokeName + "\nHp: " + TeamSetUp.pokePlaya[0].hp.ToString() + "\nAttack: " + TeamSetUp.pokePlaya[0].atk.ToString() + "\nSpeed: " + TeamSetUp.pokePlaya[0].sp.ToString() + "\nDefense: " + TeamSetUp.pokePlaya[0].def.ToString());
                chosenPoke[j].pokeFront = TeamSetUp.pokePlaya[j].pokeFront;
                chosenPoke[j].pokeBack = TeamSetUp.pokePlaya[j].pokeBack;
                chosenPoke[j].pokeName = TeamSetUp.pokePlaya[j].pokeName;
                chosenPoke[j].hp = TeamSetUp.pokePlaya[j].hp;
                chosenPoke[j].atk = TeamSetUp.pokePlaya[j].atk;
                chosenPoke[j].sp = TeamSetUp.pokePlaya[j].sp;
                chosenPoke[j].def = TeamSetUp.pokePlaya[j].def;
                currentHP[j] = TeamSetUp.pokePlaya[j].hp;
                for (int k = 0; k < SIZE; k++)
                {
                    chosenPoke[j].attackName[k] = TeamSetUp.pokePlaya[j].attackName[k];
                    chosenPoke[j].description[k] = TeamSetUp.pokePlaya[j].description[k];
                    chosenPoke[j].attackPower[k] = TeamSetUp.pokePlaya[j].attackPower[k];
                }

            }
            else
                break;
        }

        Switch();
        PokemonSwitch();
        exit.gameObject.SetActive(false);

        /*
        if (GameObject.Find("ChosenOne").GetComponent<SpriteRenderer>().sprite != growlitheback)
        { //Changing the size of the pokemon that are not growlithe...
            pokemon.transform.localScale += new Vector3(6.381F, 6.381F, 6.381F); //I won't need this when they...
            pokemon.transform.position += new Vector3(0, 0.14f, 0); //Are all the same size
        }
       */
        //Switch();
    }

    public void Switch()
    { 
        pokemon.GetComponent<SpriteRenderer>().sprite = chosenPoke[chosenIndex].pokeBack;
        //Changing our pokemon pic to the correct pokemon

        garyObject.SetActive(false);
        pokeballObject.SetActive(false);
        berryObject.SetActive(false);
        pokemon.SetActive(true);
        wildThing.SetActive(true);

        pokemonName.text = chosenPoke[chosenIndex].pokeName; //Setting our pokemon's name to the one chosen
        healthNum.text = currentHP[chosenIndex].ToString() + "/" + chosenPoke[chosenIndex].hp.ToString(); //Setting the initial health for our pokemon
        commands.text = "What will " + chosenPoke[chosenIndex].pokeName + " do?"; //Asking the user to choose something
        initial.enabled = true; //Turns on the initial menu by turning off canvas
        attacks.enabled = false; //Turns off the attack menu by turning off canvas
        bag.enabled = false; //Turns off the pokemon bag
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
            attackName[i].text = chosenPoke[chosenIndex].attackName[i];
            attackPower[i] = chosenPoke[chosenIndex].attackPower[i];
        }
    }

    public void WildDead() //Changing the scene if the wild pokemon... faints
    {
        ChangeScene.ChangeToScene(WINSCENE);
    } 

    public void PokeDied()
    {
        PokeSwitch.DeadPoke();
        if(PokeSwitch.anymore)
        {
            PokemonSwitch();
            exit.gameObject.SetActive(false);
        }
        else
        {
            ChangeScene.ChangeToScene(POKECENTER);
        }
    }

    public void RunButton()
    {
        ChangeScene.ExitBattle();
    }

    public void LikeTheWind() //Chaning the scene if trainer runs... dif from wild dead if we want to add experience/not being able to run...
    {
        commands.text = "What would you like to use to try bribing the wild " + OpponentPokemon.wildPoke.pokeName + "?";
        initial.enabled = false; //Turns off the initial menu by turning off canvas
        attacks.enabled = false; //Turns off the attack menu by turning off canvas

        bOption1.gameObject.SetActive(false);
        bOption2.gameObject.SetActive(false);
        bOption3.gameObject.SetActive(false);
        bOption4.gameObject.SetActive(false);
        bribe.enabled = true; //Turns on the pokemon bag
        bBackButton.gameObject.SetActive(true);
        if (BagStuff.berries == EMPTY)
        {
            commands.text = "You have nothing to use in your bag...\nYou can't bribe the wild " + OpponentPokemon.wildPoke.pokeName + "...\nGood luck!";
        }
        else
        {
             if (BagStuff.berries > 0)
            {
                bOption1.GetComponentInChildren<Text>().text = "x" + BagStuff.berries;
                bOption1.gameObject.SetActive(true);
                bOption1.GetComponent<Image>().sprite = BagStuff.berryPic;
            }
        }
    }

    public void bribeOption1()
    {
        BagStuff.berries--;
        StartCoroutine(BerryPlay());
    }

    IEnumerator BerryPlay()
    {
        pokemon.SetActive(false);
        garyObject.SetActive(true);
        yield return new WaitForSeconds(.5f);
        berryObject.SetActive(true);


        yield return new WaitForSeconds(1.35f);
        berryObject.GetComponent<Animator>().speed = 0;
        runChance = Random.Range(0, 50);
        if (runChance != 2)
        {
            commands.text = "The wild " + OpponentPokemon.wildPoke.pokeName + " is distracted by the berry!";

            runOption.gameObject.SetActive(true);
            yield return new WaitForSeconds(2f);
            Switch();
            berryObject.GetComponent<Animator>().speed = 1;
        }
        else
        {
            commands.text = "The wild " + OpponentPokemon.wildPoke.pokeName + " did not like the berry!";
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
        if (BagStuff.pokeballs == EMPTY && BagStuff.berries == EMPTY)
        {
            commands.text = "You have nothing to use in your bag...\nYou're probably in trouble...\nGood luck!";
        }
        else
        {
            if (BagStuff.pokeballs > 0)
            {
                option1.GetComponentInChildren<Text>().text = "x" + BagStuff.pokeballs;
                option1.gameObject.SetActive(true);
                option1.GetComponent<Image>().sprite = BagStuff.pokeballPic;
            }
            /*
            else if (BagStuff.berries > 0)
            {
                option1.GetComponentInChildren<Text>().text = "x" + BagStuff.berries;
                option1.gameObject.SetActive(true);
                option1.GetComponent<Image>().sprite = BagStuff.berryPic;
            }
            if(BagStuff.pokeballs > 0 && BagStuff.berries > 0)
            {
                option1.GetComponentInChildren<Text>().text = "x" + BagStuff.pokeballs;
                option1.gameObject.SetActive(true);
                option1.GetComponent<Image>().sprite = BagStuff.pokeballPic;
                option2.GetComponentInChildren<Text>().text = "x" + BagStuff.berries;
                option2.gameObject.SetActive(true);
                option2.GetComponent<Image>().sprite = BagStuff.berryPic;
            }
            */
        }
    }

    public void Option1Button()
    {
        if(option1.GetComponentInChildren<Text>().text == "x" + BagStuff.berries)
        {
            //Do berry stuffz
        }
        if(option1.GetComponentInChildren<Text>().text == "x" + BagStuff.pokeballs)
        {
            Debug.Log("Before Pokeball");
            bag.enabled = false;
            StartCoroutine(PokePlay());
            Debug.Log("After Pokeball");
        }
    }
    public void Option2Button()
    {
        if (option1.GetComponentInChildren<Text>().text == "x" + BagStuff.berries)
        {
            //Do berry stuffz
        }
        if (option1.GetComponentInChildren<Text>().text == "x" + BagStuff.pokeballs)
        {
            Debug.Log("Before Pokeball");
            bag.enabled = false;
            StartCoroutine(PokePlay());
            Debug.Log("After Pokeball");
        }
    }

    IEnumerator PokePlay()
    {
        pokemon.SetActive(false);
        garyObject.SetActive(true);
        yield return new WaitForSeconds(.5f);
        pokeballObject.SetActive(true);

        yield return new WaitForSeconds(1.3f);

        wildThing.SetActive(false);

        if (OpponentPokemon.currentHP / OpponentPokemon.wildPoke.hp > 0.9f)
            pokeCatch = Random.Range(0, 50);
        else if (OpponentPokemon.currentHP / OpponentPokemon.wildPoke.hp > 0.7f)
            pokeCatch = Random.Range(0, 40);
        else if (OpponentPokemon.currentHP / OpponentPokemon.wildPoke.hp > 0.5f)
            pokeCatch = Random.Range(0, 30);
        else if (OpponentPokemon.currentHP / OpponentPokemon.wildPoke.hp > 0.3f)
            pokeCatch = Random.Range(0, 15);
        else if (OpponentPokemon.currentHP / OpponentPokemon.wildPoke.hp > 0.1f)
            pokeCatch = Random.Range(0, 4);
        else if (OpponentPokemon.currentHP / OpponentPokemon.wildPoke.hp <= 0.1f)
            pokeCatch = 2;
        Debug.Log(pokeCatch);

        if (pokeCatch == 2)
        {
            yield return new WaitForSeconds(5f);
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
        Debug.Log("Pokeball Called");
        BagStuff.pokeballs -= 1;
        if (pokeCatch == 2)
        {
            bool full = true;
            for (int j = 0; j < SIZE; j++)
            {
                if (TeamSetUp.pokePlaya[j].pokeName == "")
                {
                    if (OpponentPokemon.wildPoke.pokeName == "Growlithe")
                        TeamSetUp.GrStats(j);
                    else if (OpponentPokemon.wildPoke.pokeName == "Eevee")
                        TeamSetUp.EvStats(j);
                    else if (OpponentPokemon.wildPoke.pokeName == "Mudkip")  
                        TeamSetUp.MuStats(j);
                    else if (OpponentPokemon.wildPoke.pokeName == "Psyduck")
                        TeamSetUp.PsStats(j);
                    full = false;
                    break;
                }
            }
            if (full)
            {
                PokemonSwitch();
                pokeMenu.enabled = false;
                PokeSwitch.ResetForRelease();
                releaseMenu.enabled = true;
            }
            else
            {
                ChangeScene.ExitBattle();
            }
        }
        else
        {
            Switch();
            commands.text = OpponentPokemon.wildPoke.pokeName + " faught its way free.\nWhat will " + chosenPoke[chosenIndex].pokeName + " do?";
            double opdamage = (double)OpponentPokemon.wildPoke.atk / (double)chosenPoke[chosenIndex].def * (double)OpponentPokemon.power;
            currentHP[chosenIndex] = currentHP[chosenIndex] - (int)opdamage;

            OpponentPokemon.wildHealthNum.text = OpponentPokemon.currentHP.ToString() + "/" + OpponentPokemon.wildPoke.hp.ToString();

            if (OpponentPokemon.currentHP <= DEAD)
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
        //PokemonBag.enabled = false; //Turns off the pokemon bag
        commands.text = "What will " + chosenPoke[chosenIndex].pokeName + " do?";
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
        commands.text = "Which attack should " + chosenPoke[chosenIndex].pokeName + " use?"; //Self explanitory
        initial.enabled = false; //Turns off the attack menu by turning off canvas
        attacks.enabled = true;//Turns on the attack menu by turning off canvas
    }

    public void HighlightReset()
    {
        commands.text = "What will " + chosenPoke[chosenIndex].pokeName + " do?";
    }
    public void HighlightAttack1()
    {
        commands.text = chosenPoke[chosenIndex].description[0];
    }
    public void HighlightAttack2()
    {
        commands.text = chosenPoke[chosenIndex].description[1];
    }
    public void HighlightAttack3()
    {
        commands.text = chosenPoke[chosenIndex].description[2];
    }
    public void HighlightAttack4()
    {
        commands.text = chosenPoke[chosenIndex].description[3];
    }
    
    IEnumerator AttackCalc(int i)
    {
        OpponentPokemon.WildAttack();
        double mydamage = (double)chosenPoke[chosenIndex].atk / (double)OpponentPokemon.wildPoke.def * (double)attackPower[i];
        double opdamage = (double)OpponentPokemon.wildPoke.atk / (double)chosenPoke[chosenIndex].def * (double)OpponentPokemon.power;

        if (chosenPoke[chosenIndex].sp >= OpponentPokemon.wildPoke.sp)
        {
            pokemon.GetComponent<Animator>().SetBool("Attack", true);
            yield return new WaitForSeconds(.5f);
            pokemon.GetComponent<Animator>().SetBool("Attack", false);

            OpponentPokemon.currentHP = OpponentPokemon.currentHP - (int)mydamage;
            OpponentPokemon.wildHealthNum.text = OpponentPokemon.currentHP.ToString() + "/" + OpponentPokemon.wildPoke.hp.ToString();
            if (OpponentPokemon.currentHP <= DEAD)
            {
                WildDead();
            }
            else
            {
                wildThing.GetComponent<Animator>().SetBool("Smack", true);
                yield return new WaitForSeconds(.5f);
                wildThing.GetComponent<Animator>().SetBool("Smack", false);
                currentHP[chosenIndex] = currentHP[chosenIndex] - (int)opdamage;
                healthNum.text = currentHP[chosenIndex].ToString() + "/" + chosenPoke[chosenIndex].hp.ToString();
            }
        }
        else
        {
            wildThing.GetComponent<Animator>().SetBool("Smack", true);
            yield return new WaitForSeconds(.5f);
            wildThing.GetComponent<Animator>().SetBool("Smack", false);
            currentHP[chosenIndex] = currentHP[chosenIndex] - (int)opdamage;
            healthNum.text = currentHP[chosenIndex].ToString() + "/" + chosenPoke[chosenIndex].hp.ToString();
            if (currentHP[chosenIndex] <= DEAD)
            {
                PokeDied();
            }
            else
            {
                pokemon.GetComponent<Animator>().SetBool("Attack", true);
                yield return new WaitForSeconds(.5f);
                pokemon.GetComponent<Animator>().SetBool("Attack", false);
                OpponentPokemon.currentHP = OpponentPokemon.currentHP - (int)mydamage;
                OpponentPokemon.wildHealthNum.text = OpponentPokemon.currentHP.ToString() + "/" + OpponentPokemon.wildPoke.hp.ToString();
            }
        }

        if (OpponentPokemon.currentHP <= DEAD)
        {
            WildDead();
        }
        if (currentHP[chosenIndex] <= DEAD)
        {
            PokeDied();
        }
        else
        {
            commands.text = "What will " + chosenPoke[chosenIndex].pokeName + " do?";
            attacks.enabled = false; //Returns to initial menu
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