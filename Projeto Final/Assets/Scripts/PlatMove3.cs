using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatMove3 : MonoBehaviour
{
    public float moveSpeed = 10f;
    public bool platform;
    public bool moveRight = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (platform)
        {
            if (transform.position.x > 138)
            {
                moveRight = false;
            }
            else if (transform.position.x < 119)
            {
                moveRight = true;
            }
            if (moveRight)
            {
                transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.right * -moveSpeed * Time.deltaTime);
            }
        }
    }
}
