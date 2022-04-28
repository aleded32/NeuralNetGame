using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdSpawner : MonoBehaviour
{

    public List<GameObject> birds;
    public GameObject bird;
    public bool allrocketsDead = false;
    

    // Start is called before the first frame update
    void Start()
    {
        birds.Add(Instantiate(bird, new Vector3(-5.24f, 0, 0), transform.rotation));
        birds.Add(Instantiate(bird, new Vector3(-5.24f, 0, 0), transform.rotation));
        birds.Add(Instantiate(bird, new Vector3(-5.24f, 0, 0), transform.rotation));
        birds.Add(Instantiate(bird, new Vector3(-5.24f, 0, 0), transform.rotation));
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < birds.Count; i++)
         Debug.Log("bird  " + i + "  " + birds[i].GetComponent<neuralNetwork>().outputLayer.inputValue);
    }
}
