using UnityEngine;
using System.Collections;

public class eeveeRun : MonoBehaviour
{

    Rigidbody2D rbody;
    Animator anim;
    public Run Run;
    public int speed;
    private SpriteRenderer Sprite;
    public int sortingLayer;
    private float thresholdA;
    public bool tooFar;

    // Use this for initialization
    void Start()
    {

        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Sprite = GetComponent<SpriteRenderer>();
        Sprite.sortingLayerID = sortingLayer;
        tooFar = false;
        thresholdA = -.95f;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distance = rbody.position.x;
        //Debug.Log("distance");
        //Debug.Log(distance);
        //Debug.Log(rbody.position.x);
        if (distance > (thresholdA+.01f))//&&Run.speed!=2
        {
            StartCoroutine(waitAwhile());
        }
        else
            run();


    }

    void run()
    {
        
        Vector2 movement_vector = new Vector2(3, 0) / 1000;
       rbody.MovePosition(rbody.position + movement_vector);
    }

    public IEnumerator waitAwhile()
    {
        tooFar = true;
        anim.SetBool("tooFar", true);
        //Debug.Log("thresholdA ");
        //Debug.Log(thresholdA);
        Vector2 movement_vector = new Vector2(-3f, 0) / 1000;
        rbody.MovePosition(rbody.position + movement_vector);
        yield return new WaitForSeconds(5);
        tooFar = false;
        anim.SetBool("tooFar", false);
        thresholdA = rbody.position.x;

    }
}