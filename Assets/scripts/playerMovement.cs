using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public float jumpForce;
    Rigidbody2D rb;
    bool iskeyPressed;

    void Start()
    {
        iskeyPressed = false;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    void move()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce * Time.deltaTime;
            
        }
        
    }
}
