using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollision : MonoBehaviour
{
    planetSpawner ps;
    

    private void Start()
    {
        ps = FindObjectOfType<planetSpawner>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "planet" || collision.collider.tag == "border")
        {
            ps.restartSpawner();
            gameObject.GetComponent<playerMovement>().isMoving = false;
            gameObject.transform.position = new Vector3(-5.24f, 0f, 0f);
            gameObject.GetComponent<neuralNetwork>().backPropagation();


        }
    }
}
