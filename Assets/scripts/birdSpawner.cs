using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdSpawner : MonoBehaviour
{

    public List<GameObject> birds;
    public GameObject bird;

    // Start is called before the first frame update
    void Start()
    {
        birds.Add(Instantiate(bird, new Vector3(-5.24f, 0, 0), Quaternion.identity));
        birds.Add(Instantiate(bird, new Vector3(-5.24f, 0, 0), Quaternion.identity));
        birds.Add(Instantiate(bird, new Vector3(-5.24f, 0, 0), Quaternion.identity));
        birds.Add(Instantiate(bird, new Vector3(-5.24f, 0, 0), Quaternion.identity));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
