using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float jumpForce;
    Rigidbody2D rb;
    bool iskeyPressed;
    public GameObject pauseMenu;
    public float fitness = 0;
    public bool isNotMoving;
    planetSpawner ps;
    birdSpawner bs;
    bool isNotAi = false;

    void Start()
    {
        
        iskeyPressed = false;
        isNotMoving = false;
        rb = gameObject.GetComponent<Rigidbody2D>();

        ps = FindObjectOfType<planetSpawner>();
        bs = FindObjectOfType<birdSpawner>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isNotAi)
        {
            if (!isNotMoving)
            {
                gameObject.GetComponent<Collider2D>().enabled = true;
                fitness++;
            }
            else
            {
                if (gameObject.transform.position.y < -5)
                {
                    gameObject.GetComponent<Collider2D>().enabled = true;
                }
                else
                    gameObject.GetComponent<Collider2D>().enabled = false;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
                move();
        }
           

        pauseGame();
    }

    public void move()
    {
        
        rb.velocity = Vector2.up * jumpForce * Time.deltaTime;

       
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
