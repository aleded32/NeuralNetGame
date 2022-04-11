using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public float jumpForce;
    Rigidbody2D rb;
    bool iskeyPressed;
    public GameObject pauseMenu;

    void Start()
    {
        iskeyPressed = false;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        pauseGame();
    }

    void move()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce * Time.deltaTime;
            
        }
        
    }

    void pauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !iskeyPressed)
        {
            Time.timeScale = 0.0f;
            pauseMenu.SetActive(true);
            iskeyPressed = true;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && iskeyPressed)
        {
            Time.timeScale = 1.0f;
            pauseMenu.SetActive(false);
            iskeyPressed = false;
        }
    }
}
