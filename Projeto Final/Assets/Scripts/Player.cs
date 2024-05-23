using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float Speed;
    private Rigidbody2D rig;
    public float JumpForce;
    public bool isJumping;

    public int MaxHealth;
    public int CurrentHealth;
    public AudioSource bgAudio;
    private Animator anim;

   
   
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        bgAudio.Play();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      
        Move();
        Jump();

    }

    void Move()
    {
        
        float movement = Input.GetAxis("Horizontal");
        rig.velocity = new Vector2(movement*Speed, rig.velocity.y);
      
        if (Input.GetAxis("Horizontal") > 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        if (Input.GetAxis("Horizontal") < 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        if (Input.GetAxis("Horizontal") == 0f)
        {
            anim.SetBool("walk", false);
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isJumping==false)
        {
            rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
            anim.SetBool("jump", true);
            //anim.SetBool("fall", false);

            //1,814186943225635
        }


    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer==8)
        {
            isJumping = false;
            anim.SetBool("jump", false);
           


        }
        if(collision.gameObject.layer==7)
        {
            GameController.instance.ShowGameOver();
            Destroy(gameObject);
        }
        if (collision.gameObject.layer == 9)
        {
            GameController.instance.ShowGameOver();
            Destroy(gameObject);
        }
        if (collision.gameObject.layer == 10)
        {
            GameController.instance.ShowNextLevel();
            Destroy(gameObject);
        }
        if (collision.gameObject.layer == 11)
        {
            GameController.instance.ShowGameOver();
            Destroy(gameObject);
        }
        if (collision.gameObject.tag=="Platform")
        {
            gameObject.transform.parent = collision.transform;
        }
        if (collision.gameObject.layer==13)
        {
            rig.gravityScale *= -1;
            JumpForce *= -1;
            anim.SetBool("Rotation", true);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isJumping = true;
        }
        if (collision.gameObject.tag == "Platform")
        {
            gameObject.transform.parent = null;
        }
    }
    
}

