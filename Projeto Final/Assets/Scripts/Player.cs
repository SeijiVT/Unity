using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float Speed;
    private Rigidbody2D rig;
    public float JumpForce;
    public bool isJumping;

   
   
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        //Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        //transform.position += movement * Time.deltaTime * Speed;
        float movement = Input.GetAxis("Horizontal");
        rig.velocity = new Vector2(movement*Speed, rig.velocity.y);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isJumping==false)
        {
            rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);

        }


    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer==8)
        {
            isJumping = false;
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
        
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isJumping = true;
        }
    }
}

