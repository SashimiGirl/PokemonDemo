﻿using UnityEngine;
using UnityEngine.UI;

public class Run : MonoBehaviour {

    Rigidbody2D rbody;
    Animator anim;
    public int speed;
    private Image Sprite;


    // Use this for initialization
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Sprite = GetComponent<Image>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 movement_vector = new Vector2(1, 0) / 1000;
        if (speed == 1)
        {
             movement_vector = new Vector2(1, 0) / 1000;
        }
        else if (speed == 2)
        {
             movement_vector = new Vector2(3, 0) / 500;
        }
    
        rbody.MovePosition(rbody.position + movement_vector);
    }


   public void Slow()
    {
        speed = 1;
        anim.SetBool("speed", false);

        anim = GetComponent<Animator>();
    }

    public void Fast()
    {
        speed = 2;
        anim.SetBool("speed", true);

        anim = GetComponent<Animator>();
    }
}
