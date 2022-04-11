using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuController : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Continue();
    }

    public void startPressed()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void exitPressed()
    {
        Application.Quit();
    }

    void Continue()
    {
        if (SceneManager.GetSceneByBuildIndex(1) == SceneManager.GetActiveScene())
        {
            if (Input.GetKeyDown(KeyCode.Space))
                SceneManager.LoadScene(2, LoadSceneMode.Single);
        }
    }
        
}
