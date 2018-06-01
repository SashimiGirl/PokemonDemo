using UnityEngine;
using System.Collections;
using UnityEditor.SceneManagement;

public class PlayerMove : MonoBehaviour {

    Rigidbody2D rbody;
    GameObject player; 
    Animator anim;
    ChangeScene ChangeScene;
    const int STARTSCENE = 0;
    const int WALKSCENE = 1;
    const int AREA1 = 2;
    const int AREA2 = 4;
    const int BATTLESCENE = 3;
    const int HOSPITAL = 6;
    

    // Use this for initialization
    void Start () {
        ChangeScene = GameObject.Find("SceneManager").GetComponent<ChangeScene>();
        player = GameObject.Find("player");

        if (ChangeScene.lastscene == BATTLESCENE)
        {
            //ChangeScene.lastscene = BATTLESCENE;
            float newX = PlayerPrefs.GetFloat("PlayerX");
            float newY = PlayerPrefs.GetFloat("PlayerY");
            player.transform.position = new Vector2(newX, newY);
        }
        else if (ChangeScene.lastscene == STARTSCENE)
        {
            //player.transform.position = new Vector2(-75, 120);
            player.transform.position = new Vector2(-140, 126);
            ChangeScene.lastscene = Application.loadedLevel;
        }
        else if (ChangeScene.lastscene == AREA1)
        {
            float newX = PlayerPrefs.GetFloat("PlayerX");
            float newY = PlayerPrefs.GetFloat("PlayerY");
            player.transform.position = new Vector2(newX, newY);
        }
        else if (ChangeScene.lastscene == AREA2)
        {
            player.transform.position = new Vector2(-75, 120);
        }
        else if (ChangeScene.lastscene == WALKSCENE)
        {
            player.transform.position = new Vector2(-183, 135);
        }
        else if (ChangeScene.lastscene == HOSPITAL)
        {
            player.transform.position = new Vector2(-128, 81);
        }

        Debug.Log("lastscene before loadlevel"+ ChangeScene.lastscene);

        ChangeScene.lastscene = Application.loadedLevel;
        Debug.Log("lastscene after loadlevel: " + ChangeScene.lastscene);
        
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update()
    {
       
        Vector2 movement_vector = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));

        if (movement_vector!=Vector2.zero) 
        {
            anim.SetBool("walking", true);
            anim.SetFloat("input_x", movement_vector.x);
            anim.SetFloat("input_y", movement_vector.y);
        }
        else{
                anim.SetBool("walking", false);
        }
        rbody.MovePosition(rbody.position + movement_vector * (Time.deltaTime*6));
 }

         
}
