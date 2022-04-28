using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planetSpawner : MonoBehaviour
{
   
   
    public GameObject planet;

    int spawnArea;
    int[] spawnpoints;
    bool isPlanetsDestroyed;

    public List<GameObject> planets;
    birdSpawner bs;

    ScoreTime st;

    private void Start()
    {
        spawnpoints = new int[] { -4, -2, 2, 4 };
        planets = new List<GameObject>();
        spawn();

        st = FindObjectOfType<ScoreTime>();
        bs = GetComponent<birdSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bs.birds.Exists(x => x.transform.position.x > planets[0].transform.position.x) && !isPlanetsDestroyed)
        {
           spawn();
           st.score++;
           isPlanetsDestroyed = true;
        }

        destroyPlanets();
    }

    void spawn()
    {
        
            planets.Add(Instantiate(planet, new Vector2(10, spawnpoints[Random.Range(0, 2)]), Quaternion.identity));
            planets.Add(Instantiate(planet, new Vector2(10, spawnpoints[Random.Range(2, 4)]), Quaternion.identity));
    }

    void destroyPlanets()
    {
        for (int i = 0; i < planets.Count; i++)
        {
            if (planets[i].transform.position.x < -10)
            {
                Destroy(planets[i]);
                planets.Remove(planets[i]);
               
               
            }

           

        }

        if (!planets.Exists(x => x.transform.position.x < bs.birds[0].transform.position.x))
            isPlanetsDestroyed = false;

      
       
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
        spawn();
       
    }
}
