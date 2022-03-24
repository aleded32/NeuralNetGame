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

    ScoreTime st;

    private void Start()
    {
        spawnpoints = new int[] { -4, -2, 2, 4 };
        planets = new List<GameObject>();
        spawn();

        st = FindObjectOfType<ScoreTime>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x > planets[0].transform.position.x && !isPlanetsDestroyed)
        {
           spawn();
           st.score++;
           isPlanetsDestroyed = true;
        }

        destroyPlanets();
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

        if (!planets.Exists(x => x.transform.position.x < player.transform.position.x))
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
            PlayerPrefs.SetInt("highScore", st.score);     

        st.highScore = PlayerPrefs.GetInt("highScore");
        st.score = 0;
        isPlanetsDestroyed = false;
        spawn();
       
    }
}
