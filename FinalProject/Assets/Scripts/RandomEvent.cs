using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RandomEvent : MonoBehaviour {

    ChangeScene ChangeScene;
    public BagStuff BagStuff;
    public Canvas Event1;
    public Canvas Event2;
    public Canvas Event3;
    public Canvas Event4;
    public Canvas Event5;
    public Canvas Event6;
    public Canvas bodyfind1;
    public Canvas bodyfind2;
    public Canvas bodyfind3;


    //public Canvas investCanvas;
    public Button investigate;
    public bool inspect;
    public float timer = 0.0f;
    public Text randCount;

    //public Transform Event1;
	// Use this for initialization
	void Start () {
        ChangeScene.lastscene = Application.loadedLevel;

        Event1.enabled = false;
        Event2.enabled = false;
        Event3.enabled = false;
        Event4.enabled = false;
        Event5.enabled = false;
        Event6.enabled = false;
        bodyfind1.enabled = false;
        bodyfind2.enabled = false;
        bodyfind3.enabled = false;
        // investCanvas.enabled = false;
        BagStuff = GameObject.Find("TrainerBag").GetComponent<BagStuff>();
        investigate.gameObject.SetActive(false);
        Debug.Log("Event1 disabled");
       }


    // Update is called once per frame
    void Update()
    {

        int randomPick = Random.Range(1, 1600);
        //Debug.Log(randomPick);

         
            if (randomPick == 2)
            {
                if (Time.timeScale != 0)
                    StartCoroutine(Investigate());
            }


    }

    IEnumerator Investigate()
    {
        //.enabled = true;
        investigate.gameObject.SetActive(true);
        //investCanvas.enabled = true;
        yield return new WaitForSeconds(2f);

            investigate.gameObject.SetActive(false);
        
    }    

  public void discovery()
    {

        int eventPick = Mathf.Abs(Random.Range(1, 4));
        Debug.Log(eventPick);
        if (eventPick == 1)
        {
            berries();
        }
        else if (eventPick == 2)
        {
            teamRocket();
        }
        else if (eventPick==3)
            secretArea();
        else if (eventPick==4)
            beeDrill();
        else if (eventPick == 5)
            find();
        //else if (eventPick == 5)
          //  ();



        Debug.Log("Event1 enabled");
        
    }



    public void berries ()
    {

        Event1.enabled = true;
        investigate.gameObject.SetActive(false);
        Time.timeScale = 0;
        Debug.Log("Event1 enabled");
                
    }

    public void takeBerries()
    {

        BagStuff.berries++;
        travel();

    }

    public void teamRocket()
    {

        Event2.enabled = true;
        investigate.gameObject.SetActive(false);
        Time.timeScale = 0;
        Debug.Log("Event1 enabled");

    }

    public void secretArea()
    {

        Event3.enabled = true;
        investigate.gameObject.SetActive(false);
        Time.timeScale = 0;
        Debug.Log("Event1 enabled");

    }

    public void find()
    {
            
        Event4.enabled = true;
        investigate.gameObject.SetActive(false);
        Time.timeScale = 0;
        Debug.Log("Event1 enabled");

    }

    public void body()
    {
        int findPick = Mathf.Abs(Random.Range(1, 4));
        Debug.Log(findPick);
          if (findPick == 1)
          { Event4.enabled = false;
            bodyfind1.enabled=true;
          }
          else if (findPick ==2 )
          {   Event4.enabled = false;
              bodyfind2.enabled = true;
          }
          else
           {  Event4.enabled = false;
              bodyfind3.enabled=true;
        }
        
    }

    public void beeDrill()
    {

        Event5.enabled = true;
        investigate.gameObject.SetActive(false);
        Time.timeScale = 0;
        Debug.Log("Event1 enabled");
        Event6.enabled = true;

    }


    public void inspt()
    {
        inspect = true;
    }

    public void travel()
    {
       
        Event1.enabled = false;
        Event2.enabled = false;
        Event3.enabled = false;
        Time.timeScale = 1;
        investigate.gameObject.SetActive(false);
        Debug.Log("Event1 disabled");

    }
    
}
