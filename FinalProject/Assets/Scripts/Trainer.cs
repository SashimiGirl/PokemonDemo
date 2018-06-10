using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Trainer : MonoBehaviour {

    public Sprite boyTrainerFront;
    public Sprite boyTrainerBack;
    public Sprite boyTrainerRight;
    public Sprite boyTrainerLeft;
    public Sprite look;

    public Text Away;

    public Animator animator;
    public float speed = 2.0f;
    Vector3 pos;
    Transform tr;

    const int MENUSCENE = 2;
    const int SIZE = 4;

    void Start()
    {
        pos = transform.position;
        tr = transform;
    }

    void FixedUpdate()
    {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        animator.SetFloat("StateH", h);
        animator.SetFloat("StateV", v);
        if (Input.GetKey(KeyCode.UpArrow) && tr.position == pos)
        {
            pos += (Vector3.up)/2;
            look = boyTrainerBack;
        }
        else if (Input.GetKey(KeyCode.RightArrow) && tr.position == pos)
        {
            pos += (Vector3.right)/2;
            look = boyTrainerRight;
        }
        else if (Input.GetKey(KeyCode.DownArrow) && tr.position == pos)
        {
            pos += (Vector3.down)/2;
            look = boyTrainerFront;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && tr.position == pos)
        {
            pos += (Vector3.left) / 2;
            look = boyTrainerLeft;
        }
        else if(tr.position == pos)
            GetComponent<Image>().sprite = look;
        
        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
    }

    void OnCollisionEnter2D()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        float z = transform.position.z;

        if ((int)(x + 0.5) > (int)x && x > 0)
            x = (int)x + 0.5f;
        else if ((int)(x - 0.5) < (int)x && x < 0)
            x = (int)x - 0.5f;
        else
            x = (int)x;

        if ((int)(y + 0.5) > (int)y && y > 0)
            y = (int)y + 0.5f;
        else if ((int)(y - 0.5) < (int)y && y < 0)
            y = (int)y - 0.5f;
        else
            y = (int)y;

        z = 0f;

        Vector3 away = new Vector3(x, y, z);
        pos = away;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("GrassSpot"))
        { 
            int found = Random.Range(0, 10);
            Away.text = "Random number: " + found;
            if (found == 2)
            {
                SceneManager.LoadScene(MENUSCENE);
            }
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
    }


}
