using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollision : MonoBehaviour
{
    planetSpawner ps;
    public birdSpawner bs;
    

    private void Start()
    {
        ps = FindObjectOfType<planetSpawner>();
        bs = FindObjectOfType<birdSpawner>();
    }

    void Update()
    {
        if (bs.allrocketsDead)
        {
            float i = 0;
            foreach (GameObject rockets in bs.birds)
            {
                rockets.GetComponent<playerMovement>().fitness = 0;
                rockets.GetComponent<playerMovement>().isNotMoving = false;
                rockets.transform.position = new Vector3(-5.24f, 1 - i , 0f);
                i+= 0.5f;
            }

            ps.restartSpawner();

            bs.allrocketsDead = false;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "planet" || collision.collider.tag == "border")
        {
           
            gameObject.GetComponent<playerMovement>().isNotMoving = true;

        }
    }
}
