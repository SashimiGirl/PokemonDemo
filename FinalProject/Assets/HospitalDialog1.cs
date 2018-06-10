using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class HospitalDialog1 : MonoBehaviour {

    ChangeScene changeScene;
    BagStuff bagStuff;
    Canvas joyA;
    Canvas joyB;
    Canvas lost;
    Text joyTextB;
    Button yes;
    Button no;
    GameObject peopleHolder;
    GameObject mon;
    GameObject dead;
    int price;
    const int BASEPRICE = 100;

    // Use this for initialization
    void Start () {
        bagStuff = GameObject.FindObjectOfType<BagStuff>();
        changeScene = GameObject.FindObjectOfType<ChangeScene>();
        joyA = GameObject.Find("Joy_A").GetComponent<Canvas>();
        joyB = GameObject.Find("Joy_B").GetComponent<Canvas>();
        lost = GameObject.Find("Lost").GetComponent<Canvas>();
        joyTextB = GameObject.Find("Joy_Text_B").GetComponent<Text>();
        yes = GameObject.Find("LeftButton").GetComponent<Button>();
        no = GameObject.Find("RightButton").GetComponent<Button>();
        peopleHolder = GameObject.Find("PeopleHolder");
        dead = GameObject.Find("Dead");
        mon = GameObject.Find("InputMoney");

        GameObject.Find("MoneyText").GetComponent<Text>().text = "Your cash: " + bagStuff.money;

        mon.SetActive(false);
        dead.SetActive(false);
        joyA.enabled = true;
        joyB.enabled = false;
        lost.enabled = false;
    }

    public void ToJoyB()
    {
        joyA.enabled = false;
        joyB.enabled = true;

        yes.onClick.AddListener(TruthSpeaker);
        no.onClick.AddListener(MoneyCount);
    }

    public void MoneyCount()
    {
        mon.SetActive(true);
        yes.enabled = false;
        no.enabled = false;
    }

    public void PantsOnFire(InputField input)
    {
        //Later renown can set chance...
        mon.SetActive(false);
        price = BASEPRICE;

        int num = 0;
        try
        {
            num = int.Parse(input.text);
        }
        catch
        {
            num = -10;
        }

        if (num == bagStuff.money)
        {
            price = BASEPRICE;
            joyTextB.text = "Nurse Joy:\nWell to heal your Pokemon, I am going to need " + price + ".";
            FinalMenu();
            return;
        }

        switch (Random.Range(0, 3)%3)
        {
            case 0:
                //User price
                if (num > 0 && num < BASEPRICE)
                {
                    price = num;
                    joyTextB.text = "Nurse Joy:\nHmm... alright kid, I'll give you a break. Give me " + price 
                        + " and I will heal your Pokemon.";
                    FinalMenu();
                }
                else if (num == 0)
                {
                    joyTextB.text = "Nurse Joy:\nNice try! I'm not healing your Pokemon for free! Now it will be " + price + ".";
                    price = 2 * BASEPRICE;
                    FinalMenu();
                } else if (num > BASEPRICE)
                {
                    price = BASEPRICE;
                    joyTextB.text = "Nurse Joy:\nWow, you have more than enough. I am going to need " + price
                            + " to heal your Pokemon.";
                    FinalMenu();
                }
                else
                {
                    joyTextB.text = "Nurse Joy:\nTrying to trick me?! I'm calling Officer Jenny!!";
                    StartCoroutine(UnderArrest());
                }
                break;
            default:
                price = Mathf.Abs(BASEPRICE - num);
                joyTextB.text = "Nurse Joy:\nHow could you lie to me?! I'm calling Officer Jenny!!";
                StartCoroutine(UnderArrest());
                break;
        }
    }

    void FinalMenu()
    {
        mon.SetActive(false);
        yes.enabled = true;
        no.enabled = true;
        yes.onClick.RemoveAllListeners();
        yes.onClick.AddListener(MoneyExchange);
        yes.GetComponentInChildren<Text>().text = "Pay";
        no.onClick.RemoveAllListeners();
        no.onClick.AddListener(Popo);
        no.GetComponentInChildren<Text>().text = "Don't pay";
    }

    void MoneyExchange()
    {
        StartCoroutine(SpendMoney());
    }

    void Denial()
    {
        StartCoroutine(DidNotPay());
    }
    
    void Popo()
    {
        joyTextB.text = "Nurse Joy:\nYou really aren't going to pay?! Fine, Officer Jenny!!";
        yes.enabled = false;
        no.enabled = false;
        StartCoroutine(UnderArrest());
    }

    IEnumerator SpendMoney()
    {
        if (bagStuff.money < price)
        {
            if (!peopleHolder.GetComponent<Animator>().GetBool("Angry"))
            {
                peopleHolder.GetComponent<Animator>().SetBool("Angry", true);
                yield return new WaitForSeconds(1.5f);
            }
            yield return StartCoroutine(Scold("Officer Jenny:\nYou don't have enough money!"));
            yield return StartCoroutine(DidNotPay());
        } else
        {
            bagStuff.money -= price;
            changeScene.ExitBattle();
        }
    }

    IEnumerator Scold(string words)
    {
        joyTextB.text = words;
        yield return new WaitForSeconds(2.0f);
    }

    IEnumerator DidNotPay()
    {
        int bye = Random.Range(0, bagStuff.TeamSize());
        yield return StartCoroutine(Scold("Officer Jenny:\nSay goodbye to " + bagStuff.pokePlaya[bye].pokeName + "!"));
        bagStuff.Genrelease(bye);
        if (bagStuff.TeamSize() > 0)
        {
            changeScene.ExitBattle();
        } else
        {
            //You have lost the game
            lost.enabled = true;
            joyB.enabled = false;
            string death = "You have no more Pokemon, no one by your side.\n"
                + "In this world, without any Pokemon you are doomed.\n"
                + "With no way to protect yourself or to make money you end up on the streets.\n"
                + "Pleading with every passerby for help, but no one takes pitty on you.\n"
                + "Depression beings to hit you pretty hard.\n"
                + "With no direction or hope,\n"
                + "You die.\n\n\n\n\n\n";
            foreach (char d in death)
            {
                lost.GetComponentInChildren<Text>().text += d;
                yield return new WaitForSeconds(0.05f);
            }
            dead.SetActive(true);
        }

    }

    public void TruthSpeaker()
    {
        //Later renown can set chance...

        switch (Random.Range(0, 3) % 3)
        {
            case 0:
                //User price
                price = BASEPRICE;
                joyTextB.text = "Nurse Joy:\nWell to heal your Pokemon, I am going to need " + price
                        + ".";
                FinalMenu();
                break;
            default:
                if (bagStuff.money < BASEPRICE)
                {
                    price = bagStuff.money;
                    joyTextB.text = "Nurse Joy:\nI appreciate your honesty. Tell you what, I'll give you a break. Give me " 
                        + price + " and I will heal your Pokemon.";
                    FinalMenu();
                } else
                {
                    price = BASEPRICE - Random.Range(1, 15);
                    joyTextB.text = "Nurse Joy:\nHaha geez kid, you have some dough on you! I'll give you a little discount because you're cute. "
                        + price + " and I will heal your Pokemon.";
                    FinalMenu();
                }
                break;
        }
    }

    IEnumerator UnderArrest()
    {
        price += BASEPRICE;
        yield return new WaitForSeconds(1.5f);
        peopleHolder.GetComponent<Animator>().SetBool("Angry", true);
        yield return new WaitForSeconds(1.5f);
        yes.enabled = true;
        no.enabled = true;
        joyTextB.text = "Officer Jenny:\nYou are in a lot of trouble! Now it costs " + price + "! Or say goodbye to one of your Pokemon!";
        yes.onClick.RemoveAllListeners();
        yes.onClick.AddListener(MoneyExchange);
        yes.GetComponentInChildren<Text>().text = "Pay";
        no.onClick.RemoveAllListeners();
        no.onClick.AddListener(Denial);
        no.GetComponentInChildren<Text>().text = "Don't pay";
    }

}
