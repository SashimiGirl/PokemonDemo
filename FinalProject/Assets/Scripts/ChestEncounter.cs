

using UnityEngine;
using System.Collections;


public class ChestEncounter : MonoBehaviour
{
    // public Transform target;
    // Use this for initialization
    public float xPosition;
    public float yPosition;
    public GameObject player;
    Animator anim;
    //Rigidbody2D rbody;


    void Start()
    {
        
        //rbody = GetComponent<Rigidbody2D>();
    }
    /*
    IEnumerator OnTriggerEnter2D(Collider2D other)
    {
          anim = GetComponent<Animator>();
          anim.SetBool("HasKey", true);
    }
    */
    // Update is called once per frame
    void Update()
    {

    }
}
