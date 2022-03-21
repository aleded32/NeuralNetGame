using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planetSpawner : MonoBehaviour
{
   
   
    public GameObject planet;
    public GameObject player;

    int spawnArea;
    int[] spawnpoints;
    bool isPlanetsDestroyed;

    List<GameObject> planets;

    private void Start()
    {
        spawnpoints = new int[] { -4, -2, 2, 4 };
        planets = new List<GameObject>();
        spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (planets.Exists(x => x.tag == "planet") && !isPlanetsDestroyed)
        {
            if (player.transform.position.x > planets[0].transform.position.x)
            {
                spawn();
                isPlanetsDestroyed = true;
            }

          
        }

        for (int i = 0; i < planets.Count; i++)
        {
            if (planets[i].transform.position.x < -10)
            {
                Destroy(planets[i]);
                planets.RemoveAt(i);
                isPlanetsDestroyed = false;
            }

        }

    }

    void spawn()
    {
        spawnArea = Random.Range(0, 3);


        if (spawnArea == 0)
        {
            planets.Add(Instantiate(planet, new Vector2(10, spawnpoints[Random.Range(0, 2)]), Quaternion.identity));
        }
        else if (spawnArea == 1)
        {
            planets.Add(Instantiate(planet, new Vector2(10, spawnpoints[Random.Range(2, 4)]), Quaternion.identity));
        }
        else
        {
            planets.Add(Instantiate(planet, new Vector2(10, spawnpoints[Random.Range(0, 2)]), Quaternion.identity));
            planets.Add(Instantiate(planet, new Vector2(10, spawnpoints[Random.Range(2, 4)]), Quaternion.identity));
        }
    }
}
