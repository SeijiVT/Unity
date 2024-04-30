using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    public int movespeed = 5;
    private Rigidbody2D _rb;
    public bool isJumping;
    // Start is called before the first frame update
    
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        
        Vector3 moveInput = new Vector3(horizontalInput, 0, 0);


        Vector3 nextPosition = transform.position + moveInput * movespeed * Time.deltaTime;

        _rb.MovePosition(nextPosition);
    }
}
