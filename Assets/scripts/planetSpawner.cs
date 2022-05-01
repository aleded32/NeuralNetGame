using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class planetSpawner : MonoBehaviour
{
   
   
    public GameObject planet;
    public GameObject player;

    int spawnArea;
    float[] spawnpoints;
    bool isPlanetsDestroyed;
    bool isNotAi = false;
    public bool hasSpawned = false;

    public List<GameObject> planets;
    birdSpawner bs;

    ScoreTime st;

    private void Start()
    {
        spawnpoints = new float[] { -4, -3f, 3f, 4 };
        planets = new List<GameObject>();
        planets.Add(Instantiate(planet, new Vector2(10, spawnpoints[Random.Range(0, 2)]), Quaternion.identity));
        planets.Add(Instantiate(planet, new Vector2(10, spawnpoints[Random.Range(2, 4)]), Quaternion.identity));

        st = FindObjectOfType<ScoreTime>();
        bs = GetComponent<birdSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isNotAi)
        {
            if (bs.birds.Exists(x => x.transform.position.x > planets[0].transform.position.x) && !isPlanetsDestroyed)
            {
                
                
                        spawn();
                      
                        isPlanetsDestroyed = true;
                    
                

            }
        }
        else if(isNotAi)
        {
            if (player.transform.position.x > planets[0].transform.position.x && !isPlanetsDestroyed)
            {
                spawn();
               
                isPlanetsDestroyed = true;
            }
        }

        destroyPlanets();
    }

    void spawn()
    {
        if (planets.Count < 4 && !hasSpawned)
        {
             st.score++;
            planets.Add(Instantiate(planet, new Vector2(10, spawnpoints[Random.Range(0, 2)]), Quaternion.identity));
            planets.Add(Instantiate(planet, new Vector2(10, spawnpoints[Random.Range(2, 4)]), Quaternion.identity));
           
            hasSpawned = true;
        }
    }

    void destroyPlanets()
    {
        for (int i = 0; i < planets.Count; i++)
        {
            if (planets[i].transform.position.x < -12)
            {
                Destroy(planets[i]);
                planets.Remove(planets[i]);
               
               
            }

           

        }

        if (!isNotAi)
        {

            bs.birds = bs.birds.OrderByDescending(x => x.GetComponent<playerMovement>().fitness).ToList();

            if (!planets.Exists(x => x.transform.position.x < bs.birds[0].transform.position.x) && bs.birds[0].GetComponent<playerMovement>().isNotMoving == false)
            {
                hasSpawned = false;
                isPlanetsDestroyed = false;
            }
                


        }
        else if (isNotAi)
        {
            if (!planets.Exists(x => x.transform.position.x < player.transform.position.x))
            {
                isPlanetsDestroyed = false;
            }
                
        }


    }

    public void restartSpawner()
    {

        for (int i = 0; i < planets.Count; i++)
        {      
           Destroy(planets[i]);
        }

        planets.Clear();
        if (st.score > st.highScore)
            st.highScore = st.score;

        
        st.score = 0;
        isPlanetsDestroyed = false;
        planets.Add(Instantiate(planet, new Vector2(10, spawnpoints[Random.Range(0, 2)]), Quaternion.identity));
        planets.Add(Instantiate(planet, new Vector2(10, spawnpoints[Random.Range(2, 4)]), Quaternion.identity));

    }
}
