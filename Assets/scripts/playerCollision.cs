using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollision : MonoBehaviour
{
    planetSpawner ps;
    public birdSpawner bs;
    bool isNotAi = false;

    private void Start()
    {
        ps = FindObjectOfType<planetSpawner>();
        bs = FindObjectOfType<birdSpawner>();
    }

    void Update()
    {
        if (!isNotAi)
        {
            if (bs.allrocketsDead)
            {
                float i = 0;
                foreach (GameObject rockets in bs.birds)
                {
                    rockets.GetComponent<playerMovement>().fitness = 0;
                    rockets.GetComponent<playerMovement>().isNotMoving = false;
                    rockets.transform.position = new Vector3(-5.24f, 2 - i, 0f);
                    i += 0.5f;
                }

                ps.restartSpawner();
                ps.hasSpawned = false;
                bs.allrocketsDead = false;

            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "planet" || collision.collider.tag == "border")
        {
            if (isNotAi)
            {
                transform.position = new Vector3(-5.24f, 0f, 0f);
                ps.restartSpawner();
            }
            else if (!isNotAi)
            {
                gameObject.GetComponent<playerMovement>().isNotMoving = true;
            }
        }
    }
}
